namespace GetcuReone.Cdo.Settings.Entities
{
    /// <summary>
    /// Request for <see cref="ISettings.SetSettings(List{SetSettingsRequest})"/>.
    /// </summary>
    public sealed class SetSettingsRequest
    {
        /// <summary>
        /// Setting full code.
        /// </summary>
        public string FullCode { get; set; }

        /// <summary>
        /// Setting value.
        /// </summary>
        public string Value { get; set; }

        internal bool NeedSetDefaultValue { get; set; }

        internal bool CheckSettingType { get; set; }

        internal string SettingType { get; set; }
    }
}
