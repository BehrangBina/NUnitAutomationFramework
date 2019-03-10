using System;
using System.IO;
using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using NUnitAutomationFramework.Framework.IO;
using NUnitAutomationFramework.Framework.Spreadsheet;

namespace NUnitAutomationFramework.DevTests
{
    [TestFixture]
    [AllureNUnit]
    [AllureDisplayIgnored]
    [Parallelizable]
    public class TestSpreadsheetUtility
    {
        [Test(Description = "")]
        [AllureTag("Framework Implementation")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureIssue("ISSUE-Spreadsheeet")]
        [AllureTms("TMS-Spreadsheet")]
        [AllureOwner("Behrang Bina")]
        [AllureSuite("Framework")]
        [AllureSubSuite("SpreadsheetUtility")]
        public void PomReading()
        {
            var excel = new SpreadsheetUtility();
            var exePath = FileAndFolder.GetProjectPath();

            var fileName = "DevLocators.xlsx";
            var filePath = Path.Combine(exePath,"DevTests", SolutionFolders.Resources.ToString());
            Assert.IsTrue(File.Exists(Path.Combine(filePath,fileName)));
            // copy file 
            var dest = Path.Combine(
                FileAndFolder.GetExecutionDirectory(),
                SolutionFolders.Resources.ToString(),
                SolutionFolders.Resources.ToString(),
                "HomePageLocator"
                );
            if (!Directory.Exists(dest)) Directory.CreateDirectory(dest);
            FileAndFolder.CopyFile(fileName, filePath, fileName, dest);

            var destFile = Path.Combine(dest, fileName);
            Assert.IsTrue(File.Exists(destFile));
            var allObjects = excel.GetExcelFileObjects(destFile);

            var rows = allObjects.GetLength(0);
            var columns = allObjects.GetLength(1);
            for (var  r = 1; r < rows;r++)
            {
                var pageObject = new PageObject
                {
                    Name = allObjects.GetValue(r, 0).ToString(),
                    By = allObjects.GetValue(r, 1).ToString(),
                    Query = allObjects.GetValue(r, 2).ToString(),
                };
                Console.WriteLine(pageObject);
            }
            

        }
    }
}
