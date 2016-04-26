using System.IO;

namespace ForcesOfCorruptionModdingTool.EditorCore.Project
{
    public class ProjectInformation
    {
        public ProjectInformation(ProjectInformationType type, string name, string projectPath, ISupportedProjectDefinition definition)
        {
            Type = type;
            ProjectPath = projectPath;
            Name = name;
            Definition = definition;
        }

        public ProjectInformation(ProjectInformationType type, string fullPath, ISupportedProjectDefinition definition)
        {
            Type = type;
            Definition = definition;

            Name = new DirectoryInfo(fullPath).Name;
            ProjectPath = Directory.GetParent(fullPath).FullName;

        }

        public ProjectInformationType Type { get; }

        public string Name { get; }

        public string ProjectPath { get; }

        public ISupportedProjectDefinition Definition { get; }
    }
}