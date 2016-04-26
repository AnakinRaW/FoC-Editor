using ForcesOfCorruptionModdingTool.EditorCore.Mod;

namespace ForcesOfCorruptionModdingTool.EditorCore.Project
{
    public interface IModProject : IProject
    {
        /// <summary>
        /// Contains the Mod of the project
        /// </summary>
        IMod Mod { get; set; }

        /// <summary>
        /// Creates a new Mod
        /// </summary>
        void CreateMod();

        /// <summary>
        /// Loads an existing mod
        /// </summary>
        void LoadMod();

        /// <summary>
        /// Imports an existing mod
        /// </summary>
        void ImportMod();
    }
}