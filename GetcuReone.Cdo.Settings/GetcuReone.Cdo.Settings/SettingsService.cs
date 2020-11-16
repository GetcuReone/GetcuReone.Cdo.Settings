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

        /// <inheritdoc/>
        public virtual SettingNamespace GetNamespace(string namespaceCode)
        {
            CallMethodLogging(parameter: namespaceCode);
            return ReturnNotLogging(GetFacade<SettingNamespaceFacade>().GetSettingNamespaces(new List<string>(1) { namespaceCode }).Single());
        }

        public virtual PowerMode GetPowerModeSetting(string settingFullCode)
        {
            throw new System.NotImplementedException();
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
