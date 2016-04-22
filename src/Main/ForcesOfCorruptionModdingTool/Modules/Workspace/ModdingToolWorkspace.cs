using System;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Runtime.CompilerServices;
using ForcesOfCorruptionModdingTool.Annotations;
using ForcesOfCorruptionModdingTool.EditorCore.Game;
using ForcesOfCorruptionModdingTool.EditorCore.Mod;
using ForcesOfCorruptionModdingTool.EditorCore.Project;
using ForcesOfCorruptionModdingTool.EditorCore.Workspace;
using ModernApplicationFramework.MVVM.Core;
using ModernApplicationFramework.MVVM.Interfaces;
using ModernApplicationFramework.MVVM.Modules.OutputTool;

namespace ForcesOfCorruptionModdingTool.Modules.Workspace
{
    [Export(typeof(IModule))]
    [Export(typeof(IModdingToolWorkspace))]
    public class ModdingToolWorkspace : ModuleBase, IModdingToolWorkspace
    {
        private readonly IOutput _output;
        private IMod _sourceMod;
        private IModProject _currentProject;
        private IGame _game;

        public event EventHandler ProjectLoaded;

        public event EventHandler ProjectCreated;

        public event EventHandler ProjectClosed;

        [ImportingConstructor]
        public ModdingToolWorkspace(IOutput output)
        {
            _output = output;
        }

        public override void Initialize()
        {
            _output.AppendLine("Workspace initialized");
        }


        public void LoadProject(ProjectInformation information)
        {

        }

        public void CreateProject(ProjectInformation information)
        {
            throw new NotImplementedException();
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

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnProjectLoaded()
        {
            ProjectLoaded?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnProjectCreated()
        {
            ProjectCreated?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnProjectClosed()
        {
            ProjectClosed?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnProjectChanged()
        {
            ProjectChanged?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnSourceModChanged()
        {
            SourceModChanged?.Invoke(this, EventArgs.Empty);
            _output.AppendLine($"Source Mod at: {SourceMod.ModRootDirectory}");
        }

        protected virtual void OnGameChanged()
        {
            GameChanged?.Invoke(this, EventArgs.Empty);
            _output.AppendLine($"Game at: {Game.GameDirectory}");
        }
    }
}