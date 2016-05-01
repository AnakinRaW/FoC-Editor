using System;
using Caliburn.Micro;

namespace ForcesOfCorruptionModdingTool.Modules.Wizard
{
    public interface IWizardWindowViewModel : IScreen
    {
        /// <summary>
        /// Reference to the active page
        /// </summary>
        IWizardPage ActivePage { get; set; }

        /// <summary>
        /// Reference to the first page
        /// </summary>
        IWizardPage FirstPage { get; set; }

        /// <summary>
        /// Icon for the window
        /// </summary>
        Uri IconSource { get; set; }

        /// <summary>
        /// Heading Text
        /// </summary>
        string HeadingText { get; set; }

        /// <summary>
        /// Heading Description
        /// </summary>
        string Description { get; set; }
    }
}