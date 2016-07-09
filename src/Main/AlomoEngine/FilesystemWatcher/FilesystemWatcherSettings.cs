using System.IO;

namespace AlomoEngine.FilesystemWatcher
{
    public class FilesystemWatcherSettings
    {
        public EventFilers EventFilers { get; set; }

        public string Filter { get; set; }

        public bool IncludeSubdirectories { get; set; } = true;

        public NotifyFilters NotifyFilters { get; set; }
        public string Path { get; set; }
    }
}