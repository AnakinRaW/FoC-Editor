using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using ForcesOfCorruptionModdingTool.EditorCore.Annotations;

namespace ForcesOfCorruptionModdingTool.Modules.Wizard
{
    public abstract class WizardPage : UserControl, IWizardPage
    {
        private bool _canNext;

        protected WizardPage(IWizardPage previousPage)
        {
            PreviousPage = previousPage;
        }

        public abstract string DisplayName { get; }
        public abstract IWizardPage NextPage { get; }
        public IWizardPage PreviousPage { get; }

        public bool CanNext
        {
            get { return _canNext; }
            protected set
            {
                if (value == _canNext)
                    return;
                _canNext = value;
                OnPropertyChanged();
            }
        }

        public abstract bool IsFinish { get; }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}