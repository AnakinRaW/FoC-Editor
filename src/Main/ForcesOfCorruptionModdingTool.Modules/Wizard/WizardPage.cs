using System.Windows.Controls;

namespace ForcesOfCorruptionModdingTool.Modules.Wizard
{
    public abstract class WizardPage : UserControl, IWizardPage
    {
        protected WizardPage(IWizardPage previousPage)
        {
            PreviousPage = previousPage;
        }

        public abstract IWizardPage NextPage { get; }
        public IWizardPage PreviousPage { get; }
        public abstract bool CanNext { get; protected set; }
        public abstract bool IsFinish { get; }
    }
}