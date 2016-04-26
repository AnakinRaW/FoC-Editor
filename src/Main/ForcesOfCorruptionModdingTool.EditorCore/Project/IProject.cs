using System;

namespace ForcesOfCorruptionModdingTool.EditorCore.Project
{
    public interface IProject : IDisposable
    {
        /// <summary>
        /// Name of the project
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Path to the project
        /// </summary>
        string FullPath { get; set; }

        /// <summary>
        /// Exports the project
        /// </summary>
        void Export();

        /// <summary>
        /// Saves the project file
        /// </summary>
        void Save();
    }
}