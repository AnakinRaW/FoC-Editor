using System.ComponentModel.Composition;
using ModernApplicationFramework.Caliburn.Platform.Xaml;

namespace ForcesOfCorruptionModdingTool.Modules.ExportManager.ExportWizard
{
    [Export(typeof(Wizard.ViewModels.WizardWindowViewModel))]
    [Export(typeof(IExportWizard))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class WizardWindowViewModel : Wizard.ViewModels.WizardWindowViewModel, IExportWizard
    {
        static WizardWindowViewModel()
        {
            ViewLocator.AddNamespaceMapping(typeof(WizardWindowViewModel).Namespace,
                typeof(Wizard.Views.WizardWindowView).Namespace);
        }

        public WizardWindowViewModel()
        {
            ExportSettings = new ExportSettings();
        }

        public ExportSettings ExportSettings { get; }
    }
}
