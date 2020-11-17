using GetcuReone.Cdi;
using GetcuReone.Cdm.Configuration.Settings;
using GetcuReone.Cdm.Errors;
using GetcuReone.Cdo.File;
using GetcuReone.Cdo.Helpers;
using GetcuReone.Cdo.Settings.Entities;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace GetcuReone.Cdo.Settings.Facades
{
    /// <summary>
    /// Facade for settings.
    /// </summary>
    internal sealed class SettingsFacade : GrFacadeBase
    {
        /// <inheritdoc/>
        protected override string FacadeName => nameof(SettingsFacade);

        /// <summary>
        /// Check if the setting matches the type.
        /// </summary>
        /// <param name="setting"></param>
        /// <param name="settingType"></param>
        public void ValidateSetting(Setting setting, SettingType settingType)
        {
            if (!setting.Type.EqualsOrdinalIgnoreCase(settingType.Code))
                throw CdiHelper.CreateException(
                    SettingsErrorCode.InvalidSettingType,
                    $"Invalid setting type. Expected <{settingType.Code}>, actual <{setting.Type}>.");

            switch (settingType.FormatValue)
            {
                case FormatValue.Enumerate:
                    var expectedValue = settingType
                        .PermissibleValues
                        .FirstOrDefault(value => value.EqualsOrdinalIgnoreCase(setting.Value));

                    if (expectedValue == null)
                        throw CdiHelper.CreateException(
                            SettingsErrorCode.InvalidSettingType,
                            $"The setting contains an invalid value. Value <{setting.Value}>.");

                    setting.Value = expectedValue;
                    break;
                case FormatValue.Text:
                    if (!Regex.IsMatch(setting.Value, settingType.TextPattern))
                        throw CdiHelper.CreateException(
                            SettingsErrorCode.InvalidSettingValue,
                            $"The setting value does not match the pattern. Pattern <{settingType.TextPattern}>, value <{setting.Value}>.");
                    break;

                default: throw new InvalidEnumArgumentException($"Unknown value <{settingType.FormatValue}>.");
            }
        }

        public List<Setting> GetSettins(IEnumerable<string> settingFullCodes)
        {
            var data = new List<(string settingCode, string namespaceCode, string settingFullCode)>();
            var result = new List<Setting>();

            foreach (string settingFullCode in settingFullCodes)
            {
                string[] codes = settingFullCode.Split('.');
                string settingCode = codes.Last();
                string namespaceCode = string.Join(".", codes.Take(codes.Length - 1));

                (string settingCode, string namespaceCode, string settingFullCode) item = (settingCode, namespaceCode, settingFullCode);
                data.Add(item);
            }

            List<SettingNamespace> namespaces = GetFacade<SettingNamespaceFacade>().GetSettingNamespaces(data.Select(d => d.namespaceCode));
            var notFoundSettings = new List<string>();
            var defaultTypes = GetFacade<SettingContextFacade>().GetDefaultSettingTypes();
            IReadOnlyCollection<SettingType> allTypes = null;

            foreach (var item in data)
            {
                Setting setting = namespaces
                    .First(nSpace => nSpace.FullCode.EqualsOrdinalIgnoreCase(item.namespaceCode))
                    .Settings
                    .SingleOrDefault(s => s.Code.EqualsOrdinalIgnoreCase(item.settingCode));

                if (setting == null)
                {
                    notFoundSettings.Add(item.settingFullCode);
                    continue;
                }
                else if (string.IsNullOrEmpty(setting.Value))
                    setting.Value = setting.DefaultValue;

                SettingType type = defaultTypes.SingleOrDefault(t => t.Code.EqualsOrdinalIgnoreCase(setting.Type));

                if (type == null)
                {
                    if (allTypes == null)
                        allTypes = GetFacade<SettingContextFacade>().GetSettingTypes();
                    type = allTypes.SingleType(setting.Type);
                }

                ValidateSetting(setting, type);

                result.Add(setting);
            }

            if (!notFoundSettings.IsNullOrEmpty())
                throw CdiHelper.CreateException(
                    notFoundSettings
                        .Select(code => new ErrorDetail
                        {
                            Code = SettingsErrorCode.SettingNotFound,
                            Reason = $"Setting '{code}' not found.",
                        })
                        .ToList());

            return result;
        }

        public void SetSettings(List<SetSettingsRequest> requests)
        {
            List<Setting> settingFormFile = GetSettins(requests.ConvertAll(s => s.FullCode));
            var defaultTypes = GetFacade<SettingContextFacade>().GetDefaultSettingTypes();
            List<SettingType> allTypes = null;

            foreach (var item in settingFormFile)
            {
                var request = requests.First(s => s.FullCode.EqualsOrdinalIgnoreCase(item.FullCode));

                if (request.NeedSetDefaultValue)
                    item.Value = item.DefaultValue;
                else
                    item.Value = request.Value;

                SettingType type = defaultTypes.SingleOrDefault(t => t.Code.EqualsOrdinalIgnoreCase(item.Type));

                if (type == null)
                {
                    if (allTypes == null)
                        allTypes = GetFacade<SettingContextFacade>().GetSettingTypes();
                    type = allTypes.SingleType(item.Type);
                }

                if (request.CheckSettingType && !request.SettingType.EqualsOrdinalIgnoreCase(item.Type))
                    throw CdiHelper.CreateException(SettingsErrorCode.InvalidSettingType, $"The setting contains an unexpected type. Expected <{request.SettingType}>, Actual <{item.Type}>.");

                ValidateSetting(item, type);
            }

            var lockerFacade = GetFacade<LockerFacade>();

            foreach (var pair in GetFacade<SettingContextFacade>().LoadSettingContext(true))
            {
                var context = pair.Value;
                var namespaces = new List<SettingNamespace>();
                var setSettings = new List<Setting>();

                foreach (var item in settingFormFile)
                {
                    string[] codes = item.FullCode.Split('.');
                    string namespaceCode = string.Join(".", codes.Take(codes.Length - 1));

                    SettingNamespace nSpace = namespaces.FirstOrDefault(n => n.FullCode.EqualsOrdinalIgnoreCase(namespaceCode));

                    if (nSpace == null)
                    {
                        nSpace = GetFacade<SettingNamespaceFacade>().FindNamespace(context.Namespaces, namespaceCode);

                        if (nSpace != null)
                        {
                            nSpace.FullCode = namespaceCode;
                            namespaces.Add(nSpace);
                        }
                    }

                    if (nSpace != null)
                    {
                        nSpace.Settings.First(s => s.Code.EqualsOrdinalIgnoreCase(item.Code)).Value = item.Value;
                        setSettings.Add(item);
                        continue;
                    }
                }

                if (setSettings.Count != 0)
                {
                    lock (lockerFacade.GetLocker(pair.Key))
                    {
                        try
                        {
                            using (var fileStrem = GetAdapter<FileAdapter>().Open(pair.Key, FileMode.Create))
                            {
                                using (var streamWriter = new StreamWriter(fileStrem, Encoding.UTF8))
                                    context.SerializeToTextWriter(streamWriter);
                            }
                        }
                        catch
                        {
                            lockerFacade.Unblock(pair.Key);
                            throw;
                        }
                    }

                    foreach (var item in setSettings)
                        settingFormFile.Remove(item);
                }

                lockerFacade.Unblock(pair.Key);

                if (settingFormFile.Count == 0)
                    break;
            }
        }
    }
}
