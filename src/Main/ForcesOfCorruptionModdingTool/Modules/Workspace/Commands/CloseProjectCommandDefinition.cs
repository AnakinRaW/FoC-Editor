using ForcesOfCorruptionModdingTool.EditorCore.Workspace;
using ModernApplicationFramework.Commands;
using System;
using System.ComponentModel.Composition;
using System.Windows.Input;

namespace ForcesOfCorruptionModdingTool.Modules.Workspace.Commands
{
    [Export(typeof(CommandDefinition))]
    public class CloseProjectCommandDefinition : CommandDefinition
    {
#pragma warning disable 649

        [Import]
        private IModdingToolWorkspace _workspace;

#pragma warning restore 649

        public override bool CanShowInMenu => true;
        public override bool CanShowInToolbar => true;
        public override string IconId => "CloseProgrammIcon";

        public override Uri IconSource =>
                new Uri("/ModernApplicationFramework.MVVM;component/Resources/Icons/CloseProgramm_16x.xaml",
                    UriKind.RelativeOrAbsolute);

        public override string Name => "Close Project";
        public override string Text => Name;
        public override string ToolTip => "Close current project";

        public override ICommand Command { get; }

        public CloseProjectCommandDefinition()
        {
            Command = new CommandWrapper(CloseProject, CanCloseProject);
        }

        private bool CanCloseProject()
        {
            return _workspace.CurrentProject != null;
        }

        private void CloseProject()
        {
            _workspace.CloseProject();
        }
    }
}