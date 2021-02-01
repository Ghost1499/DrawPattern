using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using DrawPattern.Exceptions;

namespace DrawPattern
{
    public class CanvasTable
    {

        PictureBox pictureBox;
        Bitmap bitmap;
        Graphics graphics;
        List<List<CanvasTableCell>> field;

        public double WidthD { get; set; }
        public int Width { get; set; }
        public double HeightD { get; set; }
        public int Height { get; set; }
        private int RowCount { get; set; }
        private int ColumnCount { get; set; }
        public double CellWidthD { get; set; }
        public int CellWidth { get => (int)Math.Floor(CellWidthD); }
        public double CellHeightD { get; set; }
        public int CellHeight { get => (int)Math.Floor(CellHeightD); }


        public int BorderWidth { get; set; }

        public CanvasTable(PictureBox pictureBox, int rows, int columns)
        {
            this.pictureBox = pictureBox ?? throw new ArgumentNullException(nameof(pictureBox));
            field = new List<List<CanvasTableCell>>();

            bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            graphics = Graphics.FromImage(bitmap);

            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            RowCount = rows;
            ColumnCount = columns;
            BorderWidth = 1;

            setUp();
        }

        private void setUp()
        {
            pictureBox.Image = bitmap;
            changeSize();


        }


        private void changeSize()
        {
            WidthD = pictureBox.Parent.Width / 2 - pictureBox.Location.X;
            HeightD = pictureBox.Parent.Height - pictureBox.Location.Y - pictureBox.Parent.Padding.Bottom - 40;

            CellWidthD = WidthD / ColumnCount;
            CellHeightD = HeightD / RowCount;
            if (CellWidthD > CellHeightD)
            {
                CellWidthD = CellHeightD;
            }
            else if (CellWidthD < CellHeightD)
            {
                CellHeightD = CellWidthD;
            }
            Width = CellWidth * ColumnCount;
            Height = CellHeight * RowCount;

            resize();
        }

        private void resize()
        {
            pictureBox.Width = Width;
            pictureBox.Height = Height;
            createGrid();
        }

        private void createGrid()
        {
            try
            {
                graphics.Clear(pictureBox.BackColor);

                int x = 0, y = 0;
                for (int i = 0; i < RowCount; i++)
                {
                    field.Add(new List<CanvasTableCell>());
                    for (int j = 0; j < ColumnCount; j++)
                    {
                        field[i].Add(new CanvasTableCell(x, y, CellWidth, CellHeight));
                        x += CellWidth;
                    }
                    y += CellHeight;
                }

                for (int i = 0; i < ColumnCount; i++)
                {
                    graphics.DrawLine(new Pen(Brushes.Black), field[0][i].X, 0, field[0][i].X, bitmap.Height - 1);
                }
                for (int i = 0; i < ColumnCount; i++)
                {
                    graphics.DrawLine(new Pen(Brushes.Black), 0, field[i][0].Y, bitmap.Width - 1, field[i][0].Y);
                }
            }
            catch (Exception ex)
            {
                throw new BaseException("Ошибка создания сетки поля", ex);
            }
        }
        
        public CanvasTableCell this[int i,int j]
        {
            get
            {
                return field[i][j];
            }
        }

        public CanvasTableCell FindCellByPoint(int x, int y)
        {
            try
            {
                int i = Width / x;
                int j = Height / y;
                int isXInCell;
                int isYInCell = this[i,j].IsPointYInCell(y);
                do
                {
                    isXInCell = this[i,j].IsPointXInCell(x);
                    i++;
                }
                while (isXInCell == 0 || i >= ColumnCount);
                if (isXInCell != 0)
                {
                    throw new FindCellByPointException("Не найдена ячейка, в которой находится данная точка", x, y);
                }
                do
                {
                    isYInCell = this[i,j].IsPointYInCell(y);
                    j++;
                }
                while (isYInCell == 0 || i >= RowCount);
                if (isYInCell != 0)
                {
                    throw new FindCellByPointException("Не найдена ячейка, в которой находится данная точка", x, y);
                }

                return this[i,j];
            }
            catch 
            {

                throw;
            }
        }

        public void DrawCellByPoint(int x, int y,Color color)
        {
            try
            {
                CanvasTableCell canvasTableCell = FindCellByPoint(x, y);
            }
            catch(FindCellByPointException ex)
            {
                throw new DrawCellByPointException("Закрасить ячейку не удалось", x, y,color,ex);
            }
        }
    }
}
