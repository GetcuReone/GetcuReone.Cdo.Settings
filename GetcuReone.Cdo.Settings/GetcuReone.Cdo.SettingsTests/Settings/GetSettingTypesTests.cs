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
    public sealed class GetSettingTypesTests : SettingsTestBase
    {
        [TestMethod]
        [TestCategory(GetcuReoneTC.Unit)]
        [Description("Get types setting.")]
        [Timeout(Timeouts.Second.One)]
        public void GetTypesTestCase()
        {
            GivenCreateAdapter()
                .When("Get types.",adapter => 
                    adapter.GetSettingTypes())
                .ThenAreEqual(types => types.Count, 5,
                    errorMessage: "There must be 4 types.")
                .Run();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(GetcuReoneTC.Unit)]
        [Description("Get types setting.")]
        [Timeout(Timeouts.Second.One)]
        public void GetTypesWithoutSettingInConfigTestCase()
        {
            string expectedMessage = $"The configuration file does not contain application setting '{ConfigKeys.SettingsTypesFile}'.";

            GivenCreateAdapter()
                .And("Remove setting from config", _ => 
                    RemoveSettingInConfig(ConfigKeys.SettingsTypesFile))
                .When("Get types", adapter =>
                    ExpectedException<GetcuReoneException>(() => adapter.GetSettingTypes()))
                .ThenAssertError(SettingsErrorCode.InvalidConfig, expectedMessage)
                .Run();
        }
    }
}
