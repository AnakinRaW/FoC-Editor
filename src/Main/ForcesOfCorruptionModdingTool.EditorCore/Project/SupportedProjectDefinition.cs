using ModernApplicationFramework.Interfaces.Utilities;

namespace ForcesOfCorruptionModdingTool.EditorCore.Project
{
    public interface ISupportedProjectDefinition : IExtensionDefinition
    {
        /// <summary>
        /// Performs some tasks to be done after a project was created
        /// </summary>
        /// <param name="project"></param>
        void PostPrepareProject(Project project);
    }
}