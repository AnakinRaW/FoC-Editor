namespace ForcesOfCorruptionModdingTool.EditorCore.Project
{
    public class ProjectInformation
    {
        public ProjectInformation(string name, string projectPath, ISupportedProjectDefinition definition)
        {
            ProjectPath = projectPath;
            Name = name;
            Definition = definition;
        }

        public string Name { get; }

        public string ProjectPath { get; }

        public ISupportedProjectDefinition Definition { get; }
    }
}
