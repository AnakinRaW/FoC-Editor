using System;

namespace ForcesOfCorruptionModdingTool.EditorCore.Workspace
{
    /// <summary>
    /// An <see cref="IProjectHandler"/> is responsible to do project operations
    /// </summary>
    public interface IProjectHandler
    {
        event EventHandler ProjectLoaded;

        event EventHandler ProjectCreated;

        event EventHandler ProjectClosed;

        void LoadProject();

        void CreateProject();

        void CloseProject();
    }
}