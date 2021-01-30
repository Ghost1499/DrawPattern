using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DrawPattern.Exceptions
{
    class FieldIndexOutOfRangeException : ArgumentOutOfRangeException
    {
        public int I { get; private set; }
        public int J { get; private set; }


        private void SetUpParams(int i, int j)
        {
            I = i;
            J = j;
        }
        public FieldIndexOutOfRangeException()
        {
        }
        public FieldIndexOutOfRangeException(int i, int j)
        {
            SetUpParams(i, j);
        }

        public FieldIndexOutOfRangeException(string paramName) : base(paramName)
        {
        }

        public FieldIndexOutOfRangeException(string paramName, string message) : base(paramName, message)
        {
        }

        public FieldIndexOutOfRangeException(string message, Exception innerException,int i, int j) : base(message, innerException)
        {
            SetUpParams(i, j);
        }

        public FieldIndexOutOfRangeException(string paramName, object actualValue, string message) : base(paramName, actualValue, message)
        {
        }

        protected FieldIndexOutOfRangeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
