using GetcuReone.Cdi;
using GetcuReone.Cdo.Configuration;
using GetcuReone.Cdo.Folder;

namespace GetcuReone.Cdo.Settings.Adapters
{
    internal sealed class SettingsFolderAdapter : FolderAdapterBase
    {
        protected override string AdapterName => nameof(SettingsFolderAdapter);

        public SettingsFolderAdapter() : base(GetPathFolder())
        {
        }

        private static string GetPathFolder()
        {
            var config = GrConfigManager.Current.Sections[GrConfigKeys.Settings.Name].Configs[GrConfigKeys.Settings.SettingsFolder];
            if (config == null)
                throw CdiHelper.CreateException(SettingsErrorCode.InvalidConfig, $"The GetcuReone.config does not contain config '{GrConfigKeys.Settings.SettingsFolder}'.");

            return config.Value;
        }
    }
}
