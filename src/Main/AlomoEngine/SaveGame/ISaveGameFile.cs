using System.Collections.Generic;
using AlomoEngine.Core.Interfaces;

namespace AlomoEngine.SaveGame
{
    public interface ISaveGameFile : IEngineFile
    {
        List<UnitRef> GetAllUnitRefs();
    }
}
