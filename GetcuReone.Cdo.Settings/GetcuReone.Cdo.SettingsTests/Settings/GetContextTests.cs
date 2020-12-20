using GetcuReone.Cdm.Errors;
using GetcuReone.Cdo.Settings;
using GetcuReone.Cdo.Settings.TestCommon;
using GetcuReone.Cdo.SettingsTests.Env;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GetcuReone.Cdo.SettingsTests.Settings
{
    [TestClass]
    public sealed class GetContextTests : SettingsTestBase
    {
        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(GetcuReoneTC.Unit)]
        [Description("Get setting context without GetcuReone_Settings_SettingsFolder in config.")]
        [Timeout(Timeouts.Second.Two)]
        public void GetContextWithout_GetcuReone_Settings_SettingsFolder_TestCase()
        {
            string expectedMessage = $"The configuration file does not contain application setting '{ConfigKeys.SettingsFolder}'.";

            GivenCreateAdapter()
                .And("Remove setting from config",
                    _ => RemoveSettingInConfig(ConfigKeys.SettingsFolder))
                .When("Get context.", adapter 
                    => ExpectedException<GetcuReoneException>(() => adapter.GetContext(true)))
                .ThenAssertError(SettingsErrorCode.InvalidConfig, expectedMessage)
                .Run();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(GetcuReoneTC.Unit)]
        [Description("Get setting context without GetcuReone_Settings_SettingsFolder in config.")]
        [Timeout(Timeouts.Second.One)]
        public void GetContextWithout_GetcuReone_Settings_TemplateSettingFile_TestCase()
        {
            string expectedMessage = $"The configuration file does not contain application setting '{ConfigKeys.TemplateSettingFile}'.";

            GivenCreateAdapter()
                .And("Remove setting from config",
                    _ => RemoveSettingInConfig(ConfigKeys.TemplateSettingFile))
                .When("Get context.", adapter
                    => ExpectedException<GetcuReoneException>(() => adapter.GetContext(true)))
                .ThenAssertError(SettingsErrorCode.InvalidConfig, expectedMessage)
                .Run();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Unit)]
        [Description("Get setting context without namespaces.")]
        [Timeout(Timeouts.Second.One)]
        public void GetContextWithoutNamespacesTestCase()
        {
            const string name = "Setting";
            const string description = "Settings for application";

            GivenCreateAdapter()
                .When("Get context.", adapter
                    => adapter.GetContext(false))
                .ThenIsNotNull()
                .AndAreEqual(context => context.Name, name,
                    errorMessage: "context cannot be null.")
                .AndAreEqual(context => context.Description, description,
                    errorMessage: "Expected another description.")
                .AndAreEqual(context => context.Namespaces, null,
                    errorMessage: "Must be null.")
                .Run();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Unit)]
        [Description("Get setting context.")]
        [Timeout(Timeouts.Second.One)]
        public void GetContextTestCase()
        {
            string name = "Setting";
            string description = "Settings for application";

            GivenCreateAdapter()
                .When("Get context.", adapter
                    => adapter.GetContext(true))
                .ThenIsNotNull()
                .AndAreEqual(context => context.Name, name,
                    errorMessage: "context cannot be null.")
                .AndAreEqual(context => context.Description, description,
                    errorMessage: "Expected another description.")
                .AndAreNotEqual(context => context.Namespaces, null,
                    errorMessage: "Namespaces cannot be null.")
                .AndAreEqual(context => context.Namespaces.Count, 2)
                .Run();
        }
    }
}
