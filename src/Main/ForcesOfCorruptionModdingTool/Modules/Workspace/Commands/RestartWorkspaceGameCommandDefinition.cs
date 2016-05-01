using ForcesOfCorruptionModdingTool.EditorCore.Workspace;
using ModernApplicationFramework.Commands;
using System;
using System.ComponentModel.Composition;
using System.Windows.Input;
using Caliburn.Micro;
using ModernApplicationFramework.Commands.Service;

namespace ForcesOfCorruptionModdingTool.Modules.Workspace.Commands
{
    [Export(typeof(CommandDefinition))]
    public class RestartWorkspaceGameCommandDefinition : CommandDefinition
    {
#pragma warning disable 649

        [Import]
        private IModdingToolWorkspace _workspace;

#pragma warning restore 649

        public override bool CanShowInMenu => false;
        public override bool CanShowInToolbar => false;
        public override string IconId => null;

        public override Uri IconSource => null;

        public override string Name => "Restart Game";
        public override string Text => Name;
        public override string ToolTip => "Restarts the game with same arguments";

        public override ICommand Command { get; }

        public RestartWorkspaceGameCommandDefinition()
        {
            Command = new GestureCommandWrapper(Restart, CanRestart, new KeyGesture(Key.F5, ModifierKeys.Shift | ModifierKeys.Control));
        }

        private bool CanRestart()
        {
            return _workspace.Game != null && _workspace.Game.GameProcessData.IsProcessRunning;
        }

        private void Restart()
        {
            IoC.Get<ICommandService>().GetCommandDefinition(typeof(StopWorkspaceGameCommandDefinition)).Command.Execute(null);
            IoC.Get<ICommandService>().GetCommandDefinition(typeof(StartWorkspaceGameCommandDefinition)).Command.Execute(null);
        }
    }
}