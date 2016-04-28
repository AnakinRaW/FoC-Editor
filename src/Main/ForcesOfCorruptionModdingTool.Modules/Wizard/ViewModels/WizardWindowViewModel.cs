using System.ComponentModel.Composition;
using System.Windows.Input;
using ModernApplicationFramework.Caliburn;
using ModernApplicationFramework.Commands;

namespace ForcesOfCorruptionModdingTool.Modules.Wizard.ViewModels
{
    [Export(typeof(IWizardWindowViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class WizardWindowViewModel : Screen, IWizardWindowViewModel
    {
        private IWizardPage _activePage;
        private IWizardPage _firstPage;

        public IWizardPage ActivePage
        {
            get { return _activePage; }
            set
            {
                if (_activePage == value)
                    return;
                _activePage = value;
                NotifyOfPropertyChange();
            }
        }

        public IWizardPage FirstPage
        {
            get { return _firstPage; }
            set
            {
                if (_firstPage == value)
                    return;
                _firstPage = value;
                NotifyOfPropertyChange();
                ActivePage = FirstPage;
            }
        }

        public ICommand NextCommand => new CommandWrapper(Next, CanNext);

        public ICommand BackCommand => new CommandWrapper(Back, CanBack);

        public ICommand FinishCommand => new CommandWrapper(Finish, CanFinish);

        private bool CanFinish()
        {
            if (ActivePage == null)
                return false;
            return ActivePage.IsFinish;
        }

        private void Finish()
        {
            TryClose(true);
        }

        private bool CanBack()
        {
            return ActivePage?.PreviousPage != null;
        }

        private void Back()
        {
            ActivePage = ActivePage.PreviousPage;
        }

        private bool CanNext()
        {
            if (ActivePage == null)
                return false;
            return ActivePage.CanNext && ActivePage.NextPage != null;
        }

        private void Next()
        {
            ActivePage = ActivePage.NextPage;
        }
    }
}
