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

        IModProject CurrentProject { get; }

        IMod SourceMod { get; set; }

        IGame Game { get; set; }

        void ImportMod(string path);
    }
}