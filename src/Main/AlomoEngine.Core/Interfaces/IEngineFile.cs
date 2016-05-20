﻿using System;

namespace AlomoEngine.Core.Interfaces
{
    public interface IEngineFile : IDisposable
    {
        string FilePath { get; }

        string Name { get; }

        byte[] ByteArray { get; set; }

        void Open(string path);

        void Save(string path);
    }
}