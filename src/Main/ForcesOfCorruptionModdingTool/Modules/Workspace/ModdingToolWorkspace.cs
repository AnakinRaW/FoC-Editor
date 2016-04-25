using ForcesOfCorruptionModdingTool.Annotations;
using ForcesOfCorruptionModdingTool.EditorCore.Game;
using ForcesOfCorruptionModdingTool.EditorCore.Mod;
using ForcesOfCorruptionModdingTool.EditorCore.Project;
using ForcesOfCorruptionModdingTool.EditorCore.Workspace;
using ForcesOfCorruptionModdingTool.Mods;
using ForcesOfCorruptionModdingTool.Modules.DialogProvider;
using ForcesOfCorruptionModdingTool.Modules.Workspace.Commands;
using ModernApplicationFramework.Caliburn;
using ModernApplicationFramework.MVVM.Core;
using ModernApplicationFramework.MVVM.Interfaces;
using ModernApplicationFramework.MVVM.Modules.OutputTool;
using System;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;

namespace ForcesOfCorruptionModdingTool.Modules.Workspace
{
    [Export(typeof(IModule))]
    [Export(typeof(IModdingToolWorkspace))]
    public class ModdingToolWorkspace : ModuleBase, IModdingToolWorkspace
    {
        private readonly IOutput _output;
        private IModProject _currentProject;
        private IGame _game;
        private IMod _sourceMod;
        private readonly IDialogProvider _dialogProvider;

        [ImportingConstructor]
        public ModdingToolWorkspace(IOutput output, IDialogProvider dialogProvider)
        {
            _dialogProvider = dialogProvider;
            _output = output;
        }

        public event EventHandler ProjectLoaded;

        public event EventHandler ProjectCreated;

        public event EventHandler ProjectClosed;

        public void LoadProject(ProjectInformation information)
        {
            //Since this is not requested that often we will delay this.
            // It will be possible however to import a mod
            throw new NotImplementedException();
        }

        public void CreateProject(ProjectInformation information)
        {
            if (!ValidateInformation(information))
            {
                IoC.Get<NewProjectCommandDefinition>().Command.Execute(null);
                return;
            }

            CurrentProject = new ModProject(information);

            // If the project is inside the workspace game add the mod to the game, do nothing if it is not.
            if (ModFactory.CheckModPathInGame(CurrentProject.Mod.ModRootDirectory))
                Game.AddMod(CurrentProject.Mod);

            OnProjectCreated();
        }

        private bool ValidateInformation(ProjectInformation information)
        {
            if (Directory.Exists(Path.Combine(information.ProjectPath, information.Name)))
            {
                _dialogProvider.Alert("The given name is already being used. Please chose another name.");
                return false;
            }

            if (ModFactory.CheckModPathInGame(information.ProjectPath))
                return true;
            var result =
                _dialogProvider.Ask(
                    "The chosen Mod project path does not match the general convention on how to setup a mod.\r\n"
                    + "The suggested path would be in you primary games directory inside the 'Mods' folder\r\n\r\n"
                    + @"Example: C:\ProgramFiles\LucasArts\Star Wars Empire At War Forces of Corruption\Mods"
                    + "\r\n\r\nYou can however keep this path, but some features, like starting the mod will not work.\r\n"
                    + "Do you want to continue ?", MessageBoxButton.YesNo);
            return !result;
        }

        public void CloseProject()
        {
            CurrentProject?.Dispose();
            CurrentProject = null;
            OnProjectClosed();
        }

        public event EventHandler ProjectChanged;

        public event EventHandler SourceModChanged;

        public event EventHandler GameChanged;

        public IModProject CurrentProject
        {
            get { return _currentProject; }
            private set
            {
                if (Equals(value, _currentProject))
                    return;
                _currentProject = value;
                OnPropertyChanged();
                OnProjectChanged();
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
                OnSourceModChanged();
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
                OnGameChanged();
            }
        }

        public void ImportMod(string path)
        {
            throw new NotImplementedException();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override void Initialize()
        {
            _output.AppendLine("Workspace initialized");
        }

        protected virtual void OnGameChanged()
        {
            GameChanged?.Invoke(this, EventArgs.Empty);
            _output.AppendLine($"Game at: {Game.GameDirectory} of Type: {Game.GetType().Name}");
        }

        protected virtual void OnProjectChanged()
        {
            ProjectChanged?.Invoke(this, EventArgs.Empty);
            if (CurrentProject != null)
                _output.AppendLine($"New Mod-Project in workspace: {CurrentProject.Mod.Name}");
        }

        protected virtual void OnProjectClosed()
        {
            ProjectClosed?.Invoke(this, EventArgs.Empty);
            _output.AppendLine("Closed Mod-Project");
        }

        protected virtual void OnProjectCreated()
        {
            ProjectCreated?.Invoke(this, EventArgs.Empty);
            _output.AppendLine($"Created new Mod-Project: {CurrentProject.Mod.Name}");
        }

        protected virtual void OnProjectLoaded()
        {
            ProjectLoaded?.Invoke(this, EventArgs.Empty);
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnSourceModChanged()
        {
            SourceModChanged?.Invoke(this, EventArgs.Empty);
            _output.AppendLine($"Source Mod at: {SourceMod.ModRootDirectory}");
        }
    }
}