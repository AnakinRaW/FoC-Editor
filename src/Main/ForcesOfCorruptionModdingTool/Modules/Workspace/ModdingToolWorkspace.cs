using System;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using ForcesOfCorruptionModdingTool.Annotations;
using ForcesOfCorruptionModdingTool.EditorCore.Game;
using ForcesOfCorruptionModdingTool.EditorCore.Mod;
using ForcesOfCorruptionModdingTool.EditorCore.Project;
using ForcesOfCorruptionModdingTool.EditorCore.Workspace;
using ForcesOfCorruptionModdingTool.EditorCore.Workspace.EventArgs;
using ForcesOfCorruptionModdingTool.Mods;
using ForcesOfCorruptionModdingTool.Modules.DialogProvider;
using ForcesOfCorruptionModdingTool.Modules.Workspace.Commands;
using ForcesOfCorruptionModdingTool.Modules.Workspace.Exceptions;
using ModernApplicationFramework.Caliburn;
using ModernApplicationFramework.MVVM.Core;
using ModernApplicationFramework.MVVM.Interfaces;
using ModernApplicationFramework.MVVM.Modules.OutputTool;
using SourceChangedEventArgs = ForcesOfCorruptionModdingTool.EditorCore.Workspace.EventArgs.SourceChangedEventArgs;

namespace ForcesOfCorruptionModdingTool.Modules.Workspace
{
    [Export(typeof(IModule))]
    [Export(typeof(IModdingToolWorkspace))]
    public class ModdingToolWorkspace : ModuleBase, IModdingToolWorkspace
    {
        private readonly IDialogProvider _dialogProvider;
        private readonly IOutput _output;
        private IModProject _currentProject;
        private IGame _game;
        private IMod _sourceMod;
        private GameLaunchArguments _workspaceLaunchArguments;

        [ImportingConstructor]
        public ModdingToolWorkspace(IOutput output, IDialogProvider dialogProvider)
        {
            _dialogProvider = dialogProvider;
            _output = output;
        }

        public event EventHandler<ProjectLoadedEventArgs> ProjectLoaded;

        public event EventHandler<ProjectCreatedEventArgs> ProjectCreated;

        public event EventHandler<ProjectClosedEventArgs> ProjectClosed;

        public event EventHandler<ProjectChangedEventArgs> ProjectChanged;

        public event EventHandler<SourceChangedEventArgs> SourceModChanged;

        public event EventHandler<GameChangedEventArgs> GameChanged;

        public IModProject CurrentProject
        {
            get { return _currentProject; }
            private set
            {
                if (Equals(value, _currentProject))
                    return;
                var oldValue = _currentProject;
                _currentProject = value;
                OnPropertyChanged();
                OnProjectChanged(new ProjectChangedEventArgs(value, oldValue));
            }
        }

        public IMod SourceMod
        {
            get { return _sourceMod; }
            set
            {
                if (Equals(value, _sourceMod))
                    return;
                _sourceMod = value;
                OnPropertyChanged();
                OnSourceModChanged(new SourceChangedEventArgs(value));
            }
        }

        public IGame Game
        {
            get { return _game; }
            set
            {
                if (Equals(value, _game))
                    return;
                _game = value;
                OnPropertyChanged();
                OnGameChanged(new GameChangedEventArgs(value));
            }
        }

        public GameLaunchArguments WorkspaceLaunchArguments
        {
            get { return _workspaceLaunchArguments; }
            set
            {
                if (Equals(value, _workspaceLaunchArguments))
                    return;
                _workspaceLaunchArguments = value;
                OnPropertyChanged();
            }
        }

        public void LoadProject(ProjectInformation information)
        {
            //Since this is not requested that often we will delay this.
            // It will be possible however to import a mod
            throw new NotImplementedException();
        }

        public void CreateProject(ProjectInformation information)
        {
            if (!WorkspaceHelper.ValidateInformation(information))
            {
                IoC.Get<NewProjectCommandDefinition>().Command.Execute(null);
                return;
            }

            if (CurrentProject != null)
                CloseProject();
            CurrentProject = new ModProject(information);

            // If the project is inside the workspace game add the mod to the game, do nothing if it is not.
            if (ModFactory.CheckModPathInGame(CurrentProject.Mod.ModRootDirectory))
                Game.AddMod(CurrentProject.Mod);

            OnProjectCreated(new ProjectCreatedEventArgs(CurrentProject));
        }

        public void CloseProject()
        {
            CurrentProject?.Dispose();
            var oldProject = CurrentProject;
            CurrentProject = null;
            OnProjectClosed(new ProjectClosedEventArgs(oldProject));
        }

        public void ImportMod(string path)
        {
            if (CurrentProject != null)
                CloseProject();

            if (!WorkspaceHelper.ValidateImportPath(path))
                return;

            try
            {
                var modLocation = AskToMoveIfRequired(path);
                var information = new ProjectInformation(ProjectInformationType.Import, modLocation, null);
                CurrentProject = new ModProject(information);
                if (ModFactory.CheckModPathInGame(CurrentProject.Mod.ModRootDirectory))
                    Game.AddMod(CurrentProject.Mod);
            }
            catch (ImportCanceledException)
            {
                _output.AppendLine("Import Canceled by user");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override void Initialize()
        {
            _output.AppendLine("Workspace initialized");
        }

        protected virtual void OnGameChanged(GameChangedEventArgs e)
        {
            GameChanged?.Invoke(this, e);
            _output.AppendLine($"Game at: {e.Game?.GameDirectory} of Type: {e.Game?.GetType().Name}");
        }

        protected virtual void OnProjectChanged(ProjectChangedEventArgs e)
        {
            ProjectChanged?.Invoke(this, e);
            if (CurrentProject != null)
                _output.AppendLine($"New Mod-Project in workspace: {CurrentProject.Name}");
        }

        protected virtual void OnProjectClosed(ProjectClosedEventArgs e)
        {
            ProjectClosed?.Invoke(this, e);
            _output.AppendLine("Closed Mod-Project");
        }

        protected virtual void OnProjectCreated(ProjectCreatedEventArgs e)
        {
            ProjectCreated?.Invoke(this, e);
            _output.AppendLine($"Created new Mod-Project: {CurrentProject.Name}");
        }

        protected virtual void OnProjectLoaded(ProjectLoadedEventArgs e)
        {
            ProjectLoaded?.Invoke(this, e);
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnSourceModChanged(SourceChangedEventArgs e)
        {
            SourceModChanged?.Invoke(this, e);
            _output.AppendLine($"Source Mod at: {e.Mod?.ModRootDirectory}");
        }

        private string AskToMoveIfRequired(string path)
        {
            if (ModFactory.CheckModPathInGame(path))
                return path;
            if (Game.Mods != null && Game.Mods.Any(x => x.Name == new DirectoryInfo(path).Name))
            {
                _dialogProvider.Inform("The selected mod is not installed in the game the editor uses." +
                                       "\r\nSome features like starting the mod might not work in this case.");
                return path;
            }
            var result = _dialogProvider.Ask("The selected mod is not installed in the game the editor uses." +
                                             "\r\nSome features like starting the mod might not work in this case.\r\n\r\n"
                                             +
                                             "Do you want to move the files to the game ? ", MessageBoxButton.YesNo);
            if (result)
                return path;

            var newPath = Path.Combine(Game.GameDirectory, "Mods", new DirectoryInfo(path).Name);

            if (WorkspaceHelper.MoveFiles(path, newPath))
                throw new ImportCanceledException();
            return newPath;
        }
    }
}