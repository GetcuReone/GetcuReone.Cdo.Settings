using GetcuReone.Cdi;
using GetcuReone.Cdm.Configuration.Settings;
using GetcuReone.Cdm.Configuration.Settings.Enums;
using GetcuReone.Cdo.Settings.Entities;
using GetcuReone.Cdo.Settings.Facades;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace GetcuReone.Cdo.Settings
{
    /// <summary>
    /// Service for working with settings.
    /// </summary>
    public class SettingsService : GrFactoryBase, ISettings
    {
        /// <inheritdoc/>
        protected override string FactoryName => nameof(SettingsService);

        /// <inheritdoc/>
        public virtual bool GetBoolSetting(string settingFullCode)
        {
            Setting setting = GetSetting(settingFullCode);

            if (!setting.Type.EqualsOrdinalIgnoreCase(SettingType.Bool.Code))
                throw CdiHelper.CreateException(SettingsErrorCode.InvalidSettingValue, $"The '{settingFullCode}' setting value is not a bool.");

            return bool.Parse(setting.Value);
        }

        /// <inheritdoc/>
        public virtual int GetIntSetting(string settingFullCode)
        {
            Setting setting = GetSetting(settingFullCode);

            if (!setting.Type.EqualsOrdinalIgnoreCase(SettingType.Int.Code))
                throw CdiHelper.CreateException(SettingsErrorCode.InvalidSettingValue, $"The '{settingFullCode}' setting value is not a int.");

            return int.Parse(setting.Value);
        }

        /// <inheritdoc/>
        public virtual SettingNamespace GetNamespace(string namespaceCode)
        {
            CallMethodLogging(parameter: namespaceCode);
            return ReturnNotLogging(GetFacade<SettingNamespaceFacade>().GetSettingNamespaces(new List<string>(1) { namespaceCode }).Single());
        }

        /// <inheritdoc/>
        public virtual PowerMode GetPowerModeSetting(string settingFullCode)
        {
            Setting setting = GetSetting(settingFullCode);

            if (!setting.Type.EqualsOrdinalIgnoreCase(SettingType.PowerMode.Code))
                throw CdiHelper.CreateException(SettingsErrorCode.InvalidSettingValue, $"The '{settingFullCode}' setting value is not a PowerMode.");

            return (PowerMode)Enum.Parse(typeof(PowerMode), setting.Value, true);
        }

        /// <inheritdoc/>
        public virtual Setting GetSetting(string settingFullCode)
        {
            CallMethodLogging(parameter: settingFullCode);
            return ReturnLogging(
                GetFacade<SettingsFacade>().GetSettins(new List<string>(1) { settingFullCode }).Single());
        }

        /// <inheritdoc/>
        public virtual SettingContext GetContext(bool loadNamespaces)
        {
            CallMethodLogging(loadNamespaces);
            return ReturnNotLogging(
                GetFacade<SettingContextFacade>().GetSettingContext(loadNamespaces));
        }

        /// <inheritdoc/>
        public virtual List<SettingNamespace> GetNamespaces(IEnumerable<string> namespaceCodes)
        {
            CallMethodLogging(namespaceCodes);
            return ReturnNotLogging(GetFacade<SettingNamespaceFacade>().GetSettingNamespaces(namespaceCodes));
        }

        /// <inheritdoc/>
        public virtual List<Setting> GetSettings(IEnumerable<string> settingFullCodes)
        {
            CallMethodLogging(settingFullCodes);
            return ReturnLogging(
                GetFacade<SettingsFacade>().GetSettins(settingFullCodes));
        }

        /// <inheritdoc/>
        public virtual SettingType GetSettingType(string settingTypeCode)
        {
            CallMethodLogging(parameter: settingTypeCode);
            var types = GetFacade<SettingContextFacade>().GetSettingTypes();
            return ReturnLogging(types.SingleType(settingTypeCode));
        }

        /// <inheritdoc/>
        public virtual List<SettingType> GetSettingTypes(IEnumerable<string> settingTypeCodes)
        {
            CallMethodLogging(settingTypeCodes);

            var types = GetFacade<SettingContextFacade>().GetSettingTypes();
            var resilt = new List<SettingType>(settingTypeCodes.Count());

            foreach (var code in settingTypeCodes)
                resilt.Add(types.SingleType(code));

            return ReturnLogging(resilt);
        }

        /// <inheritdoc/>
        public virtual List<SettingType> GetSettingTypes()
        {
            CallMethodLogging();

            return ReturnLogging(GetFacade<SettingContextFacade>().GetSettingTypes());
        }

        /// <inheritdoc/>
        public virtual void SetSetting<TSettingValue>(string settingFullCode, TSettingValue value)
        {
            SetSetting(settingFullCode, value, CultureInfo.InvariantCulture);
        }

        /// <inheritdoc/>
        public virtual void SetSetting<TSettingValue>(string settingFullCode, TSettingValue value, CultureInfo cultureInfo)
        {
            SetSettingsRequest request;

            switch (value)
            {
                case string sValue:
                    request = new SetSettingsRequest
                    {
                        FullCode = settingFullCode,
                        CheckSettingType = true,
                        NeedSetDefaultValue = false,
                        SettingType = SettingType.String.Code,
                        Value = sValue,
                    };
                    break;
                case int sValue:
                    request = new SetSettingsRequest
                    {
                        FullCode = settingFullCode,
                        CheckSettingType = true,
                        NeedSetDefaultValue = false,
                        SettingType = SettingType.Int.Code,
                        Value = sValue.ToString(cultureInfo),
                    };
                    break;
                case bool sValue:
                    request = new SetSettingsRequest
                    {
                        FullCode = settingFullCode,
                        CheckSettingType = true,
                        NeedSetDefaultValue = false,
                        SettingType = SettingType.Bool.Code,
                        Value = sValue.ToString(cultureInfo),
                    };
                    break;
                case PowerMode sValue:
                    request = new SetSettingsRequest
                    {
                        FullCode = settingFullCode,
                        CheckSettingType = true,
                        NeedSetDefaultValue = false,
                        SettingType = SettingType.PowerMode.Code,
                        Value = sValue.ToString(),
                    };
                    break;

                default:
                    request = new SetSettingsRequest
                    {
                        FullCode = settingFullCode,
                        Value = value.ToString(),
                    };
                    break;
            }

            SetSettings(new List<SetSettingsRequest> { request });
        }

        /// <inheritdoc/>
        public virtual void SetSettings(List<SetSettingsRequest> request)
        {
            CallMethodLogging(request);

            GetFacade<SettingsFacade>().SetSettings(request);

            NLogger.Info(() => "Set settings:\n" + string.Join("\n", request.ConvertAll(setting => $"Code <{setting.FullCode}>, Value <{setting.Value}>")));
        }

        /// <inheritdoc/>
        public virtual string GetStringSetting(string settingFullCode)
        {
            Setting setting = GetSetting(settingFullCode);

            if (!setting.Type.EqualsOrdinalIgnoreCase(SettingType.String.Code))
                throw CdiHelper.CreateException(SettingsErrorCode.InvalidSettingValue, $"The '{settingFullCode}' setting value is not a string.");

            return setting.Value;
        }

        /// <inheritdoc/>
        public virtual void SetDefaultSettings(IEnumerable<string> settingFullCodes)
        {
            CallMethodLogging(settingFullCodes);
            GetFacade<SettingsFacade>().SetSettings(settingFullCodes.Select(code => new SetSettingsRequest { FullCode = code, NeedSetDefaultValue = true }).ToList());
            NLogger.Info(() => "Set default settings:\n" + string.Join("\n", settingFullCodes));
        }

        /// <inheritdoc/>
        public void ValidateSetting(Setting setting, SettingType type)
        {
            GetFacade<SettingsFacade>().ValidateSetting(setting, type);
        }
    }
}
