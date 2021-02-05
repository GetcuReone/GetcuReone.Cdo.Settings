using GetcuReone.Cdi;
using GetcuReone.Cdm.Configuration.Settings;
using GetcuReone.Cdo.Configuration;
using GetcuReone.Cdo.File;
using GetcuReone.Cdo.Helpers;
using GetcuReone.Cdo.Settings.Adapters;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace GetcuReone.Cdo.Settings.Facades
{
    /// <summary>
    /// Facade for work with <see cref="SettingContext"/>.
    /// </summary>
    internal sealed class SettingContextFacade : GrFacadeBase
    {
        /// <inheritdoc/>
        protected override string FacadeName => nameof(SettingContextFacade);

        public List<SettingType> GetSettingTypes()
        {
            var settingTypeConfig = GrConfigManager.Current.Settings[GrConfigKeys.Settings.SettingTypesFile];
            List<SettingType> result = null;

            if (settingTypeConfig != null)
            {
                using (FileStream fileStream = GetAdapter<FileAdapter>().OpenRead(settingTypeConfig.Value))
                    result = fileStream.DeserializeFromXml<List<SettingType>>();

                for (int i = result.Count - 1; i >= 0; i--)
                {
                    var type = result[i];

                    if (type.Code.EqualsOrdinalIgnoreCase(SettingType.Int.Code))
                    {
                        result.Remove(type);
                        result.Insert(i, SettingType.Int);
                    }
                    else if (type.Code.EqualsOrdinalIgnoreCase(SettingType.Bool.Code))
                    {
                        result.Remove(type);
                        result.Insert(i, SettingType.Bool);
                    }
                    else if (type.Code.EqualsOrdinalIgnoreCase(SettingType.String.Code))
                    {
                        result.Remove(type);
                        result.Insert(i, SettingType.String);
                    }
                    else if (type.Code.EqualsOrdinalIgnoreCase(SettingType.PowerMode.Code))
                    {
                        result.Remove(type);
                        result.Insert(i, SettingType.PowerMode);
                    }
                }

                if (!result.Contains(SettingType.Int))
                    result.Add(SettingType.Int);
                if (!result.Contains(SettingType.Bool))
                    result.Add(SettingType.Bool);
                if (!result.Contains(SettingType.String))
                    result.Add(SettingType.String);
                if (!result.Contains(SettingType.PowerMode))
                    result.Add(SettingType.PowerMode);
            }
            else
                result = new List<SettingType>
                {
                    SettingType.Int,
                    SettingType.Bool,
                    SettingType.String,
                    SettingType.PowerMode,
                };

            return result;
        }

        public List<SettingType> GetDefaultSettingTypes()
        {
            return new List<SettingType>
            {
                SettingType.String,
                SettingType.Int,
                SettingType.Bool,
                SettingType.PowerMode,
            };
        }

        public IEnumerable<KeyValuePair<string, SettingContext>> LoadSettingContext(bool blockFiles = false)
        {
            var templateFileConfig = GrConfigManager.Current.Settings[GrConfigKeys.Settings.TemplateSettingFile];
            if (templateFileConfig == null)
                throw CdiHelper.CreateException(SettingsErrorCode.InvalidConfig, $"The GetcuReone.config does not contain config '{GrConfigKeys.Settings.TemplateSettingFile}'.");

            var lockerFacade = GetFacade<LockerFacade>();
            var fileAdapter = GetAdapter<FileAdapter>();

            var files = GetAdapter<SettingsFolderAdapter>().GetFiles(templateFileConfig.Value);

            foreach (var file in files)
            {
                SettingContext context = null;

                lockerFacade.WaitUnblock(file);
                if (blockFiles)
                    lockerFacade.Block(file);

                lock (lockerFacade.GetLocker(file))
                {
                    try
                    {
                        using (var fileStream = fileAdapter.OpenRead(file))
                            context = fileStream.DeserializeFromXml<SettingContext>();
                    }
                    catch
                    {
                        lockerFacade.Unblock(file);
                        throw;
                    }
                }

                context.Namespaces.FillFullCodes(null);
                yield return new KeyValuePair<string, SettingContext>(file, context);
            }
        }

        public SettingContext GetSettingContext(bool loadNamespace = false)
        {
            SettingContext result = null;
            foreach (var pair in LoadSettingContext())
            {
                if (result == null)
                    result = pair.Value;
                else
                    result.Namespaces.AddRange(pair.Value.Namespaces);

                if (!loadNamespace)
                {
                    result.Namespaces = null;
                    break;
                }
            }

            return result;
        }
    }
}
