using System.Runtime.Serialization;

namespace GestionEscolar.Exceptions
{
    [Serializable]
    public class PreguntaRepetidaException : Exception
    {
        public PreguntaRepetidaException()
        {
        }

        public PreguntaRepetidaException(string? message) : base(message)
        {

        }

        public PreguntaRepetidaException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected PreguntaRepetidaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}