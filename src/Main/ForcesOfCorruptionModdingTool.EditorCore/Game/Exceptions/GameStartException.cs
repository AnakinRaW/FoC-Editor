using System;

namespace ForcesOfCorruptionModdingTool.EditorCore.Game.Exceptions
{
    public class GameStartException : GameExceptions
    {
        public GameStartException()
        {
        }

        public GameStartException(string message) : base(message)
        {
        }

        public GameStartException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
