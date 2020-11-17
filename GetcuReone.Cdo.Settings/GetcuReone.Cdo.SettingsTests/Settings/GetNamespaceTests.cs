using GetcuReone.Cdm.Errors;
using GetcuReone.Cdo.Settings;
using GetcuReone.Cdo.Settings.TestCommon;
using GetcuReone.Cdo.SettingsTests.Env;
using GetcuReone.GetcuTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GetcuReone.Cdo.SettingsTests.Settings
{
    [TestClass]
    public sealed class GetNamespaceTests : SettingsTestBase
    {
        [TestMethod]
        [TestCategory(GetcuReoneTC.Unit)]
        [Description("Get namespace.")]
        [Timeout(Timeouts.Second.One)]
        public void GetNamespaceTestCase()
        {
            string code = "ExampleNamespaceCode";
            string name = "Example namspace name";
            string description = "Description namespace";

            GivenCreateAdapter()
                .When("Get types", adapter => 
                    adapter.GetNamespace(code))
                .Then("Check error", nSpace =>
                {
                    Assert.IsNotNull(nSpace, "Namespace cannot be null.");
                    Assert.AreEqual(name, nSpace.Name, "Expected another name.");
                    Assert.AreEqual(description, nSpace.Description, "Expected another description.");
                    Assert.AreEqual(code, nSpace.FullCode, "Expected another FullCode.");
                    Assert.IsNotNull(nSpace.Namespaces, "Sub namespaces cannot be null.");
                    Assert.AreEqual(1, nSpace.Namespaces.Count);
                })
                .Run();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Unit)]
        [Description("Get sub namespase.")]
        [Timeout(Timeouts.Second.One)]
        public void GetSubNamespaceTestCase()
        {
            string code = "ExampleNamespaceCode.SubExampleNamespaceCode";
            string name = "Sub example namspace name";
            string description = "Description sub namespace";

            GivenCreateAdapter()
                .When("Get types", adapter =>
                    adapter.GetNamespace(code))
                .Then("Check error", nSpace =>
                {
                    Assert.IsNotNull(nSpace, "Namespace cannot be null.");
                    Assert.AreEqual(name, nSpace.Name, "Expected another name.");
                    Assert.AreEqual(description, nSpace.Description, "Expected another description.");
                    Assert.AreEqual(code, nSpace.FullCode, "Expected another FullCode.");
                    Assert.IsNotNull(nSpace.Namespaces, "Sub namespaces cannot be null.");
                    Assert.AreEqual(0, nSpace.Namespaces.Count);
                })
                .Run();
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(GetcuReoneTC.Unit)]
        [Description("Get sub namespase.")]
        [Timeout(Timeouts.Second.One)]
        public void GetNamespaceNotContainTestCase()
        {
            string namespaceCode = "blablablaCode";
            string expectedMessage = $"Namespace '{namespaceCode}' not found.";

            GivenCreateAdapter()
                .When("Get types", adapter =>
                    ExpectedException<GetcuReoneException>(() => adapter.GetNamespace(namespaceCode)))
                .ThenAssertError(SettingsErrorCode.SettingNamespaceNotFound, expectedMessage)
                .Run();
        }
    }
}
