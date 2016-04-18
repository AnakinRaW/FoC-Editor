using ForcesOfCorruptionModdingTool.EditorCore.Mod;

namespace ForcesOfCorruptionModdingTool.EditorCore.Project
{
    public interface IModProject : IProject
    {
        IMod Mod { get; set; }

        void CreateMod();
    }
}