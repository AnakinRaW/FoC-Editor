using ForcesOfCorruptionModdingTool.EditorCore.Project;
using ForcesOfCorruptionModdingTool.Modules.Wizard;
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

            var wizard = IoC.Get<IWizardWindowViewModel>();
            wizard.DisplayName = "Export Wizard";

            var wm = IoC.Get<IWindowManager>();
            wm.ShowDialog(wizard);

        }

        public void Export(ExportSettings settings)
        {
            
        }
    }
}
