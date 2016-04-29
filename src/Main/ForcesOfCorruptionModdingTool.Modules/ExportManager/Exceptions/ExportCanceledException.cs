using System;
using System.Runtime.Serialization;

namespace ForcesOfCorruptionModdingTool.Modules.ExportManager.Exceptions
{
    public class ExportCanceledException : Exception
    {
        public ExportCanceledException()
        {
        }

        public ExportCanceledException(string message) : base(message)
        {
        }

        public ExportCanceledException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ExportCanceledException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
