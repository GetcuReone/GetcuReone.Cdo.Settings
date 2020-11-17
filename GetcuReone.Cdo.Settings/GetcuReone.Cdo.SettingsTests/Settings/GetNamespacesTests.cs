using GetcuReone.Cdi;
using GetcuReone.Cdo.SettingsTests.Env;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.GwtTestFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace GetcuReone.Cdo.SettingsTests.Settings
{
    [TestClass]
    public sealed class GetNamespacesTests : SettingsTestBase
    {
        [TestMethod]
        [TestCategory(GetcuReoneTC.Unit)]
        [Description("Get namespaces.")]
        [Timeout(Timeouts.Second.One)]
        public void GetNamespacesTestCase()
        {
            const string namespaceCode1 = "ExampleNamespaceCode";
            const string namespaceName1 = "Example namspace name";
            const string namespaceDescription1 = "Description namespace";
            const int countSettings1 = 2;

            const string namespaceCode2 = "ExampleNamespaceCode.SubExampleNamespaceCode";
            const string namespaceName2 = "Sub example namspace name";
            const string namespaceDescription2 = "Description sub namespace";
            const int countSettings2 = 1;


            const string namespaceCode3 = "NamespaceFromTowFile";
            const string namespaceName3 = "Example namspace name";
            const string namespaceDescription3 = "Description namespace";
            const int countSettings3 = 1;

            GivenCreateAdapter()
                .When("Get namespaces.", adapter =>
                    adapter.GetNamespaces(new List<string> { namespaceCode1, namespaceCode2, namespaceCode3 }))
                .ThenIsNotNull()
                .AndAreEqual(namespaces => namespaces.Count, 3)
                .AndIsTrue(namespaces => namespaces.Any(n => n.FullCode.EqualsOrdinalIgnoreCase(namespaceCode1)))
                .And("Check namespaces 1.", namespaces =>
                {
                    var nSpace = namespaces.First(n => n.FullCode.EqualsOrdinalIgnoreCase(namespaceCode1));
                    Assert.AreEqual(namespaceCode1, nSpace.FullCode, "Expected another full code.");
                    Assert.AreEqual(namespaceCode1.Split('.').Last(), nSpace.Code, "Expected another code.");
                    Assert.AreEqual(namespaceName1, nSpace.Name, "Expected another name.");
                    Assert.AreEqual(namespaceDescription1, nSpace.Description, "Expected another description.");
                    Assert.IsNotNull(nSpace.Settings, "Settings cannot be null.");
                    Assert.AreEqual(countSettings1, nSpace.Settings.Count, "Expected another description.");
                })
                .AndIsTrue(namespaces => namespaces.Any(n => n.FullCode.EqualsOrdinalIgnoreCase(namespaceCode2)))
                .And("Check namespaces 2.", namespaces =>
                {
                    var nSpace = namespaces.First(n => n.FullCode.EqualsOrdinalIgnoreCase(namespaceCode2));
                    Assert.AreEqual(namespaceCode2, nSpace.FullCode, "Expected another full code.");
                    Assert.AreEqual(namespaceCode2.Split('.').Last(), nSpace.Code, "Expected another code.");
                    Assert.AreEqual(namespaceName2, nSpace.Name, "Expected another name.");
                    Assert.AreEqual(namespaceDescription2, nSpace.Description, "Expected another description.");
                    Assert.IsNotNull(nSpace.Settings, "Settings cannot be null.");
                    Assert.AreEqual(countSettings2, nSpace.Settings.Count, "Expected another description.");
                })
                .AndIsTrue(namespaces => namespaces.Any(n => n.FullCode.EqualsOrdinalIgnoreCase(namespaceCode3)))
                .And("Check namespaces 3.", namespaces =>
                {
                    var nSpace = namespaces.First(n => n.FullCode.EqualsOrdinalIgnoreCase(namespaceCode3));
                    Assert.AreEqual(namespaceCode3, nSpace.FullCode, "Expected another full code.");
                    Assert.AreEqual(namespaceCode3.Split('.').Last(), nSpace.Code, "Expected another code.");
                    Assert.AreEqual(namespaceName3, nSpace.Name, "Expected another name.");
                    Assert.AreEqual(namespaceDescription3, nSpace.Description, "Expected another description.");
                    Assert.IsNotNull(nSpace.Settings, "Settings cannot be null.");
                    Assert.AreEqual(countSettings3, nSpace.Settings.Count, "Expected another description.");
                })
                .Run();
        }
    }
}
