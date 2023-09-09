using System.Runtime.Serialization;

namespace GestionEscolar.Exceptions
{
    public class CompetenciaNotFoundException : Exception
    {
        public CompetenciaNotFoundException()
        {
        }

        public CompetenciaNotFoundException(string? message) : base(message)
        {
        }

        public CompetenciaNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CompetenciaNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
