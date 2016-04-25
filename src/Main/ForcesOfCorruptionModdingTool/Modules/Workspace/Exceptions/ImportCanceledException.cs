using System;
using System.Runtime.Serialization;

namespace ForcesOfCorruptionModdingTool.Modules.Workspace.Exceptions
{
    internal class ImportCanceledException : Exception
    {
        public ImportCanceledException()
        {
        }

        public ImportCanceledException(string message) : base(message)
        {
        }

        public ImportCanceledException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ImportCanceledException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
