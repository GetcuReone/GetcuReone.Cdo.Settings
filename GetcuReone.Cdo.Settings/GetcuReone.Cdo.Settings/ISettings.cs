﻿using GetcuReone.Cdm.Configuration.Settings;
using GetcuReone.Cdm.Configuration.Settings.Enums;
using GetcuReone.Cdo.Settings.Entities;
using System.Collections.Generic;
using System.Globalization;

namespace GetcuReone.Cdo.Settings
{
    /// <summary>
    /// Interface for working with settings.
    /// </summary>
    public interface ISettings
    {
        /// <summary>
        /// Get setting types by codes.
        /// </summary>
        /// <param name="settingTypeCodes">setting type codes.</param>
        /// <returns></returns>
        List<SettingType> GetSettingTypes(IEnumerable<string> settingTypeCodes);

        /// <summary>
        /// Get setting type by code.
        /// </summary>
        /// <param name="settingTypeCode"></param>
        /// <returns></returns>
        SettingType GetSettingType(string settingTypeCode);

        /// <summary>
        /// Get all settig types.
        /// </summary>
        /// <returns></returns>
        List<SettingType> GetSettingTypes();

        /// <summary>
        /// Get setting context.
        /// </summary>
        /// <param name="loadNamespaces"></param>
        /// <returns>Setting context.</returns>
        SettingContext GetContext(bool loadNamespaces);

        /// <summary>
        /// Get array <see cref="SettingNamespace"/> by <paramref name="namespaceCodes"/>.
        /// </summary>
        /// <param name="namespaceCodes"></param>
        /// <returns>array <see cref="SettingNamespace"/>.</returns>
        List<SettingNamespace> GetNamespaces(IEnumerable<string> namespaceCodes);

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
        /// Get setting with <see cref="string"/> value.
        /// </summary>
        /// <param name="settingFullCode">Full customization code.</param>
        /// <returns></returns>
        string GetStringSetting(string settingFullCode);

        /// <summary>
        /// Set settings.
        /// </summary>
        /// <param name="request"></param>
        void SetSettings(List<SetSettingsRequest> request);

        /// <summary>
        /// Set setting.
        /// </summary>
        /// <param name="settingFullCode">Full customization code.</param>
        /// <param name="value">New setting value.</param>
        void SetSetting<TSettingValue>(string settingFullCode, TSettingValue value);

        /// <summary>
        /// Set setting.
        /// </summary>
        /// <param name="settingFullCode">Full customization code.</param>
        /// <param name="value">New setting value.</param>
        /// <param name="cultureInfo"></param>
        void SetSetting<TSettingValue>(string settingFullCode, TSettingValue value, CultureInfo cultureInfo);

        /// <summary>
        /// Set default settings.
        /// </summary>
        /// <param name="settingFullCodes"></param>
        void SetDefaultSettings(IEnumerable<string> settingFullCodes);

        /// <summary>
        /// Setting validation.
        /// </summary>
        /// <param name="setting">Setting.</param>
        /// <param name="type">Setting type.</param>
        void ValidateSetting(Setting setting, SettingType type);
    }
}
