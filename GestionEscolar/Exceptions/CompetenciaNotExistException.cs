using System.Runtime.Serialization;

namespace GestionEscolar.Exceptions
{
    public class CompetenciaNotExistException : Exception
    {
        public CompetenciaNotExistException()
        {
        }

        public CompetenciaNotExistException(string? message) : base(message)
        {
        }

        public CompetenciaNotExistException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CompetenciaNotExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
