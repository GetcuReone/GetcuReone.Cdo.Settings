using GetcuReone.Cdi;
using GetcuReone.Cdm.Configuration.Settings;
using GetcuReone.Cdm.Configuration.Settings.Enums;
using GetcuReone.Cdo.Settings.Entities;
using System.Collections.Generic;
using System.Globalization;

namespace GetcuReone.Cdo.Settings
{
    /// <summary>
    /// Adapter for <see cref="ISettings"/>.
    /// </summary>
    public class SettingsAdapter : BaseGrAdapterProxy<ISettings>
    {
        /// <inheritdoc/>
        protected override string AdapterName => nameof(SettingsAdapter);

        /// <summary>
        /// Constructor.
        /// </summary>
        public SettingsAdapter() : base(() => new SettingsService()) { }

        /// <summary>
        /// Get setting types by codes.
        /// </summary>
        /// <param name="settingTypeCodes">setting type codes.</param>
        /// <returns></returns>
        public List<SettingType> GetSettingTypes(IEnumerable<string> settingTypeCodes)
        {
            return CreateProxy().GetSettingTypes(settingTypeCodes);
        }

        /// <summary>
        /// Get setting type by code.
        /// </summary>
        /// <param name="settingTypeCode"></param>
        /// <returns></returns>
        public SettingType GetSettingType(string settingTypeCode)
        {
            return CreateProxy().GetSettingType(settingTypeCode);
        }

        /// <summary>
        /// Get all settig types.
        /// </summary>
        /// <returns></returns>
        public List<SettingType> GetSettingTypes()
        {
            return CreateProxy().GetSettingTypes();
        }

        /// <summary>
        /// Get setting context.
        /// </summary>
        /// <param name="loadNamespaces"></param>
        /// <returns>Setting context.</returns>
        public SettingContext GetContext(bool loadNamespaces)
        {
            return CreateProxy().GetContext(loadNamespaces);
        }

        /// <summary>
        /// Get array <see cref="SettingNamespace"/> by <paramref name="namespaceCodes"/>.
        /// </summary>
        /// <param name="namespaceCodes"></param>
        /// <returns>array <see cref="SettingNamespace"/>.</returns>
        public List<SettingNamespace> GetNamespaces(IEnumerable<string> namespaceCodes)
        {
            return CreateProxy().GetNamespaces(namespaceCodes);
        }

        /// <summary>
        /// Get <see cref="SettingNamespace"/> by code.
        /// </summary>
        /// <param name="namespaceCode"></param>
        /// <returns><see cref="SettingNamespace"/></returns>
        public SettingNamespace GetNamespace(string namespaceCode)
        {
            return CreateProxy().GetNamespace(namespaceCode);
        }

        /// <summary>
        /// Get settings by codes.
        /// </summary>
        /// <param name="settingFullCodes">Full customization codes.</param>
        /// <returns>Settings</returns>
        public List<Setting> GetSettings(IEnumerable<string> settingFullCodes)
        {
            return CreateProxy().GetSettings(settingFullCodes);
        }

        /// <summary>
        /// Get setting by code.
        /// </summary>
        /// <param name="settingFullCode">Full customization code.</param>
        /// <returns>Settings</returns>
        /// <remarks>With dot separated namespace names in code.</remarks>
        public Setting GetSetting(string settingFullCode)
        {
            return CreateProxy().GetSetting(settingFullCode);
        }

        /// <summary>
        /// Get setting with <see cref="int"/> value.
        /// </summary>
        /// <param name="settingFullCode">Full customization code.</param>
        /// <returns></returns>
        public int GetIntSetting(string settingFullCode)
        {
            return CreateProxy().GetIntSetting(settingFullCode);
        }

        /// <summary>
        /// Get setting with <see cref="bool"/> value.
        /// </summary>
        /// <param name="settingFullCode">Full customization code.</param>
        /// <returns></returns>
        public bool GetBoolSetting(string settingFullCode)
        {
            return CreateProxy().GetBoolSetting(settingFullCode);
        }

        /// <summary>
        /// Get setting with <see cref="PowerMode"/> value.
        /// </summary>
        /// <param name="settingFullCode">Full customization code.</param>
        /// <returns></returns>
        public PowerMode GetPowerModeSetting(string settingFullCode)
        {
            return CreateProxy().GetPowerModeSetting(settingFullCode);
        }

        /// <summary>
        /// Get setting with <see cref="string"/> value.
        /// </summary>
        /// <param name="settingFullCode">Full customization code.</param>
        /// <returns></returns>
        public string GetStringSetting(string settingFullCode)
        {
            return CreateProxy().GetStringSetting(settingFullCode);
        }

        /// <summary>
        /// Set settings.
        /// </summary>
        /// <param name="request"></param>
        public void SetSettings(List<SetSettingsRequest> request)
        {
            CreateProxy().SetSettings(request);
        }

        /// <summary>
        /// Set setting.
        /// </summary>
        /// <param name="settingFullCode">Full customization code.</param>
        /// <param name="value">New setting value.</param>
        public void SetSetting<TSettingValue>(string settingFullCode, TSettingValue value)
        {
            CreateProxy().SetSetting(settingFullCode, value);
        }

        /// <summary>
        /// Set setting.
        /// </summary>
        /// <param name="settingFullCode">Full customization code.</param>
        /// <param name="value">New setting value.</param>
        /// <param name="cultureInfo"></param>
        public void SetSetting<TSettingValue>(string settingFullCode, TSettingValue value, CultureInfo cultureInfo)
        {
            CreateProxy().SetSetting(settingFullCode, value, cultureInfo);
        }

        /// <summary>
        /// Set default settings.
        /// </summary>
        /// <param name="settingFullCodes"></param>
        public void SetDefaultSettings(IEnumerable<string> settingFullCodes)
        {
            CreateProxy().SetDefaultSettings(settingFullCodes);
        }

        /// <summary>
        /// Setting validation.
        /// </summary>
        /// <param name="setting">Setting.</param>
        /// <param name="type">Setting type.</param>
        public void ValidateSetting(Setting setting, SettingType type)
        {
            CreateProxy().ValidateSetting(setting, type);
        }
    }
}
