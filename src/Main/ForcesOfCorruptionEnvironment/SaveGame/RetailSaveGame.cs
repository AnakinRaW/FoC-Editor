using System;
using System.IO;
using System.Text;

namespace ForcesOfCorruptionEnvironment.SaveGame
{
    public sealed class RetailSaveGame : SaveGame
    {
        public override string Name
        {
            get
            {
                if (ByteArray == null)
                    throw new NullReferenceException();
                var reader = new BinaryReader(File.Open(FilePath, FileMode.Open));
                reader.BaseStream.Position = 35;
                var stringLength = reader.ReadBytes(2);

                if (BitConverter.IsLittleEndian)
                    Array.Reverse(stringLength);

                var length = BitConverter.ToInt16(stringLength, 0)-2;

                reader.BaseStream.Position = 37;
                var name = Encoding.Unicode.GetString(reader.ReadBytes(length));
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
