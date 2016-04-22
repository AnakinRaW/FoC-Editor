using System;

namespace ForcesOfCorruptionModdingTool.EditorCore.Game.Exceptions
{
    public class GameNotFoundException : GameExceptions
    {
        public GameNotFoundException()
        {
        }

        public GameNotFoundException(string message) : base(message)
        {
        }

        public GameNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
