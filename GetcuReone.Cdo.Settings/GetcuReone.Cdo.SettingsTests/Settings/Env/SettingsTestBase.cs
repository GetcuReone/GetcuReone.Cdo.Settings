using GetcuReone.Cdm.Configuration.Settings;
using GetcuReone.Cdo.Settings;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Configuration;

namespace GetcuReone.Cdo.SettingsTests.Env
{
    [TestClass]
    public abstract class SettingsTestBase : GetcuReoneTestBase
    {
        [TestInitialize]
        public virtual void Initialize()
        {
            ImportConfigFromFile(@"Settings\Env\config.xml");
        }

        protected void RemoveSettingInConfig(string settingKey)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove(settingKey);
            config.Save();
        }

        private List<Setting> GetAllSettings(List<SettingNamespace> settingNamespaces)
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

        protected void SetDefaultSettings()
        {
            var context = GetAdapter<SettingsAdapter>().GetContext(true);

            var settings = GetAllSettings(context.Namespaces);

            foreach (var setting in settings)
                setting.Value = setting.DefaultValue;

            GetAdapter<SettingsAdapter>().SetDefaultSettings(settings.ConvertAll(s => s.FullCode));
        }

        protected GivenBlock<object, SettingsAdapter> GivenCreateAdapter()
        {
            return Given("Create SettingsAdapter.", () => GetAdapter<SettingsAdapter>());
        }
    }
}
