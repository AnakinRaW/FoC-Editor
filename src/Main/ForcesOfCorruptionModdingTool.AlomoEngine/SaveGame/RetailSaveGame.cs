using System;
using System.IO;
using System.Text;

namespace ForcesOfCorruptionModdingTool.AlomoEngine.SaveGame
{
    public class RetailSaveGame : SaveGame
    {
        public override string Name
        {
            get
            {
                if (ByteArray == null)
                    throw new NullReferenceException();
                var reader = new BinaryReader(File.Open(FilePath, FileMode.Open));
                reader.BaseStream.Position = 37;
                var name = Encoding.Unicode.GetString(reader.ReadBytes(500));
                reader.Close();
                return name;
            }
        }

        public override void Open(string path)
        {
            if (Path.GetExtension(path) != ".sav")
                throw new FileFormatException();
            base.Open(path);
        }
    }
}
