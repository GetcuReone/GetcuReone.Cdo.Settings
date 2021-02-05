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
