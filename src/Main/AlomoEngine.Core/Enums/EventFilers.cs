using System;

namespace AlomoEngine.Core.Enums
{
    [Flags]
    public enum EventFilers
    {
        Changed = 1,
        Created = 2,
        Deleted = 4,
        Renamed = 8
    }
}