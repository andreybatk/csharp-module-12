using System;
using System.Runtime.Serialization;

namespace CSharpModule12.Infrastructure
{
    internal class InsufficientMoneyException : Exception
    {
        public InsufficientMoneyException() : base() { }
        public InsufficientMoneyException(string message) : base(message) { }
        public InsufficientMoneyException(string message, Exception innerException) : base(message, innerException) { }
        protected InsufficientMoneyException(SerializationInfo info, StreamingContext context) : base(info, context) { }

    }
}
