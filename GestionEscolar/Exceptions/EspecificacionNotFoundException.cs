using System.Runtime.Serialization;

namespace GestionEscolar.Exceptions
{
    [Serializable]
    public class EspecificacionNotFoundException : Exception
    {
        public EspecificacionNotFoundException()
        {
        }

        public EspecificacionNotFoundException(string? message) : base(message)
        {
        }

        public EspecificacionNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected EspecificacionNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}