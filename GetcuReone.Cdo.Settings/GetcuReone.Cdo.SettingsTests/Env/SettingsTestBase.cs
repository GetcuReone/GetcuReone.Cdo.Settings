using GetcuReone.Cdm.Configuration.Settings;
using GetcuReone.GetcuTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Configuration;
using NSpase = GetcuReone.Cdm.Configuration.Settings.SettingNamespace;

namespace GetcuReone.Cdo.SettingsTests.Env
{
    [TestClass]
    public abstract class SettingsTestBase : GetcuReoneTestBase
    {
        [TestInitialize]
        public virtual void Initialize()
        {
            ImportConfigFromFile("config.xml");
        }

        protected void RemoveSettingInConfig(string settingKey)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove(settingKey);
            config.Save();
        }

        private List<Setting> GetAllSettings(List<NSpase> settingNamespaces)
        {
            List<Setting> settings = new List<Setting>();

            foreach (var nSpace in settingNamespaces)
            {
                settings.AddRange(nSpace.Settings);

                if (nSpace.Namespaces != null && nSpace.Namespaces.Count > 0)
                    settings.AddRange(GetAllSettings(nSpace.Namespaces));
            }

            return settings;
        }
    }
}
