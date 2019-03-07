using System.IO;
using log4net;

namespace NUnitAutomationFramework.Framework.IO
{
    public class FileAndFolder
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(FileAndFolder));

        /// <summary>
        /// Copy file from source to destination and returns the destination file location
        /// </summary>
        /// <param name="fileName">File Name</param>
        /// <param name="source">Source Directory</param>
        /// <param name="destination">Destination Directory</param>
        /// <param name="destFileName">Destination FileName</param>
        /// <returns></returns>
        public string CopyFile(string fileName, string source, string destination, string destFileName)
        {
            // Use Path class to manipulate file and directory paths.
            string sourceFile = Path.Combine(source, fileName);
            Log.Info($"Source File: {sourceFile}");
            string destFile = Path.Combine(destination, destFileName);
            Log.Info($"Destination File: {destFile}");
            if (!File.Exists(sourceFile))
            {
                Log.Error($"Source file cound not found in {sourceFile}");
                throw new FileNotFoundException($"Source file cound not found in {sourceFile}");
            }
            // To copy a file to another location and 
            // overwrite the destination file if it already exists.
            File.Copy(sourceFile, destFile, true);
            Log.Info("File copied from source to destination");
            return destFile;
        }
        public static string GetSolutionDirectory()
        {
            var baseDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            Log.Info("Base Director: "+ baseDirectory);
            var solutionFullPath = Path.GetFullPath(Path.Combine(baseDirectory, "..\\..\\"));
            Log.Info("Solution Full Path: " + solutionFullPath);
            return solutionFullPath;
        }
    }
}
