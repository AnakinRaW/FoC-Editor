using ModernApplicationFramework.Interfaces.Utilities;

namespace ForcesOfCorruptionModdingTool.EditorCore.Project
{
    public interface ISupportedProjectDefinition : IExtensionDefinition
    {
        void PrepareProject(Project project);
    }
}
