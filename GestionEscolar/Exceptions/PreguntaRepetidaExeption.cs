using System.Runtime.Serialization;

namespace GestionEscolar.Exceptions
{
    [Serializable]
    internal class PreguntaRepetidaExeption : Exception
    {
        public PreguntaRepetidaExeption()
        {
        }

        public PreguntaRepetidaExeption(string? message) : base(message)
        {

        }

        public PreguntaRepetidaExeption(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected PreguntaRepetidaExeption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}