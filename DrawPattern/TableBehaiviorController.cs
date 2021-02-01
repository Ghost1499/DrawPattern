using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;

namespace DrawPattern
{
    public partial class TableController
    {
        PatternField patternField;
        CanvasTable canvasTable;
        Point prev;
        public Color ActiveCellColor { get; set; }
        public Color InactiveCellColor { get; set; }
        Dictionary<MouseButtons, Color> drawColorsDictionary;
        const int maxColumnsCount = 55;
        const int maxRowsCount = 55;
        const int minColumnsCount = 1;
        const int minRowsCount = 1;

        public char SelectChar { get; private set; }
        public char UnselectChar { get; private set; }

        public TableController(PictureBox pictureBox, int rows = 20, int columns = 20, char selectChar='1', char unselectChar='.')
        {
            this.pictureBox = pictureBox ?? throw new ArgumentNullException(nameof(pictureBox));
            SelectChar = selectChar;
            UnselectChar = unselectChar;
            ActiveCellColor = Color.Green;
            InactiveCellColor = pictureBox.BackColor;
            prev = Point.Empty;

            canvasTable = new CanvasTable(pictureBox, rows, columns);
            patternField = new PatternField(rows, columns, UnselectChar);

            //inputSimulator = new InputSimulator();
            SetUpSize(rows,columns);
            SetUpCanvasControl();
            SetUp();
        }




        private void Select(int row, int column, bool isUnselect=false)
        {
            if (isUnselect)
            {
                GetCell(row, column).Style.BackColor = InactiveCellColor;
                patternField.Set(row, column, UnselectChar);
            }
            else
            {
                GetCell(row, column).Style.BackColor = ActiveCellColor;
                patternField.Set(row, column, SelectChar);
            }

        }
        private void Unselect(int row, int column)
        {
            Select(row, column, true);
        }

        private void SelectRow(int row, bool isUnselect=false)
        {
            for (int i = 0; i < pictureBox.Columns.Count; i++)
            {
                Select(row, i,isUnselect);

            }
        }
        private void SelectColumn(int column,bool isUnselect=false)
        {
            for (int i = 0; i < pictureBox.Rows.Count; i++)
            {
                Select(i, column,isUnselect);

            }
        }
        private void UnselectRow(int row, bool isUnselect = false)
        {
            SelectRow(row, true);
        }
        private void UnselectColumn(int column, bool isUnselect = false)
        {
            SelectColumn(column, true);
        }
        private void SelectAll(bool isUnselect=false)
        {
            for (int i = 0; i < pictureBox.Rows.Count; i++)
            {
                SelectRow(i,isUnselect);

            }
        }
        private void UnselectAll()
        {
            SelectAll(true);
        }


        private bool IsSelected(int row, int column)
        {
            if (GetCell(row,column).Style.BackColor == ActiveCellColor)
                return true;
            return false;
        }


        private void SetUp()
        {
            pictureBox.MouseDown += MouseDown;
            pictureBox.MouseUp += MouseUp;

        }
        private void MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox.MouseMove += MouseMove;
        }

        private void MouseMove(object sender, MouseEventArgs e)
        {
            Draw(e);
            pictureBox.Invalidate();
        }

        private void MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox.MouseMove -= MouseMove;
            prev = Point.Empty;
        }
        private void Draw(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //Bitmap.SetPixel(e.X, e.Y, Color.Green);
                int radius = 10;
                double dx = Math.Abs(e.X - prev.X);
                double dy = Math.Abs(e.Y - prev.Y);
                double dist = Math.Sqrt(dx * dx + dy * dy);
                int distLim = 10;
                bool fillInd = true;
                if (dist < distLim)
                {
                    graphics.FillEllipse(Brushes.Green, e.X - radius, e.Y - radius, radius * 2, radius * 2);
                    if (prev != null && !prev.IsEmpty && !fillInd)
                    {
                        graphics.DrawLine(new Pen(Brushes.Green, radius * 2), prev, e.Location);
                    }
                }
                else
                {
                    if (prev != null && !prev.IsEmpty)
                    {
                        graphics.DrawLine(new Pen(Brushes.Green, radius * 2), prev, e.Location);
                        fillInd = false;
                    }

                }
                prev = e.Location;
            }
            else if (e.Button == MouseButtons.Right)
            {
                Bitmap.SetPixel(e.X, e.Y, Color.White);

            }
        }


        private void CellMouseEnterSelect(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dataGridView = (DataGridView)sender;
                if(e.RowIndex>=0 && e.ColumnIndex>=0)
                {
                    bool isSelected = IsSelected(e.RowIndex, e.ColumnIndex);
                    if (!isSelected)
                    {
                        Select(e.RowIndex, e.ColumnIndex);

                    }
                }
            }
            catch
            {

            }
        }
        private void CellMouseEnterUnselect(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dataGridView = (DataGridView)sender;
                if (e.RowIndex >=0 && e.ColumnIndex >= 0)
                {
                    bool isSelected = IsSelected(e.RowIndex, e.ColumnIndex);
                    if (isSelected)
                    {
                        Unselect(e.RowIndex, e.ColumnIndex);
                    }
                }
            }
            catch
            {

            }
        }

        //private void MouseUp(object sender, MouseEventArgs e)
        //{
        //    StopSelectCells(sender, e);
        //}
        private void StopSelectCells(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                pictureBox.CellMouseEnter -= CellMouseEnterSelect;
            else if (e.Button == MouseButtons.Right)
            {
                pictureBox.CellMouseEnter -= CellMouseEnterUnselect;

            }
        }


        private void CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridView dataGridView = (DataGridView)sender;


                if (e.RowIndex < 0 && e.ColumnIndex < 0)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        SelectAll();
                    }
                    else if (e.Button == MouseButtons.Right)
                    {
                        UnselectAll();
                    }

                }
                else if (e.RowIndex < 0)
                {
                    int column = e.ColumnIndex;
                        if (e.Button == MouseButtons.Left)
                            SelectColumn(column);
                        else if (e.Button == MouseButtons.Right)
                            UnselectColumn(column);
                    
                }
                else if (e.ColumnIndex < 0)
                {
                    int row = e.RowIndex;
                    if (e.Button == MouseButtons.Left)
                        SelectRow(row);
                    else if (e.Button == MouseButtons.Right)
                        UnselectRow(row);
                }
                else
                {

                    if (e.Button == MouseButtons.Left)
                        dataGridView.CellMouseEnter += CellMouseEnterSelect;
                    else if (e.Button == MouseButtons.Right)
                    {
                        dataGridView.CellMouseEnter += CellMouseEnterUnselect;

                    }
                    bool isSelected = IsSelected(e.RowIndex, e.ColumnIndex);
                    if (e.Button == MouseButtons.Left && !isSelected)
                    {
                        Select(e.RowIndex, e.ColumnIndex);

                    }
                    else if (e.Button == MouseButtons.Right && isSelected)
                    {
                        Unselect(e.RowIndex, e.ColumnIndex);
                    }
                }
            }
            catch(Exception ex)
            {
                Log.Write(ex);

            }
        }

        

        public void SaveToFile(string filename)
        {
            patternField.PrintToFile(filename);
        }
    }
}
