using System;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using ForcesOfCorruptionModdingTool.EditorCore.Project;
using ForcesOfCorruptionModdingTool.EditorCore.Workspace;
using ForcesOfCorruptionModdingTool.Mods;
using ForcesOfCorruptionModdingTool.Modules.DialogProvider;
using ForcesOfCorruptionModdingTool.ProjectDefinitions;
using ModernApplicationFramework.Caliburn;
using ModernApplicationFramework.Caliburn.Platform.Xaml;
using ModernApplicationFramework.Commands;
using ModernApplicationFramework.MVVM.Interfaces;

namespace ForcesOfCorruptionModdingTool.Modules.Workspace.Commands
{
    [Export(typeof(CommandDefinition))]
    public class NewProjectCommandDefinition : CommandDefinition
    {
#pragma warning disable 649
        [Import]
        private IModdingToolWorkspace _workspace;

        [ImportMany] private ISupportedProjectDefinition[] _definitions;

        [Import] private IDialogProvider _dialogProvider;
#pragma warning restore 649

        public override bool CanShowInMenu => true;
        public override bool CanShowInToolbar => false;
        public override string IconId => "NewProjectIcon";
        public override Uri IconSource => new Uri("/ForcesOfCorruptionModdingTool;component/Resources/Icons/NewProject.xaml",
                    UriKind.RelativeOrAbsolute);

        public override string Name => "New Project";
        public override string Text => Name;
        public override string ToolTip => "Creates a new Project";

        public override ICommand Command { get; }

        public NewProjectCommandDefinition()
        {
            Command = new GestureCommandWrapper(CreateNewProject, CanCreateNewProject, new KeyGesture(Key.N, ModifierKeys.Control | ModifierKeys.Shift));
        }

        private void CreateNewProject()
        {
            while (true)
            {
                var vm = (INewElementDialogModel) IoC.GetInstance(typeof(INewElementDialogModel), null);

                vm.ItemPresenter = new ProjectItemPresenter {ItemSource = _definitions};
                vm.DisplayName = "New Project";

                if (_workspace.Game.GameDirectory != null)
                    vm.Path = Path.Combine(_workspace.Game.GameDirectory, "Mods");

                var windowManager = IoC.Get<IWindowManager>();
                if (windowManager.ShowDialog(vm) != true)
                    return;

                var pi = vm.ResultData as ProjectInformation;
                if (pi == null)
                    return;

                if (Directory.Exists(Path.Combine(pi.ProjectPath, pi.Name)))
                {
                    _dialogProvider.Alert("The given name is already being used. Please chose another name.");
                    continue;
                }


                if (!ModFactory.CheckModPathInGame(pi.ProjectPath))
                {
                    var result =
                        _dialogProvider.Ask(
                            "The chosen Mod project path does not match the general convention on how to setup a mod.\r\n"
                            + "The suggested path would be in you primary games directory inside the 'Mods' folder\r\n\r\n"
                            + @"Example: C:\ProgramFiles\LucasArts\Star Wars Empire At War Forces of Corruption\Mods"
                            + "\r\n\r\nYou can however keep this path, but some features, like starting the mod will not work.\r\n"
                            + "Do you want to continue ?", MessageBoxButton.YesNo);
                    if (result)
                        continue;
                }
                _workspace.CreateProject(pi);
                break;
            }
        }

        private static bool CanCreateNewProject()
        {
            return IoC.GetAll<ISupportedProjectDefinition>().Any();
        }
    }
}
