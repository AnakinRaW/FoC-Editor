using System.IO;
using AlomoEngine.Core.Enums;

namespace AlomoEngine.Core.Classes
{
    public sealed class FilesystemWatcherSettings
    {
        public EventFilers EventFilers { get; set; }

        public string Filter { get; set; }

        public bool IncludeSubdirectories { get; set; } = true;

        public NotifyFilters NotifyFilters { get; set; }
        public string Path { get; set; }
    }
}