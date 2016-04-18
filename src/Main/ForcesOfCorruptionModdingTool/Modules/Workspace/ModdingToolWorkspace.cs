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

        public IModProject CurrentProject { get; private set; }
        public IMod SourceMod { get; set; }
        public IGame Game { get; set; }

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
    }
}