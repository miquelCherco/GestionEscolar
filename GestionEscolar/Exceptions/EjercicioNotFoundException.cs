using System.Runtime.Serialization;

namespace GestionEscolar.Exceptions
{
    [Serializable]
    internal class EjercicioNotFoundException : Exception
    {
        public EjercicioNotFoundException()
        {
        }

        public EjercicioNotFoundException(string? message) : base(message)
        {
        }

        public EjercicioNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected EjercicioNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}