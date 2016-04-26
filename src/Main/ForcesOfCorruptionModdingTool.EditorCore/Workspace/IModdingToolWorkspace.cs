using System;
using System.ComponentModel;
using ForcesOfCorruptionModdingTool.EditorCore.Game;
using ForcesOfCorruptionModdingTool.EditorCore.Mod;
using ForcesOfCorruptionModdingTool.EditorCore.Project;

namespace ForcesOfCorruptionModdingTool.EditorCore.Workspace
{
    public interface IModdingToolWorkspace : IProjectHandler, INotifyPropertyChanged
    {

        event EventHandler ProjectChanged;

        event EventHandler SourceModChanged;

        event EventHandler GameChanged;

        /// <summary>
        /// Contains the current project
        /// </summary>
        IModProject CurrentProject { get; }

        /// <summary>
        /// Holds the reference source mod
        /// </summary>
        IMod SourceMod { get; set; }

        /// <summary>
        /// Holds the game the editors uses
        /// </summary>
        IGame Game { get; set; }

        /// <summary>
        /// Creates a project from an existing mod
        /// </summary>
        /// <param name="path"></param>
        void ImportMod(string path);
    }
}