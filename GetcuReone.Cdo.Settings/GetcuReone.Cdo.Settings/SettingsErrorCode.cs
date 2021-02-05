namespace GetcuReone.Cdo.Settings
{
    /// <summary>
    /// Error codes.
    /// </summary>
    public static class SettingsErrorCode
    {
        /// <summary>
        /// Invalid config.
        /// </summary>
        public static string InvalidConfig => "InvalidConfig";

        /// <summary>
        /// <see cref="Cdm.Configuration.Settings.SettingType"/> not found.
        /// </summary>
        public static string SettingTypeNotFaound => "SettingTypeNotFaound";

        /// <summary>
        /// <see cref="Cdm.Configuration.Settings.SettingNamespace"/> not found.
        /// </summary>
        public static string SettingNamespaceNotFound => "SettingNamespaceNotFound";

        /// <summary>
        /// <see cref="Cdm.Configuration.Settings.Setting"/> not found.
        /// </summary>
        public static string SettingNotFound => "SettingNotFound";

        /// <summary>
        /// Invalid setting value.
        /// </summary>
        public static string InvalidSettingValue => "InvalidSettingValue";

        /// <summary>
        /// Invalid setting type.
        /// </summary>
        public static string InvalidSettingType => "InvalidSettingType";
    }
}
