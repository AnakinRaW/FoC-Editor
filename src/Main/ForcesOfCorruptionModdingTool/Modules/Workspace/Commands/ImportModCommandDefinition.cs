using ForcesOfCorruptionModdingTool.EditorCore.Workspace;
using ModernApplicationFramework.Commands;
using ModernApplicationFramework.Dialoges;
using System;
using System.ComponentModel.Composition;
using System.Windows.Input;

namespace ForcesOfCorruptionModdingTool.Modules.Workspace.Commands
{
    [Export(typeof(CommandDefinition))]
    [Export(typeof(ImportModCommandDefinition))]
    public class ImportModCommandDefinition : CommandDefinition
    {
#pragma warning disable 649

        [Import]
        private IModdingToolWorkspace _workspace;

#pragma warning restore 649

        public override bool CanShowInMenu => true;
        public override bool CanShowInToolbar => false;
        public override string IconId => "ImportModIcon";

        public override Uri IconSource => new Uri("/ForcesOfCorruptionModdingTool;component/Resources/Icons/ImportMod.xaml",
                    UriKind.RelativeOrAbsolute);

        public override string Name => "Import Mod";
        public override string Text => Name;
        public override string ToolTip => "Import a mod from Disk";

        public override ICommand Command { get; }

        public ImportModCommandDefinition()
        {
            //This is the wrong shortcut but since we do not handle project files yet we can override it due usability aspects
            Command = new GestureCommandWrapper(ImportMod, CanImportMod, new KeyGesture(Key.O, ModifierKeys.Control | ModifierKeys.Shift));
        }

        private void ImportMod()
        {
            var dialog = new FolderBrowserDialog
            {
                Description = "Please chose the root directory of the mod you want to import."
            };
            if (dialog.ShowDialog() == false)
                return;
            _workspace.ImportMod(dialog.SelectedPath);
        }

        private static bool CanImportMod()
        {
            return true;
        }
    }
}