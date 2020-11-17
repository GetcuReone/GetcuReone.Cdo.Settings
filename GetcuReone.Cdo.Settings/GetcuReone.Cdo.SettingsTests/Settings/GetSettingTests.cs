using GetcuReone.Cdm.Errors;
using GetcuReone.Cdo.Settings;
using GetcuReone.Cdo.Settings.TestCommon;
using GetcuReone.Cdo.SettingsTests.Env;
using GetcuReone.GetcuTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GetcuReone.Cdo.SettingsTests.Settings
{
    [TestClass]
    public sealed class GetSettingTests : SettingsTestBase
    {
        [TestMethod]
        [TestCategory(GetcuReoneTC.Unit)]
        [Description("Get setting SettingInt.")]
        [Timeout(Timeouts.Second.One)]
        public void GetSettingIntCodeTestCase()
        {
            const string settingCode = "ExampleNamespaceCode.SubExampleNamespaceCode.SettingInt";
            const string expectedValue = "1";
            const string expecdetName = "Setting int";
            const string expecdedDescription = "Description SettingInt";

            GivenCreateAdapter()
                .When("Get setting.", adapter =>
                    adapter.GetSetting(settingCode))
                .Then("Check setting.", setting =>
                {
                    Assert.IsNotNull(setting);
                    Assert.AreEqual(expectedValue, setting.Value);
                    Assert.AreEqual(expecdetName, setting.Name);
                    Assert.AreEqual(settingCode, setting.FullCode);
                    Assert.AreEqual(expecdedDescription, setting.Description);
                })
                .Run();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Unit)]
        [Description("Get setting SettingBool.")]
        [Timeout(Timeouts.Second.One)]
        public void GetSettingBoolCodeTestCase()
        {
            const string settingCode = "ExampleNamespaceCode.SettingBool";
            const string expectedValue = "True";
            const string expecdetName = "Setting bool";
            const string expecdedDescription = "Description SettingBool";

            GivenCreateAdapter()
                .When("Get setting.", adapter
                    => adapter.GetSetting(settingCode))
                .Then("Check setting.", setting =>
                {
                    Assert.IsNotNull(setting);
                    Assert.AreEqual(expectedValue, setting.Value);
                    Assert.AreEqual(expecdetName, setting.Name);
                    Assert.AreEqual(settingCode, setting.FullCode);
                    Assert.AreEqual(expecdedDescription, setting.Description);
                })
                .Run();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(GetcuReoneTC.Unit)]
        [Description("Not found setting.")]
        [Timeout(Timeouts.Second.One)]
        public void NotFoundSettingTestCase()
        {
            const string settingCode = "ExampleNamespaceCode.NGhhrddrs";
            string expectedMessage = $"Setting '{settingCode}' not found.";

            GivenCreateAdapter()
                .When("Get setting.", adapter =>
                    ExpectedException<GetcuReoneException>(() => adapter.GetSetting(settingCode)))
                .ThenAssertError(SettingsErrorCode.SettingNotFound, expectedMessage)
                .Run();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Unit)]
        [Description("Get int setting.")]
        [Timeout(Timeouts.Second.One)]
        public void GetIntSettingTestCase()
        {
            const string settingCode = "ExampleNamespaceCode.SubExampleNamespaceCode.SettingInt";
            const int expectedValue = 1;

            GivenCreateAdapter()
                .When("Get setting.", adapter =>
                    adapter.GetIntSetting(settingCode))
                .Then("Check setting.", result =>
                {
                    Assert.AreEqual(expectedValue, result);
                })
                .Run();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(GetcuReoneTC.Unit)]
        [Description("Get int setting.")]
        [Timeout(Timeouts.Second.One)]
        public void GetIntSettingWithInvalidTypeTestCase()
        {
            const string settingCode = "ExampleNamespaceCode.SettingBool";
            string expectedMessage = $"The '{settingCode}' setting value is not a int.";

            GivenCreateAdapter()
                .When("Get setting.", adapter =>
                    ExpectedException<GetcuReoneException>(() => adapter.GetIntSetting(settingCode)))
                .ThenAssertError(SettingsErrorCode.InvalidSettingValue, expectedMessage)
                .Run();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Unit)]
        [Description("Get bool setting.")]
        [Timeout(Timeouts.Second.One)]
        public void GetBoolSettingTestCase()
        {
            const string settingCode = "ExampleNamespaceCode.SettingBool";
            const bool expectedValue = true;

            GivenCreateAdapter()
                .When("Get setting.", adapter =>
                    adapter.GetBoolSetting(settingCode))
                .Then("Check setting.", result =>
                {
                    Assert.AreEqual(expectedValue, result);
                })
                .Run();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(GetcuReoneTC.Unit)]
        [Description("Get bool setting.")]
        //[Timeout(Timeouts.Second.One)]
        public void GetBoolSettingWithInvalidTypeTestCase()
        {
            const string settingCode = "ExampleNamespaceCode.SubExampleNamespaceCode.SettingInt";
            string expectedMessage = $"The '{settingCode}' setting value is not a bool.";

            GivenCreateAdapter()
                .When("Get setting.", adapter =>
                    ExpectedException<GetcuReoneException>(() => adapter.GetBoolSetting(settingCode)))
                .ThenAssertError(SettingsErrorCode.InvalidSettingValue, expectedMessage)
                .Run();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Unit)]
        [Description("Get bool setting.")]
        [Timeout(Timeouts.Second.One)]
        public void GetStringSettingTestCase()
        {
            const string settingCode = "ExampleNamespaceCode.SettingString";
            const string expectedValue = "GetcuReone";

            GivenCreateAdapter()
                .When("Get setting.", adapter =>
                    adapter.GetStringSetting(settingCode))
                .Then("Check setting.", result =>
                {
                    Assert.AreEqual(expectedValue, result);
                })
                .Run();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(GetcuReoneTC.Unit)]
        [Description("Get bool setting.")]
        [Timeout(Timeouts.Second.One)]
        public void GetStringSettingWithInvalidTypeTestCase()
        {
            string settingCode = "ExampleNamespaceCode.SubExampleNamespaceCode.SettingInt";
            string expectedMessage = $"The '{settingCode}' setting value is not a string.";

            GivenCreateAdapter()
                .When("Get setting.", adapter =>
                    ExpectedException<GetcuReoneException>(() => adapter.GetStringSetting(settingCode)))
                .ThenAssertError(SettingsErrorCode.InvalidSettingValue, expectedMessage)
                .Run();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Unit)]
        [Description("Get bool setting from tow file.")]
        [Timeout(Timeouts.Second.One)]
        public void GetBoolSettingTowFileTestCase()
        {
            string settingCode = "NamespaceFromTowFile.SettingBool";
            bool expectedValue = true;

            GivenCreateAdapter()
                .When("Get setting.", adapter =>
                    adapter.GetBoolSetting(settingCode))
                .Then("Check setting.", result =>
                {
                    Assert.AreEqual(expectedValue, result);
                })
                .Run();
        }
    }
}
