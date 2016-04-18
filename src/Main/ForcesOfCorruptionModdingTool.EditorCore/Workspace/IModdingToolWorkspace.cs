using System.ComponentModel;
using ForcesOfCorruptionModdingTool.EditorCore.Game;
using ForcesOfCorruptionModdingTool.EditorCore.Mod;
using ForcesOfCorruptionModdingTool.EditorCore.Project;

namespace ForcesOfCorruptionModdingTool.EditorCore.Workspace
{
    public interface IModdingToolWorkspace : IProjectHandler, INotifyPropertyChanged
    {
        IModProject CurrentProject { get; }

        IMod SourceMod { get; set; }

        IGame Game { get; set; }
    }
}