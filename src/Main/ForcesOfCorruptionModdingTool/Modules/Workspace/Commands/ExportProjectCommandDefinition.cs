using System;
using System.ComponentModel.Composition;
using System.Windows.Input;
using ForcesOfCorruptionModdingTool.EditorCore.Workspace;
using ModernApplicationFramework.Commands;

namespace ForcesOfCorruptionModdingTool.Modules.Workspace.Commands
{
    [Export(typeof(CommandDefinition))]
    public class ExportProjectCommandDefinition : CommandDefinition
    {
#pragma warning disable 649

        [Import] private IModdingToolWorkspace _workspace;

#pragma warning restore 649

        public ExportProjectCommandDefinition()
        {
            Command = new MultiKeyGestureCommandWrapper(ExportProject, CanExportProject, new MultiKeyGesture(new []{Key.E, Key.M}, ModifierKeys.Control));
        }

        public override bool CanShowInMenu => true;
        public override bool CanShowInToolbar => true;

        public override ICommand Command { get; }
        public override string IconId => null;

        public override Uri IconSource => null;

        public override string Name => "Export Project";
        public override string Text => Name;
        public override string ToolTip => "Export current project to a mod archive";

        private bool CanExportProject()
        {
            return _workspace.CurrentProject != null;
        }

        private void ExportProject()
        {
            _workspace.CurrentProject.Export();
        }
    }
}