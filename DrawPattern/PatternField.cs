using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawPattern
{
    public class PatternField
    {
        List<List<string>> field;

        public PatternField(int width, int height)
        {
            field = new List<List<string>>(height);
            for (int i = 0; i < height; i++)
            {
                field.Add( new List<string>(width));
            }
        }

    }
}
