using GetcuReone.Cdm.Configuration.Settings;
using GetcuReone.Cdm.Configuration.Settings.Enums;
using GetcuReone.Cdo.Settings.Entities;
using System.Collections.Generic;

namespace GetcuReone.Cdo.Settings
{
    /// <summary>
    /// Interface for working with settings.
    /// </summary>
    public interface ISettings
    {
        /// <summary>
        /// Get setting context.
        /// </summary>
        /// <param name="includeNamespaces"></param>
        /// <returns>Setting context.</returns>
        SettingContext GetSettingContext(bool includeNamespaces);

        /// <summary>
        /// Get array <see cref="SettingNamespace"/> by <paramref name="namespaceCodes"/>.
        /// </summary>
        /// <param name="namespaceCodes"></param>
        /// <returns>array <see cref="SettingNamespace"/>.</returns>
        List<SettingNamespace> GetSettingNamespaces(IEnumerable<string> namespaceCodes);

        /// <summary>
        /// Get <see cref="SettingNamespace"/> by code.
        /// </summary>
        /// <param name="namespaceCode"></param>
        /// <returns><see cref="SettingNamespace"/></returns>
        SettingNamespace GetNamespace(string namespaceCode);

        /// <summary>
        /// Get settings by codes.
        /// </summary>
        /// <param name="settingFullCodes">Full customization codes.</param>
        /// <returns>Settings</returns>
        List<Setting> GetSettings(IEnumerable<string> settingFullCodes);

        /// <summary>
        /// Get setting by code.
        /// </summary>
        /// <param name="settingFullCode">Full customization code.</param>
        /// <returns>Settings</returns>
        /// <remarks>With dot separated namespace names in code.</remarks>
        Setting GetSetting(string settingFullCode);

        /// <summary>
        /// Get setting with <see cref="int"/> value.
        /// </summary>
        /// <param name="settingFullCode">Full customization code.</param>
        /// <returns></returns>
        int GetIntSetting(string settingFullCode);

        /// <summary>
        /// Get setting with <see cref="bool"/> value.
        /// </summary>
        /// <param name="settingFullCode">Full customization code.</param>
        /// <returns></returns>
        bool GetBoolSetting(string settingFullCode);

        /// <summary>
        /// Get setting with <see cref="PowerMode"/> value.
        /// </summary>
        /// <param name="settingFullCode">Full customization code.</param>
        /// <returns></returns>
        PowerMode GetPowerModeSetting(string settingFullCode);

        /// <summary>
        /// Set settings.
        /// </summary>
        /// <param name="request"></param>
        void SetSettings(List<SetSettingsRequest> request);

        /// <summary>
        /// Set setting.
        /// </summary>
        /// <param name="settingFullCode"></param>
        /// <param name="value"></param>
        void SetSetting<TSettingValue>(string settingFullCode, TSettingValue value);
    }
}
