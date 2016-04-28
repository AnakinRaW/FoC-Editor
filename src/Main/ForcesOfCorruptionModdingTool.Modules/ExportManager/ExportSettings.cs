using Ionic.Zlib;

namespace ForcesOfCorruptionModdingTool.Modules.ExportManager
{
    public class ExportSettings
    {
        public string SourceLocation { get; set; }

        public string ExportPath { get; set; }

        public CompressionLevel CompressionMode { get; set; }

        public string Password { get; set; }

        public bool CreateCredits { get; set; }

        public string Readme { get; set; }
    }
}
