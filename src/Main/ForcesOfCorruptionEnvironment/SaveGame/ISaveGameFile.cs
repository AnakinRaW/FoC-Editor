using System.Collections.Generic;
using AlomoEngine.Core.Interfaces.Engine;

namespace ForcesOfCorruptionEnvironment.SaveGame
{
    public interface ISaveGameFile : IBinaryFile
    {
        List<UnitRef> GetAllUnitRefs();
    }
}
