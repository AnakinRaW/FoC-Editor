using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows.Input;
using ModernApplicationFramework.Caliburn;
using ModernApplicationFramework.Core.Themes;
using ModernApplicationFramework.MVVM.Interfaces;

namespace ForcesOfCorruptionModdingTool.Configuration.ViewModles
{
    [Export(typeof(IFirstStartConfigModel))]
    public class FirstStartConfigViewModel : Screen, IFirstStartConfigModel
    {
        private readonly ThemeManager _manager;
        private Theme _selectedTheme;
        private IDockingMainWindowViewModel _shell;

        [ImportingConstructor]
        public FirstStartConfigViewModel(IDockingMainWindowViewModel shell, ThemeManager manager)
        {
            _manager = manager;
            _shell = shell;
            SelectedTheme = Themes.FirstOrDefault(x => x.GetType() == _shell.Theme?.GetType());
        }

        public IEnumerable<Theme> Themes => _manager.Themes;
        public string GamePath { get; set; }
        public string SourcePath { get; set; }
        public bool IsSteam { get; set; }

        public Theme SelectedTheme
        {
            get { return _selectedTheme; }
            set
            {
                if (value.Equals(_selectedTheme))
                    return;
                _selectedTheme = value;
                NotifyOfPropertyChange();
            }
        }

        public ICommand BrowseGameCommand { get; }
        public ICommand BrowseSourceCommand { get; }
        public ICommand StartCommand { get; }
    }
}
