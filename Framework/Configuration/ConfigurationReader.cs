﻿using System.IO;
using log4net;
using NUnitAutomationFramework.Framework.IO;

namespace NUnitAutomationFramework.Framework.Configuration
{
    class ConfigurationReader
    {
        private readonly string _solutionDir;
        private static readonly ILog Log = LogManager.GetLogger(typeof(ConfigurationReader));

        public ConfigurationReader()
        {
            _solutionDir = FileAndFolder.GetSolutionDirectory();
            Log.Info(this.GetType() + " Dir= " + _solutionDir);
        }
        public string ReadFolderPathFromConfigurationFile(SolutionFolders solutionFolder)
        {
            string folderPath = string.Empty;
            switch (solutionFolder)
            {
                case (SolutionFolders.Logs):
                    folderPath = Path.Combine(_solutionDir,
                        SolutionFolders.Reports.ToString(),
                        solutionFolder.ToString());
                    Log.Info($"Log folder full path selected: {folderPath}");
                    break;
                case (SolutionFolders.Reports):
                    folderPath = Path.Combine(_solutionDir,
                        SolutionFolders.Reports.ToString(),
                        solutionFolder.ToString());
                    Log.Info($"Reports folder full path selected: {folderPath}");
                    break;
                case (SolutionFolders.Resources):
                    folderPath = Path.Combine(_solutionDir,
                        SolutionFolders.Resources.ToString(),
                        solutionFolder.ToString());
                    Log.Info($"Resources folder full path selected: {folderPath}");
                    break;
            }
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
                Log.Info("Directory Has Been Created "+ folderPath);
            }
            return folderPath;
        }
    }

}
