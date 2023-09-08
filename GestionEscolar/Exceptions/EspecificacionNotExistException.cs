using System.Runtime.Serialization;

namespace GestionEscolar.Exceptions
{
    [Serializable]
    internal class EspecificacionNotExistException : Exception
    {
        public EspecificacionNotExistException()
        {
        }

        public EspecificacionNotExistException(string? message) : base(message)
        {
        }

        public EspecificacionNotExistException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected EspecificacionNotExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}