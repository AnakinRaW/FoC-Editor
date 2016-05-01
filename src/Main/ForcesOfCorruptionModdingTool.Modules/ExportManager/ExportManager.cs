using System;
using System.IO;
using System.Windows;
using Caliburn.Micro;
using ForcesOfCorruptionModdingTool.EditorCore.Project;
using ForcesOfCorruptionModdingTool.EditorCore.Windows.FileSystem.Compression;
using ForcesOfCorruptionModdingTool.Modules.ExportManager.Exceptions;
using ForcesOfCorruptionModdingTool.Modules.ExportManager.ExportWizard;
using ForcesOfCorruptionModdingTool.Modules.ExportManager.ExportWizard.Pages.Views;
using ModernApplicationFramework.Controls;
using ModernApplicationFramework.MVVM.Interfaces;
using ModernApplicationFramework.MVVM.Modules.OutputTool;

namespace ForcesOfCorruptionModdingTool.Modules.ExportManager
{
    public class ExportManager : IExportManager
    {
        private readonly IOutput _output = IoC.Get<IOutput>();
        private readonly IDockingMainWindowViewModel _mainWindow = IoC.Get<IDockingMainWindowViewModel>();


        public IModProject Project { get; }
        public ExportManager(IModProject project)
        {
            if (project == null)
                throw new ArgumentNullException(nameof(project));
            if (project.Mod == null)
                throw new ArgumentNullException(nameof(project.Mod));
            Project = project;
        }

        public void StartExportWizard()
        {
            var wizard = IoC.Get<IExportWizard>();
            wizard.DisplayName = "Export Wizard";
            wizard.HeadingText = $"Export '{Project?.Mod?.Name}'";
            wizard.Description = "This wizard will help you export your mod into a .zip file";
            wizard.FirstPage = new ExportSettingsViewGeneral(wizard, null);
            wizard.ExportSettings.Mod = Project?.Mod;

            var wm = IoC.Get<IWindowManager>();
            if (wm.ShowDialog(wizard) != true)
                return;
            Export(wizard.ExportSettings);
        }

        public void Export(ExportSettings settings)
        {
            _mainWindow.StatusBar.Mode = 4;
            _mainWindow.StatusBar.ModeText = "Started Export";
            _output.AppendLine($"1>------ Export Started: Project: {Project.Name}");
            CreateModPublishFiles(settings);
            try
            {
                ExportAsZip(settings);
            }
            catch (Exception e)
            {
                if (e is ExportCanceledException)
                    _output.AppendLine("1>------ Export Error: Canceled by user");
                else
                    _output.AppendLine($"1>------ Export Error: {e.Message}");
                return;
            }
            finally
            {
                _mainWindow.StatusBar.ModeText = "Ready";
                _mainWindow.StatusBar.RestoreMode();
            }
            _output.AppendLine($"1>------ Export Finished: Project: {Project.Name}");
        }

        public void ExportAsZip(ExportSettings settings)
        {
            _output.AppendLine($"1>Start Compressing: {settings.Mod.ModRootDirectory}");
            var wd = new WaitDialog
            {
                MessageText = "Creating Zip File...\r\nThis may take a while",
                Title = $"Exporting {Project.Name}",
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Owner = Application.Current.MainWindow
            };

            wd.ShowDialog(() =>
            {
                var cs = new CompressSettings(settings.Mod.ModRootDirectory, settings.ExportPath,
                    settings.CompressionLevel, settings.Password);
                FileCompression.CompressDirectory(cs);

            });
            if (wd.ActionWasAborted)
                throw new ExportCanceledException();
        }

        public void CreateModPublishFiles(ExportSettings settings)
        {
            CreateCredits(settings);
            CreateReadme(settings);
        }

        private void CreateReadme(ExportSettings settings)
        {
            var textFilePath = Path.Combine(settings.Mod.ModRootDirectory, "readme.txt");
            if (string.IsNullOrEmpty(settings.Readme))
                return;
            _output.AppendLine("1>Creating Readme file");
            using (var writer = new StreamWriter(textFilePath, false))
            {
                writer.WriteLine(settings.Readme);
            }
            _output.AppendLine("1>Creating Readme file finished");
        }

        private void CreateCredits(ExportSettings settings)
        {
            if (!settings.CreateCredits)
                return;
            _output.AppendLine("1>Creating Credits file");
            //TODO: The creditManager will be added much later, but we reserve code here.
            _output.AppendLine("1>Creating Credits file finished");
        }
    }
}
