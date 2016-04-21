using ModernApplicationFramework.Core.Themes;
using System.Collections.Generic;
using System.Windows.Input;

namespace ForcesOfCorruptionModdingTool.Configuration
{
    public interface IFirstStartConfigModel
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