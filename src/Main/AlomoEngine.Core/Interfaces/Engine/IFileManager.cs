using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AlomoEngine.Core.Interfaces.Engine
{
    public interface IFileManager : IEngineManager, IEngineFilesystemWatcher
    {
        ObservableCollection<IEngineFile> Files { get; }

        ICollection<string> GetAllFilePaths();
    }
}
