using System.Collections.Generic;
using ForcesOfCorruptionModdingTool.AlomoEngine.Interfaces;

namespace ForcesOfCorruptionModdingTool.AlomoEngine.SaveGame
{
    public interface ISaveGameFile : IEngineFile
    {
        List<UnitRef> GetAllUnitRefs();
    }
}
