using System.Collections.Generic;
using System.IO;
using ForcesOfCorruptionModdingTool.AlomoEngine.Core;

namespace ForcesOfCorruptionModdingTool.AlomoEngine.SaveGame
{
    public abstract class SaveGame : ISaveGameFile
    {
        public static IEnumerable<ISaveGameFile> GetAllFilesFromDirectory(string path)
        {
            if (!Directory.Exists(path))
                throw new DirectoryNotFoundException();
            foreach (var file in new DirectoryInfo(path).GetFiles())
            {
                if (file.Extension.Equals(".sav"))
                {
                    var sg = new RetailSaveGame();
                    sg.Open(file.FullName);
                    yield return sg;
                }
                else
                {
                    var sg = new SteamSaveGame();
                    sg.Open(file.FullName);
                    yield return sg;
                }          
            }
        }

        public void Dispose()
        {
            ByteArray = null;
        }

        public string FilePath { get; protected set; }
        public abstract string Name { get; }
        public byte[] ByteArray { get; set; }

        public virtual void Open(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException(nameof(path));
            FilePath = path;
            ByteArray = File.ReadAllBytes(path);
        }

        public virtual void Save(string path)
        {
            var writer = new BinaryWriter(File.OpenWrite(path));
            writer.Write(ByteArray);
            writer.Close();
        }

        public List<UnitRef> GetAllUnitRefs()
        {
            var uRefs = new List<UnitRef>();
            var l = 0;
            var pos = 0;

            while (pos != -1)
            {
                pos = SearchAlgorithm.SearchKmp(ByteArray, UnitRef.SearchPattern, l);
                if (pos == -1)
                    continue;
                l = pos + 17;
                uRefs.Add(new UnitRef(l, new[] { ByteArray[l], ByteArray[l + 1], ByteArray[l + 2] },
                    new[] { ByteArray[l + 6], ByteArray[l + 7], ByteArray[l + 8], ByteArray[l + 9] }));
            }
            return uRefs;
        }
    }
}
