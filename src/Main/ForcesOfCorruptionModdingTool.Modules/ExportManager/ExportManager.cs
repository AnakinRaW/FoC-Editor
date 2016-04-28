using ForcesOfCorruptionModdingTool.EditorCore.Project;
using ForcesOfCorruptionModdingTool.Modules.ExportManager.Pages.Views;
using ModernApplicationFramework.Caliburn;
using ModernApplicationFramework.Caliburn.Platform.Xaml;

namespace ForcesOfCorruptionModdingTool.Modules.ExportManager
{
    public class ExportManager : IExportManager
    {
        public IModProject Project { get; }
        public ExportManager(IModProject project)
        {
            Project = project;
        }

        public void StartExportWizard()
        {
            var wizard = IoC.Get<Wizard.ViewModels.WizardWindowViewModel>();
            wizard.DisplayName = "Export Wizard";
            wizard.HeadingText = $"Export '{Project?.Mod?.Name}'";
            wizard.Description = "This wizard will help you export your mod into a .zip file";
            wizard.FirstPage = new ExportSettingsViewGeneral((IExportWizard)wizard, null);

            var wm = IoC.Get<IWindowManager>();
            if (wm.ShowDialog(wizard) != true)
                return;

        }

        public void Export(ExportSettings settings)
        {
            
        }
    }
}
