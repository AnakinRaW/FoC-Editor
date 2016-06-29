using System.IO;

namespace ForcesOfCorruptionEnvironment.SaveGame
{
    public sealed class SteamSaveGame : SaveGame
    {
        public override string Name => Path.GetFileName(FilePath);

        public override void Open(string path)
        {
            if (Path.GetExtension(path) != ".PetroglyphFoCSave")
                throw new FileFormatException();
            base.Open(path);
        }
    }
}
