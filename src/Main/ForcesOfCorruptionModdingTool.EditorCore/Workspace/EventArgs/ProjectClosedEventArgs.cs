using ForcesOfCorruptionModdingTool.EditorCore.Project;

namespace ForcesOfCorruptionModdingTool.EditorCore.Workspace.EventArgs
{
    public class ProjectClosedEventArgs : System.EventArgs
    {
        public ProjectClosedEventArgs(IProject project)
        {
            Project = project;
        }

        public IProject Project { get; }
    }
}
