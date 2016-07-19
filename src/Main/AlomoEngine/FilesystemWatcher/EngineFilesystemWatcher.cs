using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using AlomoEngine.Core.Classes;
using AlomoEngine.Core.Enums;
using AlomoEngine.Core.Interfaces.Engine;

namespace AlomoEngine.FilesystemWatcher
{
    [SuppressMessage("ReSharper", "DelegateSubtraction")]
    public class EngineFilesystemWatcher : IEngineFilesystemWatcher
    {
        private readonly List<FileSystemWatcher> _watcherList;

        private FileSystemEventHandler _onChangedHandler;
        private FileSystemEventHandler _onCreatedHandler;
        private FileSystemEventHandler _onDeletedHandler;
        private RenamedEventHandler _onRenamedHandler;

        public EngineFilesystemWatcher()
        {
            _watcherList = new List<FileSystemWatcher>();
        }

        public EngineFilesystemWatcher(FilesystemWatcherSettings settings) : this()
        {
            if (settings == null)
                return;
            Add(settings);
        }

        public event FileSystemEventHandler Changed
        {
            add { _onChangedHandler += value; }
            remove { _onChangedHandler -= value; }
        }

        public event FileSystemEventHandler Created
        {
            add { _onCreatedHandler += value; }
            remove { _onCreatedHandler -= value; }
        }

        public event FileSystemEventHandler Deleted
        {
            add { _onDeletedHandler += value; }
            remove { _onDeletedHandler -= value; }
        }

        public event RenamedEventHandler Renamed
        {
            add { _onRenamedHandler += value; }
            remove { _onRenamedHandler -= value; }
        }

        public void Dispose()
        {
            foreach (var watcher in _watcherList)
                watcher.Dispose();
            _onChangedHandler = null;
            _onCreatedHandler = null;
            _onDeletedHandler = null;
            _onRenamedHandler = null;
        }

        public static FileSystemWatcher CreateFileSystemWatcher(FilesystemWatcherSettings settings)
        {
            return new FileSystemWatcher
            {
                Path = settings.Path,
                NotifyFilter = settings.NotifyFilters,
                Filter = settings.Filter,
                EnableRaisingEvents = true,
                IncludeSubdirectories = settings.IncludeSubdirectories
            };
        }

        public void Add(FilesystemWatcherSettings settings)
        {
            if (settings.Path == null)
                throw new NoNullAllowedException(nameof(settings.Path));
            if (!Directory.Exists(settings.Path))
                throw new DirectoryNotFoundException(settings.Path);
            if (settings.NotifyFilters == 0)
                throw new ArgumentException(nameof(settings.NotifyFilters));
            if (string.IsNullOrEmpty(settings.Filter))
                throw new NoNullAllowedException(nameof(settings.Filter));
            if (settings.EventFilers == 0)
                throw new ArgumentException(nameof(settings.EventFilers));

            var watcher = CreateFileSystemWatcher(settings);
            RegisterEvent(watcher, settings.EventFilers);

            _watcherList.Add(watcher);
        }

        public bool Exists(FileSystemWatcher instance)
        {
            if (instance == null)
                throw new ArgumentNullException(nameof(instance));
            return _watcherList.Any(i => i == instance);
        }

        public FileSystemWatcher GetFileSystemWatcher(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException(nameof(path));
            if (!PathExists(path))
                throw new FilesystemWathcerNotFoundException();
            return _watcherList.First(w => w.Path == path);
        }

        public ICollection<string> GetPaths()
        {
            var paths = new List<string>();
            foreach (var watcher in _watcherList)
            {
                paths.Add(watcher.Path);
                if (!watcher.IncludeSubdirectories)
                    continue;
                var folders = Directory.GetDirectories(watcher.Path, "*", SearchOption.AllDirectories);
                paths.AddRange(folders);
            }
            return paths;
        }

        public ICollection<FileSystemWatcher> GetWatchers()
        {
            return new List<FileSystemWatcher>(_watcherList);
        }

        public bool PathExists(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException(nameof(path));
            return _watcherList.Any(w => w.Path == path);
        }

        public void RegisterEvent(FileSystemWatcher watcher, EventFilers filter)
        {
            if (filter.HasFlag(EventFilers.Changed))
                watcher.Changed += Watcher_Changed;
            if (filter.HasFlag(EventFilers.Created))
                watcher.Created += Watcher_Created;
            if (filter.HasFlag(EventFilers.Deleted))
                watcher.Deleted += Watcher_Deleted;
            if (filter.HasFlag(EventFilers.Renamed))
                watcher.Renamed += Watcher_Renamed;
        }

        public void Remove(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException(nameof(path));
            var watcher = GetFileSystemWatcher(path);
            if (watcher == null)
                throw new FilesystemWathcerNotFoundException();
            Remove(watcher);
        }

        public void Remove(FileSystemWatcher instance)
        {
            if (!Exists(instance))
                throw new FilesystemWathcerNotFoundException();

            UnregisterEvent(instance,
                EventFilers.Changed | EventFilers.Created | EventFilers.Deleted | EventFilers.Renamed);
            instance.Dispose();
            _watcherList.Remove(instance);
        }

        public void UnregisterEvent(FileSystemWatcher watcher, EventFilers filter)
        {
            if (filter.HasFlag(EventFilers.Changed))
                watcher.Changed -= Watcher_Changed;
            if (filter.HasFlag(EventFilers.Created))
                watcher.Created -= Watcher_Created;
            if (filter.HasFlag(EventFilers.Deleted))
                watcher.Deleted -= Watcher_Deleted;
            if (filter.HasFlag(EventFilers.Renamed))
                watcher.Renamed -= Watcher_Renamed;
        }


        protected virtual void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            _onChangedHandler?.Invoke(this, e);
        }

        protected virtual void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            _onCreatedHandler?.Invoke(this, e);
        }

        protected virtual void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            _onDeletedHandler?.Invoke(this, e);
        }

        protected virtual void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            _onRenamedHandler?.Invoke(this, e);
        }
    }
}