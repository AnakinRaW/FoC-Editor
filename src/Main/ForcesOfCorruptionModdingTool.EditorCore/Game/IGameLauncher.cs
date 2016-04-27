using System.Collections.Generic;
using System.Windows.Input;
using ForcesOfCorruptionModdingTool.EditorCore.Mod;

namespace ForcesOfCorruptionModdingTool.EditorCore.Game
{
    public interface IGameLauncher
    {
        IEnumerable<IMod> InstalledMods { get; set; }

        ICommand LaunchCommand { get; }

        bool IsWindowMode { get; set; }

        IMod SelectedMod { get; set; }
    }
}
