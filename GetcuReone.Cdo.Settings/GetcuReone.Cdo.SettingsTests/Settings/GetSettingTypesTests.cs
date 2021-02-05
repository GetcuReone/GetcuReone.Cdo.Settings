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
    }
}
