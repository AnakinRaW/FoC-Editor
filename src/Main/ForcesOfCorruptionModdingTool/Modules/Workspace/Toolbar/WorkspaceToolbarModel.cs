using System.Collections.Generic;
using System.Windows.Input;
using Caliburn.Micro;
using ForcesOfCorruptionModdingTool.EditorCore.Game;
using ForcesOfCorruptionModdingTool.EditorCore.Mod;
using ForcesOfCorruptionModdingTool.EditorCore.Workspace;
using ForcesOfCorruptionModdingTool.EditorCore.Workspace.EventArgs;
using ForcesOfCorruptionModdingTool.Modules.Workspace.Commands;
using ModernApplicationFramework.Commands.Service;
using ModernApplicationFramework.ViewModels;

namespace ForcesOfCorruptionModdingTool.Modules.Workspace.Toolbar
{
    public class WorkspaceToolbarModel : ViewModelBase, IGameLauncher
    {
        private IEnumerable<IMod> _installedMods;
        private bool _isWindowMode;
        private IMod _selectedMod;

        static WorkspaceToolbarModel()
        {
            ViewLocator.AddNamespaceMapping(typeof(WorkspaceToolbarModel).Namespace,
                typeof(WorkspaceToolbarModel).Namespace);
        }

        public WorkspaceToolbarModel()
        {
            Workspace.ProjectChanged += Workspace_ProjectChanged;
            IsWindowMode = true;
        }

        public ICommand RestartCommand
            => IoC.Get<ICommandService>().GetCommandDefinition(typeof(RestartWorkspaceGameCommandDefinition)).Command;

        public ICommand StopCommand
            => IoC.Get<ICommandService>().GetCommandDefinition(typeof(StopWorkspaceGameCommandDefinition)).Command;

        public IModdingToolWorkspace Workspace => IoC.Get<IModdingToolWorkspace>();

        public IEnumerable<IMod> InstalledMods
        {
            get { return _installedMods; }
            set
            {
                if (Equals(value, _installedMods))
                    return;
                _installedMods = value;
                OnPropertyChanged();
            }
        }

        public string Language { get; set; }

        public IMod SelectedMod
        {
            get { return _selectedMod; }
            set
            {
                if (value == _selectedMod)
                    return;
                _selectedMod = value;
                OnPropertyChanged();
                UpdateLaunchArguments();
            }
        }

        public bool IsWindowMode
        {
            get { return _isWindowMode; }
            set
            {
                _isWindowMode = value;
                UpdateLaunchArguments();
            }
        }


        public ICommand LaunchCommand
            => IoC.Get<ICommandService>().GetCommandDefinition(typeof(StartWorkspaceGameCommandDefinition)).Command;

        public void UpdateLaunchArguments()
        {
            var gla = new GameLaunchArguments
            {
                Mod = SelectedMod,
                Windowed = IsWindowMode
            };
            Workspace.WorkspaceLaunchArguments = gla;
        }

        private void Workspace_ProjectChanged(object sender, ProjectChangedEventArgs e)
        {
            InstalledMods = e.NewProject == null ? new List<IMod>() : new List<IMod> {((ModProject) e.NewProject).Mod};
            SelectedMod = ((ModProject) e.NewProject)?.Mod;
        }
    }
}