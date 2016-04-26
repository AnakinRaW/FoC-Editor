using ForcesOfCorruptionModdingTool.EditorCore.Project;

namespace ForcesOfCorruptionModdingTool.EditorCore.Workspace.EventArgs
{
    public class ProjectChangedEventArgs : System.EventArgs
    {
        public ProjectChangedEventArgs(IProject newProject, IProject oldProject)
        {
            NewProject = newProject;
            OldProject = oldProject;
        }

        public IProject NewProject { get; }

        public IProject OldProject { get; }
    }
}
