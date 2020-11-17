using GetcuReone.Cdm.Configuration.Settings;
using GetcuReone.Cdo.SettingsTests.Env;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GetcuReone.Cdo.SettingsTests.Settings
{
    [TestClass]
    public sealed class GetSettingTypeTests : SettingsTestBase
    {
        [TestMethod]
        [TestCategory(GetcuReoneTC.Unit)]
        [Description("Get type setting by code.")]
        [Timeout(Timeouts.Second.One)]
        public void GetSettingTypeByCodeTestCase()
        {
            const string code = "Integer";
            const string pattern = @"(^\d+$)|(^-\d+$)";

            GivenCreateAdapter()
                .When("Get type by code.", adapter => 
                    adapter.GetSettingType(code))
                .ThenIsNotNull()
                .AndAreEqual(type => type.FormatValue, FormatValue.Text,
                    errorMessage: "Expected another format.")
                .AndAreEqual(type => type.TextPattern, pattern,
                    errorMessage: "Expected another pattern.")
                .Run();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Unit)]
        [Description("Get type setting by code.")]
        [Timeout(Timeouts.Second.One)]
        public void GetDefaultSettingTypeByCodeTestCase()
        {
            string code = SettingType.Int.Code;

            GivenCreateAdapter()
                .When("Get type by code.", adapter =>
                    adapter.GetSettingType(code))
                .ThenIsNotNull()
                .AndAreEqual(SettingType.Int)
                .Run();
        }
    }
}
