
using Ionic.Zlib;

namespace ForcesOfCorruptionModdingTool.EditorCore.Windows.FileSystem.Compression
{
    public class CompressSettings
    {
        public CompressSettings(string sourcePath, string targetPath, CompressionLevel compressionLevel, string password)
        {
            SourcePath = sourcePath;
            TargetPath = targetPath;
            CompressionLevel = compressionLevel;
            Password = password;
        }

        public string SourcePath { get; }

        public string TargetPath { get;}

        public CompressionLevel CompressionLevel { get;}

        public string Password { get; }

    }
}
