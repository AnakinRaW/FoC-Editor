using ForcesOfCorruptionModdingTool.EditorCore.Project;

namespace ForcesOfCorruptionModdingTool.EditorCore.Workspace.EventArgs
{
    public class ProjectLoadedEventArgs : System.EventArgs
    {
        public ProjectLoadedEventArgs(IProject project)
        {
            Project = project;
        }

        public IProject Project { get; }
    }
}
