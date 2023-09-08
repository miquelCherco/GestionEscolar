using System.Runtime.Serialization;

namespace GestionEscolar.Exceptions
{
    [Serializable]
    internal class ActividadNotFoundException : Exception
    {
        public ActividadNotFoundException()
        {
        }

        public ActividadNotFoundException(string? message) : base(message)
        {
        }

        public ActividadNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ActividadNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}