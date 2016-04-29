using System.IO;
using ForcesOfCorruptionModdingTool.EditorCore.Workspace;
using ForcesOfCorruptionModdingTool.Modules.Wizard;
using ModernApplicationFramework.Caliburn;

namespace ForcesOfCorruptionModdingTool.Modules.ExportManager.ExportWizard.Pages.Views
{
    public partial class ExportSettingsPublishFiles : IExportSettingsPublishFiles
    {
        private bool _createCredits;
        private bool _createReadme;
        private string _readmeText;
        private readonly IExportWizard _wizard;
        private readonly IModdingToolWorkspace _workspace = IoC.Get<IModdingToolWorkspace>();

        public ExportSettingsPublishFiles(IExportWizard wizard, IWizardPage page) : base(page)
        {
            InitializeComponent();
            _wizard = wizard;
            SetupControls();
        }

        private void SetupControls()
        {
            if (!File.Exists(Path.Combine(_workspace.CurrentProject.Mod.ModRootDirectory, "readme.txt")))
                return;
            CreateReadme = true;
            ReadmeText = File.ReadAllText(Path.Combine(_workspace.CurrentProject.Mod.ModRootDirectory, "readme.txt"));
        }

        public override string DisplayName => "Add Additional Information";
        public override IWizardPage NextPage => null;
        public override bool IsFinish => true;

        public bool CreateCredits
        {
            get { return _createCredits; }
            set
            {
                if (value == _createCredits)
                    return;
                _createCredits = value;
                OnPropertyChanged();
                UpdateExportSettings();
            }
        }

        public bool CreateReadme
        {
            get { return _createReadme; }
            set
            {
                if (value == _createReadme)
                    return;
                _createReadme = value;
                OnPropertyChanged();
                UpdateExportSettings();
            }
        }

        public string ReadmeText
        {
            get { return _readmeText; }
            set
            {
                if (value == _readmeText)
                    return;
                _readmeText = value;
                OnPropertyChanged();
                UpdateExportSettings();
            }
        }

        public void UpdateExportSettings()
        {
            if (_wizard == null)
                return;
            _wizard.ExportSettings.CreateCredits = CreateCredits;
            _wizard.ExportSettings.Readme = CreateReadme ? ReadmeText : null;
        }
    }
}
