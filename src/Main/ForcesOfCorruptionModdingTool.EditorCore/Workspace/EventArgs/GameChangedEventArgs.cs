using ForcesOfCorruptionModdingTool.EditorCore.Game;

namespace ForcesOfCorruptionModdingTool.EditorCore.Workspace.EventArgs
{
    public class GameChangedEventArgs : System.EventArgs
    {
        public GameChangedEventArgs(IGame game)
        {
            Game = game;
        }

        public IGame Game { get; }
    }
}
