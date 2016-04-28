using System.ComponentModel.Composition;
using ModernApplicationFramework.Caliburn.Platform.Xaml;

namespace ForcesOfCorruptionModdingTool.Modules.ExportManager
{
    [Export(typeof(Wizard.ViewModels.WizardWindowViewModel))]
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

    public interface IExportWizard
    {
        ExportSettings ExportSettings { get;}
    }
}
