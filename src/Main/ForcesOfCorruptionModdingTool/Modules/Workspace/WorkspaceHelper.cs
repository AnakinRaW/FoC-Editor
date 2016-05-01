using System.IO;
using System.Windows;
using Caliburn.Micro;
using ForcesOfCorruptionModdingTool.EditorCore.Project;
using ForcesOfCorruptionModdingTool.EditorCore.Windows.FileSystem;
using ForcesOfCorruptionModdingTool.Mods;
using ForcesOfCorruptionModdingTool.Modules.DialogProvider;
using ForcesOfCorruptionModdingTool.Modules.Workspace.Commands;
using ModernApplicationFramework.Controls;

namespace ForcesOfCorruptionModdingTool.Modules.Workspace
{
    public static class WorkspaceHelper
    {
        private static readonly IDialogProvider DialogProvider = IoC.Get<IDialogProvider>();

        public static bool ValidateImportPath(string path)
        {
            if (ModFactory.FindMod(path))
                return true;
            DialogProvider.Alert("The specified path does not contain a mod");
            IoC.Get<ImportModCommandDefinition>().Command.Execute(null);
            return false;
        }

        public static bool MoveFiles(string path, string newPath)
        {
            var wd = new WaitDialog
            {
                MessageText = "Moving Files...",
                Title = Configuration.ProductConfiguration.ProductName,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Owner = Application.Current.MainWindow
            };
            wd.ShowDialog(() => { FileSystemHelper.CopyFolder(path, newPath); });
            return wd.ActionWasAborted;
        }

        public static bool ValidateInformation(ProjectInformation information)
        {
            if (Directory.Exists(Path.Combine(information.ProjectPath, information.Name)))
            {
                DialogProvider.Alert("The given name is already being used. Please chose another name.");
                return false;
            }

            if (ModFactory.CheckModPathInGame(information.ProjectPath))
                return true;
            var result =
                DialogProvider.Ask(
                    "The chosen Mod project path does not match the general convention on how to setup a mod.\r\n"
                    + "The suggested path would be in you primary games directory inside the 'Mods' folder\r\n\r\n"
                    + @"Example: C:\ProgramFiles\LucasArts\Star Wars Empire At War Forces of Corruption\Mods"
                    + "\r\n\r\nYou can however keep this path, but some features, like starting the mod will not work.\r\n"
                    + "Do you want to continue ?", MessageBoxButton.YesNo);
            return !result;
        }
    }
}