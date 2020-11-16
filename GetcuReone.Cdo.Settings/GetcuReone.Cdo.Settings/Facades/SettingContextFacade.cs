using GetcuReone.Cdi;
using GetcuReone.Cdm.Configuration.Settings;
using GetcuReone.Cdo.File;
using GetcuReone.Cdo.Helpers;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace GetcuReone.Cdo.Settings.Facades
{
    /// <summary>
    /// Facade for work with <see cref="SettingContext"/>.
    /// </summary>
    internal class SettingContextFacade : GrFacadeBase
    {
        /// <inheritdoc/>
        protected override string FacadeName => nameof(SettingContextFacade);

        private string GetValueFromConfig(string keyConfig)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var appSettings = config.AppSettings.Settings;

            if (!appSettings.AllKeys.Contains(keyConfig))
                throw CdiHelper.CreateException(
                    SettingsErrorCode.InvalidConfig,
                    $"The configuration file does not contain application setting '{keyConfig}'.");

            string value = appSettings[keyConfig].Value;
            NLogger.Debug(() => $"Get setting config from confug Key <{keyConfig}>, Value <{value}>");
            return value;
        }

        public List<SettingType> GetSettingTypes()
        {
            string settingTypeFilePath = GetValueFromConfig(ConfigKeys.SettingsTypesFile);
            using (FileStream fileStream = GetAdapter<FileAdapter>().OpenRead(settingTypeFilePath))
            {
                var types = fileStream.DeserializeFromXml<List<SettingType>>();

                for (int i = types.Count - 1; i >= 0; i--)
                {
                    var type = types[i];

                    if (type.Code.EqualsOrdinalIgnoreCase(SettingType.Int.Code))
                    {
                        types.Remove(type);
                        types.Insert(i, SettingType.Int);
                    }
                    else if (type.Code.EqualsOrdinalIgnoreCase(SettingType.Bool.Code))
                    {
                        types.Remove(type);
                        types.Insert(i, SettingType.Bool);
                    }
                    else if (type.Code.EqualsOrdinalIgnoreCase(SettingType.String.Code))
                    {
                        types.Remove(type);
                        types.Insert(i, SettingType.String);
                    }
                    else if (type.Code.EqualsOrdinalIgnoreCase(SettingType.PowerMode.Code))
                    {
                        types.Remove(type);
                        types.Insert(i, SettingType.PowerMode);
                    }
                }

                return types;
            }
        }
    }
}
