using System;
using System.Runtime.Serialization;

namespace ForcesOfCorruptionModdingTool.EditorCore.Windows.ProcessManager
{
    public class ProcessNotExistException : Exception
    {
        public ProcessNotExistException()
        {
        }

        public ProcessNotExistException(string message) : base(message)
        {
        }

        public ProcessNotExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ProcessNotExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
