using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace ForcesOfCorruptionModdingTool.Modules.ExportManager.ExportWizard.Pages
{
    public interface IExportSettingsGeneral : IExportSettingsModifier, INotifyPropertyChanged
    {
        ICommand BrowseCommand { get; }

        IEnumerable<string> ComplressionLevels { get; set; }

        bool Encrypt { get; set; }

        string Password { get; set; }

        string SelectedCompression { get; set; }
        string SourceLocation { get; set; }
        string TargetLocation { get; set; }
    }
}
