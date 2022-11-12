using GetcuReone.Cdm.Errors;
using GetcuReone.Cdo.Settings;
using GetcuReone.Cdo.Settings.Entities;
using GetcuReone.Cdo.Settings.TestCommon;
using GetcuReone.Cdo.SettingsTests.Env;
using GetcuReone.GetcuTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace GetcuReone.Cdo.SettingsTests.Settings
{
    [TestClass]
    public sealed class SetSettingsTests : SettingsTestBase
    {
        [TestCleanup]
        public void Cleanup()
        {
            SetDefaultSettings();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Unit)]
        [Description("Set settings.")]
        [Timeout(Timeouts.Second.Five)]
        public void SetSettingsTestCase()
        {
            var settingCodes = new Dictionary<string, string>
            {
                { "ExampleNamespaceCode.SubExampleNamespaceCode.SettingInt", "2" },
                { "ExampleNamespaceCode.SettingBool", "true" },
            };

            GivenCreateAdapter()
                .When("Set settings.", adapter =>
                    adapter.SetSettings(settingCodes.Select(s => new SetSettingsRequest { FullCode = s.Key, Value = s.Value }).ToList()))
                .Then("Get settings", adapter =>
                    adapter.GetSettings(settingCodes.Keys))
                .And("Check result.", settings =>
                {
                    foreach (var setting in settings)
                        Assert.AreEqual(settingCodes[setting.FullCode], setting.Value.ToLower(), "Expecded another value.");
                })
                .Run();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Unit)]
        [Description("Set default settings.")]
        [Timeout(Timeouts.Second.One)]
        public void SetDefaultSettingsTestCase()
        {
            var settingCodes = new Dictionary<string, string>
            {
                { "ExampleNamespaceCode.SubExampleNamespaceCode.SettingInt", "2" },
                { "ExampleNamespaceCode.SettingBool", "true" },
            };

            GivenCreateAdapter()
                .And("Set settings.", adapter =>
                    adapter.SetSettings(settingCodes.Select(s => new SetSettingsRequest { FullCode = s.Key, Value = s.Value }).ToList()))
                .When("Set default settings", adapter =>
                    adapter.SetDefaultSettings(settingCodes.Keys.ToList()))
                .Then("Get settings", adapter =>
                    adapter.GetSettings(settingCodes.Keys))
                .And("Check result.", settings =>
                {
                    foreach (var setting in settings)
                        Assert.AreEqual(setting.DefaultValue, setting.Value.ToLower(), "Expecded another value.");
                })
                .Run();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Unit)]
        [Description("Set setting.")]
        [Timeout(Timeouts.Second.One)]
        public void SetSettingTestCase()
        {
            const string settingFullCode = "ExampleNamespaceCode.SubExampleNamespaceCode.SettingInt";
            const int expectedValue = 2;

            GivenCreateAdapter()
                .When("Set setting.", adapter =>
                    adapter.SetSetting(settingFullCode, expectedValue))
                .Then("Get setting.", adapter =>
                    adapter.GetSetting(settingFullCode))
                .And("Check setting.", setting =>
                {
                    Assert.AreEqual(expectedValue.ToString(), setting.Value);
                })
                .Run();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Unit)]
        [Description("Set int setting.")]
        [Timeout(Timeouts.Second.One)]
        public void SetIntSettingTestCase()
        {
            const string settingFullCode = "ExampleNamespaceCode.SubExampleNamespaceCode.SettingInt";
            const int expectedValue = 2;

            GivenCreateAdapter()
                .When("Set setting.", adapter =>
                    adapter.SetSetting(settingFullCode, expectedValue))
                .Then("Get setting.", adapter =>
                    adapter.GetIntSetting(settingFullCode))
                .And("Check setting.", result =>
                {
                    Assert.AreEqual(expectedValue, result);
                })
                .Run();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(GetcuReoneTC.Unit)]
        [Description("Set int setting with another type.")]
        [Timeout(Timeouts.Second.One)]
        public void SetIntSettingWithAnotherTypeTestCase()
        {
            const string settingFullCode = "ExampleNamespaceCode.SettingBool";
            const int expectedValue = 2;
            const string expectedMessage = "The setting contains an unexpected type. Expected <Int>, Actual <bool>.";

            GivenCreateAdapter()
                .When("Set setting.", adapter =>
                    ExpectedException<GetcuReoneException>(() => adapter.SetSetting(settingFullCode, expectedValue)))
                .ThenAssertError(SettingsErrorCode.InvalidSettingType, expectedMessage)
                .Run();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Unit)]
        [Description("Set bool setting.")]
        [Timeout(Timeouts.Second.One)]
        public void SetBoolSettingTestCase()
        {
            const string settingFullCode = "ExampleNamespaceCode.SettingBool";
            const bool expectedValue = false;

            GivenCreateAdapter()
                .When("Set setting.", adapter =>
                    adapter.SetSetting(settingFullCode, expectedValue))
                .Then("Get setting.", adapter =>
                    adapter.GetBoolSetting(settingFullCode))
                .And("Check setting.", result =>
                {
                    Assert.AreEqual(expectedValue, result);
                });
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Unit)]
        [Description("Set bool setting.")]
        [Timeout(Timeouts.Second.One)]
        public void SetStringSettingTestCase()
        {
            string settingFullCode = "ExampleNamespaceCode.SettingString";
            string expectedValue = "Hey! hey!";

            GivenCreateAdapter()
                .When("Set setting.", adapter =>
                    adapter.SetSetting(settingFullCode, expectedValue))
                .Then("Get setting.", adapter =>
                    adapter.GetStringSetting(settingFullCode))
                .And("Check setting.", result =>
                {
                    Assert.AreEqual(expectedValue, result);
                });
        }
    }
}
