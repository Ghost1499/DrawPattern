using DrawPattern.Exceptions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawPattern
{
    public class GraphicFieldCell:FieldCell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Color DefaultColor { get; set; }
        public Color CurrentColor { get; set; }
        //public bool IsSelect { get; set; }
        public int BorderWidth { get; set; }
        public GraphicFieldCell(int borderWidth, Color defaultColor,char defaultChar, int x=-1, int y =-1, int width =0, int height =0 ):base(defaultChar)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            BorderWidth = borderWidth;
            //IsSelect = false;
            DefaultColor = defaultColor;
            CurrentColor = DefaultColor;
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

        public Rectangle GetRectangle()
        {
            return new Rectangle(X, Y, Width, Height);
        }
        public Rectangle GetRectangleForFill()
        {
            return new Rectangle(X+BorderWidth, Y+BorderWidth, Width-1-BorderWidth, Height-1-BorderWidth);
        }
        public Rectangle GetRectangleForFillSelect()
        {
            Rectangle rectangle = GetRectangleForFill();
            rectangle.X += 1;
            rectangle.Y += 1;
            rectangle.Width -= 2;
            rectangle.Height -= 2;
            return rectangle;
        }

        protected new void Select(char c)
        {
            base.Select(c);
        }

        public void Select(char c, Graphics graphics, Color color)
        {
            Select(c);
            if ( X>= 0 && Y >= 0 && Width > 0 && Height > 0)
            {
                if (CurrentColor != color)
                {
                    Rectangle rectangle;
                    if (color == DefaultColor)
                        rectangle = GetRectangleForFill();
                    else
                        rectangle = GetRectangleForFillSelect();
                    graphics.FillRectangle(new SolidBrush(color), rectangle);
                    CurrentColor = color;
                }
            }
            else
            {
                throw new BaseException("Невозможно нарисовать ячейку." +
                    " Поля экземпляра имеют недопустимые значения");
            }
        }
    }
}
