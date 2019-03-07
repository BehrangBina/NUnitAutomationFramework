using System;
using System.IO;
using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using NUnitAutomationFramework.Framework.IO;

namespace NUnitAutomationFramework.DevTests
{
    [TestFixture]
    [AllureNUnit]
    [AllureDisplayIgnored]
    public class FileAndFolderTests
    {
        [Test(Description = "Testing Files and folders")]
        [AllureTag("Regression")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureIssue("ISSUE-Reading_From_Folders")]
        [AllureTms("TMS-Reading_From_Folders")]
        [AllureOwner("Behrang Bina")]
        [AllureSuite("Framework")]
        [AllureSubSuite("FileAndFolders")]
        public void TestGetSolutionDirectory()
        {
             var uat =   FileAndFolder.GetSolutionDirectory();
             Console.WriteLine("Solution Dir: "+uat);
             Assert.IsTrue(Directory.Exists(uat));
        }
    }
}
