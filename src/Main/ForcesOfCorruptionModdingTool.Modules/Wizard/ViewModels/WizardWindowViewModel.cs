using System.ComponentModel.Composition;
using ModernApplicationFramework.Caliburn.Conductor;

namespace ForcesOfCorruptionModdingTool.Modules.Wizard.ViewModels
{
    [Export(typeof(IWizardWindowViewModel))]
    public class WizardWindowViewModel : Conductor<IWizardPage>, IWizardWindowViewModel
    {
    }
}
