using System;
using System.IO;
using ForcesOfCorruptionModdingTool.EditorCore.Annotations;

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


        //http://stackoverflow.com/questions/5617320/given-full-path-check-if-path-is-subdirectory-of-some-other-path-or-otherwise
        public static bool PathIsInDirectory(string fullPath, string path)
        {
            string normalizedPath = Path.GetFullPath(path.Replace('/', '\\')
            .WithEnding("\\"));

            string normalizedBaseDirPath = Path.GetFullPath(fullPath.Replace('/', '\\')
                .WithEnding("\\"));

            return normalizedPath.StartsWith(normalizedBaseDirPath, StringComparison.OrdinalIgnoreCase);
        }

        private static string WithEnding([CanBeNull] this string str, string ending)
        {
            if (str == null)
                return ending;

            var result = str;

            // Right() is 1-indexed, so include these cases
            // * Append no characters
            // * Append up to N characters, where N is ending length
            for (var i = 0; i <= ending.Length; i++)
            {
                var tmp = result + ending.Right(i);
                if (tmp.EndsWith(ending))
                    return tmp;
            }

            return result;
        }

        private static string Right([NotNull] this string value, int length)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length), length, "Length is less than zero");
            return length < value.Length ? value.Substring(value.Length - length) : value;
        }
    }
}
