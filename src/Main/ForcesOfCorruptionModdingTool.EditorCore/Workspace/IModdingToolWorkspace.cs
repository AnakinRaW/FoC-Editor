using System;
using System.ComponentModel;
using ForcesOfCorruptionModdingTool.EditorCore.Game;
using ForcesOfCorruptionModdingTool.EditorCore.Mod;
using ForcesOfCorruptionModdingTool.EditorCore.Project;
using ForcesOfCorruptionModdingTool.EditorCore.Workspace.EventArgs;

namespace ForcesOfCorruptionModdingTool.EditorCore.Workspace
{
    public interface IModdingToolWorkspace : IProjectHandler, INotifyPropertyChanged
    {

        event EventHandler<ProjectChangedEventArgs> ProjectChanged;

        event EventHandler<SourceChangedEventArgs> SourceModChanged;

        event EventHandler<GameChangedEventArgs> GameChanged;

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
        /// Holds game the current GameLaunchArguments
        /// </summary>
        GameLaunchArguments WorkspaceLaunchArguments { get; set; }

        /// <summary>
        /// Creates a project from an existing mod
        /// </summary>
        /// <param name="path"></param>
        void ImportMod(string path);
    }
}