﻿using System.ComponentModel;

namespace ForcesOfCorruptionModdingTool.Modules.ExportManager.Pages
{
    public interface IExportSettingsPublishFiles : IExportSettingsModifier, INotifyPropertyChanged
    {
        bool CreateCredits { get; set; }

        bool CreateReadme { get; set; }

        string ReadmeText { get; set; }
    }
}
