using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Windows.Input;
using ForcesOfCorruptionModdingTool.EditorCore.Game;
using ForcesOfCorruptionModdingTool.EditorCore.Mod;
using ForcesOfCorruptionModdingTool.EditorCore.Workspace;
using ModernApplicationFramework.Caliburn;
using ModernApplicationFramework.Commands;
using ModernApplicationFramework.MVVM.Controls;
using ModernApplicationFramework.MVVM.Core;

namespace ForcesOfCorruptionModdingTool.Modules.ModLauncher
{
    [Export(typeof(IModLauncher))]
    public class ModLauncherViewModel : Tool, IModLauncher
    {
        public IModdingToolWorkspace Workspace => IoC.Get<IModdingToolWorkspace>();

        private IEnumerable<IMod> _installedMods;
        private IMod _selectedMod;
        public override PaneLocation PreferredLocation => PaneLocation.Right;
        public IEnumerable<IMod> InstalledMods
        {
            get { return _installedMods; }
            set
            {
                if (Equals(value, _installedMods))
                    return;
                _installedMods = value;
                NotifyOfPropertyChange();
            }
        }

        public IMod SelectedMod
        {
            get { return _selectedMod; }
            set
            {
                if (value == _selectedMod)
                    return;
                _selectedMod = value;
                NotifyOfPropertyChange();
            }
        }

        public ICommand LaunchCommand => new CommandWrapper(Launch, CanLaunch);
        public bool IsWindowMode { get; set; }

        private void Launch()
        {
            var gla = new GameLaunchArguments();
            if (_selectedMod != null)
                gla.Mod = _selectedMod;
            if (IsWindowMode)
                gla.Windowed = true;
            Workspace.Game.StartGame(gla);
        }

        private bool CanLaunch()
        {
            return Workspace.Game != null;
        }
    }
}
