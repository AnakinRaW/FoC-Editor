using ForcesOfCorruptionModdingTool.Annotations;
using ForcesOfCorruptionModdingTool.EditorCore.Game;
using ForcesOfCorruptionModdingTool.EditorCore.Mod;
using ForcesOfCorruptionModdingTool.EditorCore.Project;
using ForcesOfCorruptionModdingTool.EditorCore.Workspace;
using ForcesOfCorruptionModdingTool.Mods;
using ModernApplicationFramework.MVVM.Core;
using ModernApplicationFramework.MVVM.Interfaces;
using ModernApplicationFramework.MVVM.Modules.OutputTool;
using System;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Runtime.CompilerServices;

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

        [ImportingConstructor]
        public ModdingToolWorkspace(IOutput output)
        {
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
            CurrentProject = new ModProject(information);

            // If the project is inside the workspace game add the mod to the game, do nothing if it is not.
            if (ModFactory.CheckModPathInGame(CurrentProject.Mod.ModRootDirectory))
                Game.AddMod(CurrentProject.Mod);

            OnProjectCreated();
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