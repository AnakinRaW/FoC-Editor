namespace ForcesOfCorruptionModdingTool.Modules.Wizard
{
    public interface IWizardPage
    {
        /// <summary>
        /// The name of the page. Will appear on the window
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Reference to the next page
        /// </summary>
        IWizardPage NextPage { get; }

        /// <summary>
        /// Reference to the last page
        /// </summary>
        IWizardPage PreviousPage { get; }

        /// <summary>
        /// Checks if all necessary input were made to proceed to the next page
        /// </summary>
        bool CanNext { get; }

        /// <summary>
        /// Tell whether this page is a finish page
        /// </summary>
        bool IsFinish { get; }
    }
}