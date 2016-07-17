using System;

namespace AlomoEngine.Core.Interfaces.Engine
{
    public interface IEngineFile : IDisposable
    {
        string FilePath { get; }

        string Name { get; }

        void Open(string path);

        void Save(string path);
    }
}
