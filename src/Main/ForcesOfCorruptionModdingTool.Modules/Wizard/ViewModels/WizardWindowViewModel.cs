using ModernApplicationFramework.Caliburn;
using ModernApplicationFramework.Commands;
using System;
using System.ComponentModel.Composition;
using System.Windows.Input;

namespace ForcesOfCorruptionModdingTool.Modules.Wizard.ViewModels
{
    [Export(typeof(IWizardWindowViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class WizardWindowViewModel : Screen, IWizardWindowViewModel
    {
        private IWizardPage _activePage;
        private IWizardPage _firstPage;
        private Uri _iconSource;
        private string _headingText;
        private string _description;

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

        public Uri IconSource
        {
            get { return _iconSource; }
            set
            {
                if (value == _iconSource)
                    return;
                _iconSource = value;
                NotifyOfPropertyChange();
            }
        }

        public string HeadingText
        {
            get { return _headingText; }
            set
            {
                if (value == _headingText)
                    return;
                _headingText = value;
                NotifyOfPropertyChange();
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                if (value == _description)
                    return;
                _description = value;
                NotifyOfPropertyChange();
            }
        }

        public ICommand NextCommand => new CommandWrapper(Next, CanNext);

        public ICommand BackCommand => new CommandWrapper(Back, CanBack);

        public ICommand FinishCommand => new CommandWrapper(Finish, CanFinish);

        private bool CanFinish()
        {
            return ActivePage != null && ActivePage.IsFinish;
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
            return ActivePage != null && (ActivePage.CanNext && ActivePage.NextPage != null);
        }

        private void Next()
        {
            ActivePage = ActivePage.NextPage;
        }
    }
}