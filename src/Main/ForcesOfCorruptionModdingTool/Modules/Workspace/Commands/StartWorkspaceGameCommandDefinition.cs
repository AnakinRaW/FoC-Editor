using ForcesOfCorruptionModdingTool.EditorCore.Workspace;
using ModernApplicationFramework.Commands;
using System;
using System.ComponentModel.Composition;
using System.Windows.Input;
using ForcesOfCorruptionModdingTool.Mods;

namespace ForcesOfCorruptionModdingTool.Modules.Workspace.Commands
{
    [Export(typeof(CommandDefinition))]
    public class StartWorkspaceGameCommandDefinition : CommandDefinition
    {
#pragma warning disable 649

        [Import]
        private IModdingToolWorkspace _workspace;

#pragma warning restore 649

        public override bool CanShowInMenu => false;
        public override bool CanShowInToolbar => false;
        public override string IconId => null;

        public override Uri IconSource => null;

        public override string Name => "Start game";
        public override string Text => Name;
        public override string ToolTip => "Start the game with given arguments";

        public override ICommand Command { get; }

        public StartWorkspaceGameCommandDefinition()
        {
            Command = new GestureCommandWrapper(Launch, CanLaunch, new KeyGesture(Key.F5));
        }

        private bool CanLaunch()
        {
            if (_workspace.Game == null)
                return false;
            return _workspace.WorkspaceLaunchArguments.Mod == null
                   || ModFactory.CheckModPathInGame(_workspace.WorkspaceLaunchArguments.Mod.ModRootDirectory);
        }

        private void Launch()
        {
            _workspace.Game.StartGame(_workspace.WorkspaceLaunchArguments);
        }
    }
}