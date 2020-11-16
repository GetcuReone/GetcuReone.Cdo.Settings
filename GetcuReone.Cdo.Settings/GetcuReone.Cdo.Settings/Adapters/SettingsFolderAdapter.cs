using GetcuReone.Cdo.Folder;

namespace GetcuReone.Cdo.Settings.Adapters
{
    internal sealed class SettingsFolderAdapter : FolderAdapterBase
    {
        internal static string folderPath;

        protected override string AdapterName => nameof(SettingsFolderAdapter);

        public SettingsFolderAdapter() : base(folderPath)
        {
        }
    }
}
