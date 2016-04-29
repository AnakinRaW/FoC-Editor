using ForcesOfCorruptionModdingTool.EditorCore.Mod;
using Ionic.Zlib;

namespace ForcesOfCorruptionModdingTool.Modules.ExportManager
{
    public class ExportSettings
    {
        public IMod Mod { get; set; }

        public string ExportPath { get; set; }

        public CompressionLevel CompressionLevel { get; set; }

        public string Password { get; set; }

        public bool CreateCredits { get; set; }

        public string Readme { get; set; }
    }
}
