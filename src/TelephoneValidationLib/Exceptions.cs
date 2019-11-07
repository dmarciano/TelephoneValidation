using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace SMC.Validation.NANP
{
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class ValidationException : Exception
    {
        public string Reference { get; }

        public ValidationException(string reference) { Reference = reference; }

        public ValidationException(string message, string reference) : base(message) { Reference = reference; }

        public ValidationException(string message, string reference, Exception innerException) : base(message, innerException) { Reference = reference; }

        public ValidationException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    [ExcludeFromCodeCoverage]
    [Serializable]
    public class InvalidLengthException : Exception
    {
        public InvalidLengthException() { }

        public InvalidLengthException(string message) : base(message) { }

        public InvalidLengthException(string message, Exception innerException) : base(message, innerException) { }

        public InvalidLengthException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    [ExcludeFromCodeCoverage]
    [Serializable]
    public class InvalidNumberException : Exception
    {
        public InvalidNumberException() { }

        public InvalidNumberException(string message) : base(message) { }

        public InvalidNumberException(string message, Exception innerException) : base(message, innerException) { }

        public InvalidNumberException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    [ExcludeFromCodeCoverage]
    [Serializable]
    public class AreaCodeException : ValidationException
    {
        public AreaCodeException(string reference) : base(reference) { }

        public AreaCodeException(string message, string reference) : base(message, reference) { }

        public AreaCodeException(string message, string reference, Exception innerException) : base(message, reference, innerException) { }

        public AreaCodeException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    [ExcludeFromCodeCoverage]
    [Serializable]
    public class CentralOfficeCodeException : ValidationException
    {
        public CentralOfficeCodeException(string reference) : base(reference) { }

        public CentralOfficeCodeException(string message, string reference) : base(message, reference) { }

        public CentralOfficeCodeException(string message, string reference, Exception innerException) : base(message, reference, innerException) { }

        public CentralOfficeCodeException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}