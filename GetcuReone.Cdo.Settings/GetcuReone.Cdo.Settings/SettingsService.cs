using GetcuReone.Cdi;
using GetcuReone.Cdm.Configuration.Settings;
using GetcuReone.Cdm.Configuration.Settings.Enums;
using GetcuReone.Cdo.Settings.Entities;
using GetcuReone.Cdo.Settings.Facades;
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

        public virtual bool GetBoolSetting(string settingFullCode)
        {
            throw new System.NotImplementedException();
        }

        public virtual int GetIntSetting(string settingFullCode)
        {
            throw new System.NotImplementedException();
        }

        public virtual SettingNamespace GetNamespace(string namespaceCode)
        {
            throw new System.NotImplementedException();
        }

        public virtual PowerMode GetPowerModeSetting(string settingFullCode)
        {
            throw new System.NotImplementedException();
        }

        public virtual Setting GetSetting(string settingFullCode)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc/>
        public virtual SettingContext GetSettingContext(bool loadNamespaces)
        {
            CallMethodLogging(loadNamespaces);
            return ReturnNotLogging(
                GetFacade<SettingContextFacade>().GetSettingContext(loadNamespaces));
        }

        /// <inheritdoc/>
        public virtual List<SettingNamespace> GetSettingNamespaces(IEnumerable<string> namespaceCodes)
        {
            CallMethodLogging(namespaceCodes);
            return ReturnNotLogging(GetFacade<SettingNamespaceFacade>().GetSettingNamespaces(namespaceCodes));
        }

        public virtual List<Setting> GetSettings(IEnumerable<string> settingFullCodes)
        {
            throw new System.NotImplementedException();
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

        public virtual void SetSetting<TSettingValue>(string settingFullCode, TSettingValue value)
        {
            throw new System.NotImplementedException();
        }

        public virtual void SetSetting<TSettingValue>(string settingFullCode, TSettingValue value, CultureInfo cultureInfo)
        {
            throw new System.NotImplementedException();
        }

        public void SetSettings(List<SetSettingsRequest> request)
        {
            throw new System.NotImplementedException();
        }
    }
}
