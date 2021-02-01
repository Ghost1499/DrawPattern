using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawPattern
{
    public struct CanvasTableCell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool IsSelect { get; set; }
        public CanvasTableCell(int x=0, int y =0, int width =0, int height =0)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            IsSelect = false;
        }

        public bool IsPointInCell(int x, int y)
        {
            int isXInCell = IsPointXInCell(x);
            int isYInCell = IsPointYInCell(y);
            if (isXInCell==0 && isYInCell==0)
            {
                return true;
               
            }
            else
            {
                return false;
            }
        }

        public int IsPointXInCell(int x)
        {
            if (x >= X && x < X + Width )
            {
                return 0;

            }
            else if(x>= X + Width)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
        public int IsPointYInCell(int y)
        {
            if (y >= Y && y < Y + Height)
            {
                return 0;

            }
            else if (y >= Y + Height)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
}
