namespace GetcuReone.Cdo.Settings.Entities
{
    /// <summary>
    /// Request for <see cref="ISettings.SetSettings(System.Collections.Generic.List{SetSettingsRequest})"/>.
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

        /// <summary>
        /// True - set default value.
        /// </summary>
        internal bool NeedSetDefaultValue { get; set; }

        /// <summary>
        /// True - check setting type
        /// </summary>
        internal bool CheckSettingType { get; set; }

        /// <summary>
        /// Settings type.
        /// </summary>
        internal string SettingType { get; set; }
    }
}
