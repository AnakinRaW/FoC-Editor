using System;

namespace ForcesOfCorruptionModdingTool.EditorCore.Project
{
    public interface IProject : IDisposable
    {
        string Name { get; set; }

        string FullPath { get; set; }

        void Export();

        void Save();
    }
}