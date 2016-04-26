using System.Collections.Generic;
using System.Windows.Input;
using ForcesOfCorruptionModdingTool.EditorCore.Game;
using ForcesOfCorruptionModdingTool.EditorCore.Mod;
using ForcesOfCorruptionModdingTool.EditorCore.Workspace;
using ForcesOfCorruptionModdingTool.Mods;
using ModernApplicationFramework.Caliburn;
using ModernApplicationFramework.Caliburn.Platform.Xaml;
using ModernApplicationFramework.Commands;
using ModernApplicationFramework.ViewModels;

namespace ForcesOfCorruptionModdingTool.Modules.Workspace.Toolbar
{
    public class WorkspaceToolbarModel : ViewModelBase
    {
        private IEnumerable<IMod> _itemSource;
        private IMod _selectedMod;

        static WorkspaceToolbarModel()
        {
            ViewLocator.AddNamespaceMapping(typeof(WorkspaceToolbarModel).Namespace,
                typeof(WorkspaceToolbarModel).Namespace);
        }

        public WorkspaceToolbarModel()
        {
            Workspace.ProjectChanged += Workspace_ProjectChanged;
        }

        private void Workspace_ProjectChanged(object sender, EditorCore.Workspace.EventArgs.ProjectChangedEventArgs e)
        {
            ItemSource = e.NewProject == null ? new List<IMod>() : new List<IMod> {((ModProject)e.NewProject).Mod};
            SelectedMod = ((ModProject) e.NewProject)?.Mod;
        }

        public IModdingToolWorkspace Workspace => IoC.Get<IModdingToolWorkspace>();

        public IEnumerable<IMod> ItemSource
        {
            get { return _itemSource; }
            set
            {
                if (Equals(value, _itemSource))
                    return;
                _itemSource = value;
                OnPropertyChanged();
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
                OnPropertyChanged();
            }
        }

        public bool IsWindowMode { get; set; }


        public ICommand LaunchCommand => new CommandWrapper(Launch, CanLaunch);

        public ICommand StopCommand => new CommandWrapper(Stop, CanStop);

        public ICommand RestartCommand => new CommandWrapper(Restart, CanRestart);

        private void Restart()
        {
            StopCommand.Execute(null);
            LaunchCommand.Execute(null);
        }

        private bool CanRestart()
        {
            if (Workspace.Game == null)
                return false;
            return Workspace.Game.GameProcessData.IsProcessRunning;
        }

        private bool CanStop()
        {
            return Workspace.Game?.GameProcessData?.Process != null;
        }

        private void Stop()
        {
            Workspace.Game?.GameProcessData?.Process.Kill();
        }

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
            return _selectedMod == null || ModFactory.CheckModPathInGame(_selectedMod.ModRootDirectory);
        }
    }
}
