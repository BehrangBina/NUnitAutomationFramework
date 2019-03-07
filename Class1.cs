using System;
using System.IO;
using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace NUnitAutomationFramework
{
    [TestFixture]
    [AllureNUnit]
    [AllureDisplayIgnored]
    public class Class1
    {
        public Class1()
        {
            var dir = System.AppContext.BaseDirectory;
            Environment.SetEnvironmentVariable(
                AllureConstants.ALLURE_CONFIG_ENV_VARIABLE,
                Path.Combine(dir, AllureConstants.CONFIG_FILENAME));

            var config = AllureLifecycle.Instance.JsonConfiguration;

        }
        [Test]
        public void TestAdd()
        {
            Assert.True(4+4>0,"4+4>0");
            Assert.AreEqual(2+2,4,"4");
        }
         
        [Test(Description = "XXX")]
        [AllureTag("Regression")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureIssue("ISSUE-1")]
        [AllureTms("TMS-12")]
        [AllureOwner("User")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("NoAssert")]
        public void TestSubtract()
        {
            Assert.True(4 - 4 == 0, "4-4==0");
            Assert.AreEqual(2 -2, 0, "0");
        }
        [Test]
        [AllureTag("NUnit", "Debug")]
        [AllureIssue("GitHub#1", "https://github.com/unickq/allure-nunit")]
        [AllureFeature("Core")]
        public void EvenTest([Range(0, 5)] int value)
        {
            Assert.IsTrue(value % 2 == 0, $"Oh no :( {value} % 2 = {value % 2}");
        }
    }
}
