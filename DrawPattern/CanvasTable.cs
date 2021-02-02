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


        public Color DefaultColor { get; set;}
        public int BorderWidth { get; set; }

        public CanvasTable(PictureBox pictureBox, int rows, int columns, int borderWidth=1)
        {
            this.pictureBox = pictureBox ?? throw new ArgumentNullException(nameof(pictureBox));
            field = new List<List<CanvasTableCell>>();


            RowCount = rows;
            ColumnCount = columns;
            BorderWidth = borderWidth;

            //setUp();
            pictureBox.Anchor = AnchorStyles.Right|AnchorStyles.Left | AnchorStyles.Top |AnchorStyles.Bottom;
            DefaultColor = pictureBox.BackColor;

            Redraw();

        }



        private void changeSize()
        {
            WidthD = pictureBox.Parent.Width/2 - pictureBox.Location.X-40;
            HeightD = pictureBox.Parent.Height - pictureBox.Location.Y - pictureBox.Parent.Padding.Bottom - 60;

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
            Width = CellWidth * ColumnCount+ BorderWidth;
            Height = CellHeight * RowCount+BorderWidth;

            resize();
        }

        private void resize()
        {
            pictureBox.Width = Width;
            pictureBox.Height = Height;

            bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            graphics = Graphics.FromImage(bitmap);
            pictureBox.Image = bitmap;
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;


        }

        private void createGrid()
        {
            try
            {
                graphics.Clear(pictureBox.BackColor);

                int x = 0, y = 0;
                CanvasTableCell cell;
                for (int i = 0; i < RowCount; i++)
                {
                    if(field.Count <RowCount )
                        field.Add(new List<CanvasTableCell>());
                    for (int j = 0; j < ColumnCount; j++)
                    {
                        if(field[i].Count<j+1)
                            field[i].Add(new CanvasTableCell(BorderWidth,DefaultColor,x, y, CellWidth, CellHeight));
                        else
                        {
                            cell = field[i][j];
                            cell.X = x;
                            cell.Y = y;
                            cell.Width = CellWidth;
                            cell.Height = CellHeight;
                        }
                        x += CellWidth;
                    }
                    x = 0;
                    y += CellHeight;
                }

                for (int i = 0; i < ColumnCount; i++)
                {
                    graphics.DrawLine(new Pen(Brushes.Black), field[0][i].X, 0, field[0][i].X, bitmap.Height - 1);
                }
                graphics.DrawLine(new Pen(Brushes.Black), bitmap.Width-1, 0, bitmap.Width - 1, bitmap.Height - 1);

                for (int i = 0; i < RowCount; i++)
                {
                    graphics.DrawLine(new Pen(Brushes.Black), 0, field[i][0].Y, bitmap.Width - 1, field[i][0].Y);
                }
                graphics.DrawLine(new Pen(Brushes.Black), 0, bitmap.Height - 1, bitmap.Width - 1, bitmap.Height - 1);

            }
            catch (Exception ex)
            {
                throw new BaseException("Ошибка создания сетки поля", ex);
            }
        }
        
        private void drawAllCells()
        {
            foreach (var list in field)
            {
                foreach (var cell in list)
                {
                    cell.FillCell(graphics,cell.CurrentColor);
                }
            }
        }

        public CanvasTableCell this[int i,int j]
        {
            get
            {
                return field[i][j];
            }
        }

        public CanvasTableCell FindCellByPoint(int x, int y, out int i, out int j)
        {
            try
            {
                j = x/CellWidth;
                i = y/CellHeight;
                int isXInCell;
                int isYInCell;
                do
                {
                    isXInCell = this[i,j].IsPointXInCell(x);
                    if (isXInCell > 0)
                        j++;
                    else if (isXInCell < 0)
                        j--;
                    
                }
                while (isXInCell != 0 && j < ColumnCount && j>=0);
                if (isXInCell != 0)
                {
                    throw new FindCellByPointException("Не найдена ячейка, в которой находится данная точка", x, y);
                }
                do
                {
                    isYInCell = this[i,j].IsPointYInCell(y);
                    if (isYInCell > 0)
                        i++;
                    else if (isYInCell < 0)
                        i--;
                }
                while (isYInCell != 0 && i < RowCount && i>=0);
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

        public Point DrawCellByPoint(int x, int y,Color color)
        {
            try
            {
                int i, j;
                CanvasTableCell cell = FindCellByPoint(x, y,out i,out j);
                cell.FillCell(graphics, color);
                return new Point(i, j);
            }
            catch(Exception ex)
            {
                throw new DrawCellByPointException("Закрасить ячейку не удалось", x, y,color,ex);
            }

        }


        private void Redraw()
        {
            changeSize();
            createGrid();
            drawAllCells();
        }
        public void AddColumns(int count)
        {
            try
            {
                ColumnCount+=count;
                Redraw();
            }
            catch (Exception ex)
            {
                throw new BaseException("Неудалось добавить столбцы", ex);
            }
        }
        public void AddRows(int count)
        {
            try
            {
                RowCount += count;
                Redraw();
            }
            catch (Exception ex)
            {
                throw new BaseException("Неудалось добавить строчки", ex);
            }
        }
        public void DeleteColumns(int count)
        {
            if (ColumnCount - count < 1)
            {
                throw new ChangeDimensionException("Количество удаляемых столбцов " +
                    "больше или равно количеству столбцов таблицы", nameof(count));
            }
            try
            {
                ColumnCount -= count;
                Redraw();
            }
            catch (Exception ex)
            {
                throw new BaseException("Неудалось удалить столбцы", ex);
            }
        }

        public void DeleteRows(int count)
        {
            if (RowCount - count < 1)
            {
                throw new ChangeDimensionException("Количество удаляемых строк " +
                    "больше или равно количеству столбцов таблицы", nameof(count));
            }
            try
            {
                RowCount -= count;
                Redraw();
            }
            catch (Exception ex)
            {
                throw new BaseException("Неудалось удалить строки", ex);
            }
        }

    }
}
