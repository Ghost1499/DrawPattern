using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DrawPattern.Exceptions
{
    class ChangeDimensionException : ArgumentException
    {
        public ChangeDimensionException()
        {
        }

        public ChangeDimensionException(string message) : base(message)
        {
        }

        public ChangeDimensionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ChangeDimensionException(string message, string paramName) : base(message, paramName)
        {
        }

        public ChangeDimensionException(string message, string paramName, Exception innerException) : base(message, paramName, innerException)
        {
        }

        protected ChangeDimensionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
