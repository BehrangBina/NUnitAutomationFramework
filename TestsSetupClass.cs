﻿using System;
using System.IO;
using Allure.Commons;
using log4net;
using log4net.Config;
using NUnit.Framework;
using NUnitAutomationFramework.Framework.Configuration;
using NUnitAutomationFramework.Framework.IO;

namespace NUnitAutomationFramework
{
    [SetUpFixture]
    public class TestsSetupClass
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(TestsSetupClass));

        [OneTimeSetUp]
        public void GlobalSetup()
        {
            XmlConfigurator.Configure();
            var dir = AppContext.BaseDirectory;
            Environment.SetEnvironmentVariable(
                AllureConstants.ALLURE_CONFIG_ENV_VARIABLE,
                Path.Combine(dir, AllureConstants.CONFIG_FILENAME));
            Log.Info($"ALLURE_CONFIG_ENV_VARIABLE Environment Variable Set to: {dir}");
            var config = AllureLifecycle.Instance.JsonConfiguration;
            Log.Info(config);
        }

        [OneTimeTearDown]
        public void GlobalTeardown()
        {
            var exeDir =  FileAndFolder.GetExecutionDirectory();
            var allureReport = Path.GetFullPath(Path.Combine(exeDir, "..\\..\\"));
            allureReport = Path.Combine(allureReport, SolutionFolders.Reports.ToString());
            var filename = "TestResult.xml";
            var allureReportFullPath = Path.Combine(allureReport, filename);
            Assert.True(File.Exists(allureReportFullPath));
            var f = new FileAndFolder();
            var configurationReader = new ConfigurationReader();
            var uat = configurationReader.ReadFolderPathFromConfigurationFile(SolutionFolders.Reports);
            f.CopyFile(filename, allureReport, uat, filename);
            Assert.IsTrue(File.Exists(Path.Combine(uat,filename)));
            // Do logout here
        }
    }
}