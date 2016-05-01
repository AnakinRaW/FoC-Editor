using System.Threading;
using Caliburn.Micro;
using Ionic.Zip;
using ModernApplicationFramework.MVVM.Modules.OutputTool;

namespace ForcesOfCorruptionModdingTool.EditorCore.Windows.FileSystem.Compression
{
    public static class FileCompression
    {
        public static void Test(int time)
        {
            Thread.Sleep(time);
        }

        private static readonly IOutput Ouput = IoC.Get<IOutput>();

        public static void CompressDirectory(CompressSettings settings)
        {
            using (var zipFile = new ZipFile())
            {
                if (!string.IsNullOrEmpty(settings.Password))
                {
                    zipFile.Password = settings.Password;
                    zipFile.Encryption = EncryptionAlgorithm.WinZipAes256;
                }
                zipFile.AddDirectory(settings.SourcePath);
                zipFile.StatusMessageTextWriter = Ouput.Writer;
                zipFile.CompressionLevel = settings.CompressionLevel;             
                zipFile.Save(settings.TargetPath);
            }
        }
    }
}
