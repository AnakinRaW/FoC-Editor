using ForcesOfCorruptionModdingTool.EditorCore.Mod;

namespace ForcesOfCorruptionModdingTool.EditorCore.Workspace.EventArgs
{
    public class SourceChangedEventArgs : System.EventArgs
    {
        public SourceChangedEventArgs(IMod mod)
        {
            Mod = mod;
        }

        public IMod Mod { get; }
    }
}
