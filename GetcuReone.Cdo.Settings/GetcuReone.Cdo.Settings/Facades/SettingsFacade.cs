using GetcuReone.Cdi;
using GetcuReone.Cdm.Configuration.Settings;
using GetcuReone.Cdm.Errors;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
            var defaultTypes = new SettingType[]
            {
                SettingType.String,
                SettingType.Int,
                SettingType.Bool,
                SettingType.PowerMode,
            };
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
    }
}
