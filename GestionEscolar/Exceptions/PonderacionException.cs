using System.Runtime.Serialization;

namespace GestionEscolar.Exceptions
{
    [Serializable]
    public class PonderacionException : Exception
    {
        private object value;

        public PonderacionException()
        {
        }

        public PonderacionException(object value)
        {
            this.value = value;
        }

        public PonderacionException(string? message) : base(message)
        {
        }

        public PonderacionException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected PonderacionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}