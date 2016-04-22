using ModernApplicationFramework.Core.Themes;
using System.Collections.Generic;
using System.Windows.Input;
using ModernApplicationFramework.Caliburn.Interfaces;

namespace ForcesOfCorruptionModdingTool.Configuration
{
    public interface IFirstStartConfigModel : IScreen
    {
        IEnumerable<Theme> Themes { get; }

        string GamePath { get; set; }

        string SourcePath { get; set; }

        bool IsSteam { get; set; }

        Theme SelectedTheme { get; set; }

        ICommand BrowseGameCommand { get; }

        ICommand BrowseSourceCommand { get; }

        ICommand StartCommand { get; }
    }
}