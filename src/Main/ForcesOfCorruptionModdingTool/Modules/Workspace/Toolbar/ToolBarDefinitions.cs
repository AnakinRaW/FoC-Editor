using System.ComponentModel.Composition;
using System.Windows.Controls;
using ModernApplicationFramework.Utilities;

namespace ForcesOfCorruptionModdingTool.Modules.Workspace.Toolbar
{
    public static class ToolBarDefinitions
    {
        [Export]
        public static ToolbarDefinition Workspace = new ToolbarDefinition<WorkspaceToolbar>(1, true, Dock.Top);
    }
}
