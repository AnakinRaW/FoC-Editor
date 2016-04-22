using System;

namespace ForcesOfCorruptionModdingTool.EditorCore.Mod.Exceptions
{
    public class ModNotFoundException : ModExceptions
    {
        public ModNotFoundException()
        {
        }

        public ModNotFoundException(string messsage) : base(messsage)
        {
        }

        public ModNotFoundException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
