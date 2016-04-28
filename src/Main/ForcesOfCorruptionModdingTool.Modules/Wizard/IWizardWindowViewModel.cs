using ModernApplicationFramework.Caliburn.Interfaces;

namespace ForcesOfCorruptionModdingTool.Modules.Wizard
{
    public interface IWizardWindowViewModel : IScreen
    {
        IWizardPage ActivePage { get; set; }

        IWizardPage FirstPage { get; set; }
    }
}
