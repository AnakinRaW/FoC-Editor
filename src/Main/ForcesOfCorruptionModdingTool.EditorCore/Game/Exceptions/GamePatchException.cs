using System;

namespace ForcesOfCorruptionModdingTool.EditorCore.Game.Exceptions
{
    public class GamePatchException : GameExceptions
    {
        public GamePatchException()
        {
        }

        public GamePatchException(string message) : base(message)
        {
        }

        public GamePatchException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
