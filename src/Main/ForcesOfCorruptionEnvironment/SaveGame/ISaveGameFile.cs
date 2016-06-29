using System.Collections.Generic;
using AlomoEngine.Core.Interfaces;

namespace ForcesOfCorruptionEnvironment.SaveGame
{
    public interface ISaveGameFile : IEngineFile
    {
        List<UnitRef> GetAllUnitRefs();
    }
}
