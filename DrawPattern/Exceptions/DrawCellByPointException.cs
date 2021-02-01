using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DrawPattern.Exceptions
{
    class DrawCellByPointException : FindCellByPointException
    {
        public Color Color { get; protected set; }
        public DrawCellByPointException(int x, int y,Color color) : base(x, y)
        {
            Color = color;
        }

        public DrawCellByPointException(string message, int x, int y,Color color, Exception inner) : base(message,x,y, inner)
        {
            Color = color;
        }

        public DrawCellByPointException(string message, int x, int y,Color color) : base(message, x, y)
        {
            Color = color;
        }

        protected DrawCellByPointException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
