using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DrawPattern.Exceptions
{
    class FindCellByPointException : BaseException
    {
        public int X { get; protected set; }
        public int Y { get; protected set; }
        public FindCellByPointException(int x, int y)
        {
            SetUp(x, y);
        }
        private void SetUp(int x, int y)
        {
            X = x;
            Y = y;
        }
        public FindCellByPointException(string message, int x, int y) : base(message)
        {
            SetUp(x, y);
        }

        public FindCellByPointException(string message, int x, int y,Exception inner) : base(message, inner)
        {
            SetUp(x, y);
        }

        protected FindCellByPointException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
