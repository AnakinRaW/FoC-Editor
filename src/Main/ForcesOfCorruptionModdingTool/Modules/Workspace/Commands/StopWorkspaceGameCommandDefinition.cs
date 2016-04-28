using ForcesOfCorruptionModdingTool.EditorCore.Workspace;
using ModernApplicationFramework.Commands;
using System;
using System.ComponentModel.Composition;
using System.Windows.Input;

namespace ForcesOfCorruptionModdingTool.Modules.Workspace.Commands
{
    [Export(typeof(CommandDefinition))]
    public class StopWorkspaceGameCommandDefinition : CommandDefinition
    {
#pragma warning disable 649

        [Import]
        private IModdingToolWorkspace _workspace;

#pragma warning restore 649

        public override bool CanShowInMenu => false;
        public override bool CanShowInToolbar => false;
        public override string IconId => null;

        public override Uri IconSource => null;

        public override string Name => "Stop Game";
        public override string Text => Name;
        public override string ToolTip => "Closes the current game process";

        public override ICommand Command { get; }

        public StopWorkspaceGameCommandDefinition()
        {
            Command = new GestureCommandWrapper(Stop, CanStop, new KeyGesture(Key.F5, ModifierKeys.Shift));
        }

        private bool CanStop()
        {
            return _workspace.Game?.GameProcessData?.Process != null;
        }

        private void Stop()
        {
            _workspace.Game?.GameProcessData?.Process.Kill();
        }
    }
}