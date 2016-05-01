using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Caliburn.Micro;
using ForcesOfCorruptionModdingTool.EditorCore.Windows.FileSystem;
using ForcesOfCorruptionModdingTool.EditorCore.Workspace;
using ForcesOfCorruptionModdingTool.Modules.Wizard;
using Ionic.Zlib;
using Microsoft.Win32;
using ModernApplicationFramework.Commands;
using ModernApplicationFramework.Core.Utilities;

namespace ForcesOfCorruptionModdingTool.Modules.ExportManager.ExportWizard.Pages.Views
{
    public partial class ExportSettingsViewGeneral : IExportSettingsGeneral
    {
        private readonly IExportWizard _wizard;

        private readonly IModdingToolWorkspace _workspace = IoC.Get<IModdingToolWorkspace>();
        private IEnumerable<string> _complressionLevels;
        private bool _encrypt;
        private string _errorText;
        private string _password;
        private double _popupPositionY;
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
            Loaded += View1_Loaded;
        }

        public override string DisplayName => "Export Settings";
        public override bool IsFinish => false;
        public override IWizardPage NextPage { get; }


        public string ErrorText
        {
            get { return _errorText; }
            set
            {
                if (value == _errorText)
                    return;
                _errorText = value;
                OnPropertyChanged();
            }
        }

        public double PopupPositionY
        {
            get { return _popupPositionY; }
            set
            {
                if (value.Equals(_popupPositionY))
                    return;
                _popupPositionY = value;
                OnPropertyChanged();
            }
        }

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
            _wizard.ExportSettings.ExportPath = TargetLocation;
            _wizard.ExportSettings.CompressionLevel =
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

        private bool CheckSettings()
        {
            if (string.IsNullOrEmpty(TargetLocation))
            {
                ErrorText = null;
                return false;
            }
            if (!WindowsFileNameHelper.IsValidPath(TargetLocation))
            {
                ErrorText = "The given target location is not a valid path.";
                return false;
            }
            if (FileSystemHelper.PathIsInDirectory(SourceLocation, TargetLocation))
            {
                ErrorText = "The given target location must not be part of the mod you want to export.";
                return false;
            }
            if (!Path.GetFileName(TargetLocation).Contains(".zip"))
            {
                ErrorText = "The given target location must be a .zip file";
                return false;
            }
            ErrorText = null;
            return true;
        }

        private void InitCompressionLevelList()
        {
            var levels = new List<string>(Enum.GetNames(typeof(CompressionLevel)));
            ComplressionLevels = levels.Where(level => !level.StartsWith("Level")).ToList();
            SelectedCompression = ComplressionLevels.FirstOrDefault();
        }

        private void UpdateCanNext()
        {
            CanNext = CheckSettings();
        }

        //http://stackoverflow.com/questions/1600218/how-can-i-move-a-wpf-popup-when-its-anchor-element-moves/9898418#9898418
        private void View1_Loaded(object sender, RoutedEventArgs e)
        {
            var w = Window.GetWindow(this);
            if (null == w)
                return;
            w.LocationChanged += delegate
            {
                var offset = PopupPositionY;
                PopupPositionY = offset + 1;
                PopupPositionY = offset;
            };
            w.SizeChanged += delegate
            {
                var offset = PopupPositionY;
                PopupPositionY = offset + 1;
                PopupPositionY = offset;
            };
        }
    }
}