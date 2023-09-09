using System.Runtime.Serialization;

namespace GestionEscolar.Exceptions
{
    [Serializable]
    public class EvaluacioNotFoundException : Exception
    {
        public EvaluacioNotFoundException()
        {
        }

        public EvaluacioNotFoundException(string? message) : base(message)
        {
        }

        public EvaluacioNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected EvaluacioNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}