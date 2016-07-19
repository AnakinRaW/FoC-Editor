using System;
using System.Collections.Generic;
using System.IO;
using AlomoEngine.Core.Classes;
using AlomoEngine.Core.Enums;

namespace AlomoEngine.Core.Interfaces.Engine
{
    public interface IEngineFilesystemWatcher : IDisposable
    {
        event FileSystemEventHandler Changed;
        event FileSystemEventHandler Created;
        event FileSystemEventHandler Deleted;
        event RenamedEventHandler Renamed;

        void Add(FilesystemWatcherSettings settings);

        bool Exists(FileSystemWatcher instance);

        FileSystemWatcher GetFileSystemWatcher(string path);

        ICollection<string> GetPaths();

        ICollection<FileSystemWatcher> GetWatchers();

        bool PathExists(string path);

        void RegisterEvent(FileSystemWatcher watcher, EventFilers filter);

        void Remove(string path);

        void Remove(FileSystemWatcher instance);

        void UnregisterEvent(FileSystemWatcher watcher, EventFilers filter);
    }
}