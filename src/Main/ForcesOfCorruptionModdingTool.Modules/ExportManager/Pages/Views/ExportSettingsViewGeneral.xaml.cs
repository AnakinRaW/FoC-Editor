using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using ForcesOfCorruptionModdingTool.EditorCore.Workspace;
using ForcesOfCorruptionModdingTool.Modules.Wizard;
using Ionic.Zlib;
using Microsoft.Win32;
using ModernApplicationFramework.Caliburn;
using ModernApplicationFramework.Commands;
using ModernApplicationFramework.Core.Utilities;

namespace ForcesOfCorruptionModdingTool.Modules.ExportManager.Pages.Views
{
    public partial class ExportSettingsViewGeneral : IExportSettingsGeneral
    {
        private readonly IExportWizard _wizard;

        private readonly IModdingToolWorkspace _workspace = IoC.Get<IModdingToolWorkspace>();
        private IEnumerable<string> _complressionLevels;
        private bool _encrypt;
        private string _password;
        private string _selectedCompression;
        private string _sourceLocation;
        private string _targetLocation;

        public ExportSettingsViewGeneral(IExportWizard wizard, IWizardPage page) : base(page)
        {
            InitializeComponent();
            InitCompressionLevelList();
            SourceLocation = _workspace?.CurrentProject?.Mod?.ModRootDirectory;
            _wizard = wizard;
            NextPage = new ExportSettingsPublishFiles(wizard, this);
        }

        public override string DisplayName => "Export Settings";
        public override bool IsFinish => false;
        public override IWizardPage NextPage { get; }

        public string SourceLocation
        {
            get { return _sourceLocation; }
            set
            {
                if (value == _sourceLocation)
                    return;
                _sourceLocation = value;
                OnPropertyChanged();
                UpdateCanNext();
                UpdateExportSettings();
            }
        }

        public string TargetLocation
        {
            get { return _targetLocation; }
            set
            {
                if (value == _targetLocation)
                    return;
                _targetLocation = value;
                OnPropertyChanged();
                UpdateCanNext();
                UpdateExportSettings();
            }
        }

        public ICommand BrowseCommand => new Command(Browse);

        public bool Encrypt
        {
            get { return _encrypt; }
            set
            {
                if (value == _encrypt)
                    return;
                _encrypt = value;
                OnPropertyChanged();
                UpdateExportSettings();
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                if (value == _password)
                    return;
                _password = value;
                OnPropertyChanged();
                UpdateExportSettings();
            }
        }

        public IEnumerable<string> ComplressionLevels
        {
            get { return _complressionLevels; }
            set
            {
                if (Equals(value, _complressionLevels))
                    return;
                _complressionLevels = value;
                OnPropertyChanged();
            }
        }

        public string SelectedCompression
        {
            get { return _selectedCompression; }
            set
            {
                if (value == _selectedCompression)
                    return;
                _selectedCompression = value;
                OnPropertyChanged();
                UpdateExportSettings();
            }
        }

        public void UpdateExportSettings()
        {
            if (_wizard == null)
                return;
            _wizard.ExportSettings.SourceLocation = SourceLocation;
            _wizard.ExportSettings.ExportPath = TargetLocation;
            _wizard.ExportSettings.CompressionMode =
                (CompressionLevel) Enum.Parse(typeof(CompressionLevel), SelectedCompression);
            _wizard.ExportSettings.Password = Encrypt ? Password : null;
        }

        private void Browse()
        {
            var dialog = new SaveFileDialog {FileName = _workspace.CurrentProject?.Mod?.Name};
            const string filter = "zip|*.zip";
            dialog.Filter = filter;

            if (dialog.ShowDialog() != true)
                return;
            TargetLocation = dialog.FileName;
        }

        private void InitCompressionLevelList()
        {
            var levels = new List<string>(Enum.GetNames(typeof(CompressionLevel)));
            ComplressionLevels = levels.Where(level => !level.StartsWith("Level")).ToList();
            SelectedCompression = ComplressionLevels.FirstOrDefault();
        }

        private void UpdateCanNext()
        {
            if (!WindowsFileNameHelper.IsValidPath(TargetLocation))
            {
                CanNext = false;
                return;
            }
            CanNext = true;
        }
    }
}