using System.IO;

namespace ForcesOfCorruptionModdingTool.EditorCore.Windows.FileSystem
{
    //http://stackoverflow.com/questions/2947300/copy-a-directory-to-a-different-drive
    public static class FileSystemHelper
    {
        public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            // Check if the target directory exists, if not, create it.
            if (Directory.Exists(target.FullName) == false)
                Directory.CreateDirectory(target.FullName);

            // Copy each file into it’s new directory.
            foreach (var fi in source.GetFiles())
                fi.CopyTo(Path.Combine(target.ToString(), fi.Name), true);

            // Copy each subdirectory using recursion.
            foreach (var diSourceSubDir in source.GetDirectories())
            {
                var nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }

        /// <summary>
        /// Copies the content from target folder to destination
        /// </summary>
        /// <param name="sourceFolder">source folder</param>
        /// <param name="destFolder">target folder</param>
        public static void CopyFolder(string sourceFolder, string destFolder)
        {
            if (!Directory.Exists(destFolder))
                Directory.CreateDirectory(destFolder);
            var files = Directory.GetFiles(sourceFolder);
            foreach (var file in files)
            {
                var name = Path.GetFileName(file);
                if (name == null)
                    continue;
                var dest = Path.Combine(destFolder, name);
                File.Copy(file, dest);
            }
            var folders = Directory.GetDirectories(sourceFolder);
            foreach (var folder in folders)
            {
                var name = Path.GetFileName(folder);
                if (name == null)
                    continue;
                var dest = Path.Combine(destFolder, name);
                CopyFolder(folder, dest);
            }
        }
    }
}
