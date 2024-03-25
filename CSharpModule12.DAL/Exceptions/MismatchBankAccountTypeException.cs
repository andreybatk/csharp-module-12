using System;
using System.Runtime.Serialization;

namespace CSharpModule12.DAL.Exceptions
{
    public class MismatchBankAccountTypeException : Exception
    {
        public MismatchBankAccountTypeException() : base() { }
        public MismatchBankAccountTypeException(string message) : base(message) { }
        public MismatchBankAccountTypeException(string message, Exception innerException) : base(message, innerException) { }
        protected MismatchBankAccountTypeException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}