using System.Runtime.Serialization;

namespace GestionEscolar.Exceptions
{
    [Serializable]
    internal class PreguntaNotFoundException : Exception
    {
        public PreguntaNotFoundException()
        {
        }

        public PreguntaNotFoundException(string? message) : base(message)
        {
        }

        public PreguntaNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected PreguntaNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}