using ForcesOfCorruptionModdingTool.Modules.Wizard;

namespace ForcesOfCorruptionModdingTool.Modules.ExportManager.ExportWizard
{
    public interface IExportWizard : IWizardWindowViewModel
    {
        ExportSettings ExportSettings { get; }
    }
}
