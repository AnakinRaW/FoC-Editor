using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using AlomoEngine.Core.Classes;
using AlomoEngine.Core.Interfaces.Engine;
using AlomoEngine.FilesystemWatcher;

namespace AlomoEngine.Managers
{
    public abstract class FileMananger : EngineFilesystemWatcher, IFileManager
    {
        public abstract string[] SupportedExtensions { get; }

        protected FileMananger(FilesystemWatcherSettings settings) : base(settings)
        {
            Files = new ObservableCollection<IEngineFile>();
        }
        public abstract void Initialize();

        public ObservableCollection<IEngineFile> Files { get; }

        public ICollection<string> GetAllFilePaths()
        {
            var ps = GetPaths();
            var allFiles = new List<string>();
            foreach (var path in ps)
                allFiles.AddRange(SupportedExtensions.SelectMany(e => Directory.GetFiles(path, e)));
            return allFiles.Distinct().ToList();
        }
    }
}
