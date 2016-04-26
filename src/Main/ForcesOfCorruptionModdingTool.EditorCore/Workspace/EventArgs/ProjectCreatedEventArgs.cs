using ForcesOfCorruptionModdingTool.EditorCore.Project;

namespace ForcesOfCorruptionModdingTool.EditorCore.Workspace.EventArgs
{
    public class ProjectCreatedEventArgs : System.EventArgs
    {
        public ProjectCreatedEventArgs(IProject project)
        {
            Project = project;
        }

        public IProject Project { get; }
    }
}
