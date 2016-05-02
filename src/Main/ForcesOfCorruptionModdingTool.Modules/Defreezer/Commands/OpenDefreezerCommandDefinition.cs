using System;
using System.ComponentModel.Composition;
using System.Windows.Input;
using ModernApplicationFramework.Commands;
using ModernApplicationFramework.MVVM.Interfaces;

namespace ForcesOfCorruptionModdingTool.Modules.Defreezer
{
    [Export(typeof(CommandDefinition))]
    public class OpenDefreezerCommandDefinition : CommandDefinition
    {
#pragma warning disable 649
        [Import]
        private IDockingMainWindowViewModel _shell;
#pragma warning restore 649

        public OpenDefreezerCommandDefinition()
        {
            Command = new MultiKeyGestureCommandWrapper(Open, CanOpen, new MultiKeyGesture(new []{Key.E, Key.D}, ModifierKeys.Control));
        }

        public override bool CanShowInMenu => true;
        public override bool CanShowInToolbar => true;
        public override ICommand Command { get; }

        public override string IconId => null;

        public override Uri IconSource => null;

        public override string Name => "Save Game Defreezer";
        public override string Text => Name;
        public override string ToolTip => Name;

        public string MyText { get; set; }

        private bool CanOpen()
        {
            return _shell != null;
        }

        private void Open()
        {
            _shell.DockingHost.ShowTool<IDefreezerTool>();
        }
    }
}
