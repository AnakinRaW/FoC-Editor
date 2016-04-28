namespace ForcesOfCorruptionModdingTool.Modules.Wizard
{
    public interface IWizardPage
    {
        IWizardPage NextPage { get; }
        IWizardPage PreviousPage { get; }

        bool CanNext { get; }

        bool IsFinish { get; }
    }
}
