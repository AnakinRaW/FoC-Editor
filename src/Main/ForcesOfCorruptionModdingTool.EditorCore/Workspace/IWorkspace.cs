using System;
using ForcesOfCorruptionModdingTool.EditorCore.Project;
using ForcesOfCorruptionModdingTool.EditorCore.Workspace.EventArgs;

namespace ForcesOfCorruptionModdingTool.EditorCore.Workspace
{
    /// <summary>
    /// An <see cref="IProjectHandler"/> is responsible to do project operations
    /// </summary>
    public interface IProjectHandler
    {
        event EventHandler<ProjectLoadedEventArgs> ProjectLoaded;

        event EventHandler<ProjectCreatedEventArgs> ProjectCreated;

        event EventHandler<ProjectClosedEventArgs> ProjectClosed;

        /// <summary>
        /// Loads an existing Project
        /// </summary>
        /// <param name="information">Project information</param>
        void LoadProject(ProjectInformation information);

        /// <summary>
        /// Creates a new Project
        /// </summary>
        /// <param name="information">Project information</param>
        void CreateProject(ProjectInformation information);

        /// <summary>
        /// Closes the Project
        /// </summary>
        void CloseProject();
    }
}