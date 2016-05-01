using System;
using System.Collections.Generic;

namespace ForcesOfCorruptionModdingTool.AlomoEngine.SaveGame
{
    public abstract class SaveGame : ISaveGameFile
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public string FilePath { get; }
        public string Name { get; }
        public byte[] ByteArray { get; set; }
        public abstract void Open();

        public abstract void Save();

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
