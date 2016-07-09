using System.Collections.Generic;
using AlomoEngine.Core.Interfaces;
using AlomoEngine.Core.Interfaces.Engine;

namespace ForcesOfCorruptionEnvironment.SaveGame
{
    public interface ISaveGameFile : IEngineFile
    {
        List<UnitRef> GetAllUnitRefs();
    }
}
