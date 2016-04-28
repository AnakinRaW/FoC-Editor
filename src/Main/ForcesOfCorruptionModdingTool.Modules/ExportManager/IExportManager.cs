using ForcesOfCorruptionModdingTool.EditorCore.Project;

namespace ForcesOfCorruptionModdingTool.Modules.ExportManager
{
    public interface IExportManager
    {
        /// <summary>
        /// Contains the Project to export
        /// </summary>
        IModProject Project { get; }

        /// <summary>
        /// Starts the wizard to export the Project
        /// </summary>
        void StartExportWizard();

        /// <summary>
        /// Exports the project with given settings
        /// </summary>
        /// <param name="settings">Settings to export the project</param>
        void Export(ExportSettings settings);
    }
}
