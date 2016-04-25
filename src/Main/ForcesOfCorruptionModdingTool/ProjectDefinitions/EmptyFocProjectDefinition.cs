using System;
using System.ComponentModel.Composition;
using ForcesOfCorruptionModdingTool.EditorCore.Project;

namespace ForcesOfCorruptionModdingTool.ProjectDefinitions
{
    [Export(typeof(ISupportedProjectDefinition))]
    public class EmptyFocProjectDefinition : ISupportedProjectDefinition
    {
        public string ApplicationContext => "Forces of Corruption";
        public string Description => "Creates an empty Mod";

        public Uri IconSource
            =>
                new Uri(
                    "pack://application:,,,/ForcesOfCorruptionModdingTool;component/Resources/Icons/focProjectEmpty.png",
                    UriKind.RelativeOrAbsolute);
        public string Name => "Empty Project";
        public string PresetElementName => "NewMod";
        public int SortOrder => 1;

        public void PostPrepareProject(Project project)
        {
        }
    }
}
