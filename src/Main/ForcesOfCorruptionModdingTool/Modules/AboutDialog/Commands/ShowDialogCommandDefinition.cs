using System;
using System.ComponentModel.Composition;
using System.Windows.Input;
using ModernApplicationFramework.Commands;

namespace ForcesOfCorruptionModdingTool.Modules.AboutDialog.Commands
{
    [Export(typeof(CommandDefinition))]
    public sealed class ShowDialogCommandDefinition : CommandDefinition
    {
        public override bool CanShowInMenu => true;
        public override bool CanShowInToolbar => false;
        public override string IconId => null;
        public override Uri IconSource => null;
        public override string Name => "Information about this tool";
        public override string Text => Name;
        public override string ToolTip => Name;

        public override ICommand Command { get; }

        public ShowDialogCommandDefinition()
        {
            Command = new CommandWrapper(ShowDialog, () => true);
        }

        private void ShowDialog()
        {
            new AboutDialog().ShowDialog();
        }
    }
}
