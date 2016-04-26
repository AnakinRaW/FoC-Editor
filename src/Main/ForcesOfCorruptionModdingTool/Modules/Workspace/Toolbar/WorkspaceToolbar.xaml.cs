using System.ComponentModel.Composition;
using ModernApplicationFramework.Controls;

namespace ForcesOfCorruptionModdingTool.Modules.Workspace.Toolbar
{
    [Export(typeof(ToolBar))]
    public partial class WorkspaceToolbar 
    {      
        public WorkspaceToolbar()
        {
            InitializeComponent();
            IdentifierName = "Workspace Toolbar";
            DataContext = new WorkspaceToolbarModel();
        }
    }
}
