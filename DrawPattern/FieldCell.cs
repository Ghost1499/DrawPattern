using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawPattern
{
    public class FieldCell
    {
        public char DefaultChar { get; set; }
        public char CurrentChar { get; set; }
        public FieldCell(char defaultChar)
        {
            SetUp(defaultChar);
        }

        protected virtual void SetUp(char defaultChar)
        {
            DefaultChar = defaultChar;
            CurrentChar = DefaultChar;
        }

        public virtual void Select(char c)
        {
            CurrentChar = c;
        }


    }
}
