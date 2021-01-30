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
    public partial class DataGridViewBehaiviorController
    {
        DataGridView dataGridView;
        PatternField patternField;
        public Color ActiveCellColor { get; set; }
        public Color InactiveCellColor { get; set; }
        const int maxColumnsCount = 30;
        const int maxRowsCount = 30;
        const int minColumnsCount = 1;
        const int minRowsCount = 1;

        public DataGridViewBehaiviorController(DataGridView dataGridView, int width = 5, int height = 5)
        {
            this.dataGridView = dataGridView ?? throw new ArgumentNullException(nameof(dataGridView));
            //inputSimulator = new InputSimulator();
            SetUpDataGridView();
            SetUpSize(width,height);
            SetUp(width, height);
        }


        private DataGridViewCell GetCell(int row,int column)
        {
            return dataGridView[column,row];
        }

        private void Select(int row, int column, bool isUnselect=false)
        {
            if(isUnselect)
                GetCell(row, column).Style.BackColor = InactiveCellColor;
            else
                GetCell(row, column).Style.BackColor = ActiveCellColor;
        }
        private void Unselect(int row, int column)
        {
            Select(row, column, true);
        }

        private void SelectRow(int row, bool isUnselect=false)
        {
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                Select(row, i,isUnselect);

            }
        }
        private void SelectColumn(int column,bool isUnselect=false)
        {
            for (int i = 0; i < dataGridView.Rows.Count; i++)
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
            for (int i = 0; i < dataGridView.Rows.Count; i++)
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


        private void SetUp(int width, int heigth)
        {
            patternField = new PatternField(width, heigth);
            if(dataGridView.CurrentCell!=null)
                dataGridView.CurrentCell.Selected = false;
            dataGridView.MultiSelect = false;
            //dataGridView.GotFocus += DataGridView_GotFocus;
            //dataGridView.LostFocus += DataGridView_LostFocus;


            dataGridView.CellMouseClick += cellMouseClick;
            dataGridView.SelectionChanged += selectionChanged;

            ActiveCellColor = Color.Green;
            InactiveCellColor = dataGridView.DefaultCellStyle.BackColor;



        }

        //public void ControlKeyDown()
        //{
        //    inputSimulator.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.CONTROL);

        //}
        //public void ControlKeyUp()
        //{
        //    inputSimulator.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.CONTROL);
        //}

        //private void DataGridView_GotFocus(object sender, EventArgs e)
        //{
        //    ControlKeyDown();
        //}


        //private void DataGridView_LostFocus(object sender, EventArgs e)
        //{
        //    ControlKeyUp();

        //}

        private void cellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
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
            catch
            {

            }
        }

        private void selectionChanged(object sender, EventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            //suppresss the SelectionChanged event
            this.dataGridView.SelectionChanged -= selectionChanged;

            //grab the selectedIndex, if needed, for use in your custom code
            // do your custom code here

            // finally, clear the selection & resume (reenable) the SelectionChanged event 
            this.dataGridView.ClearSelection();
            this.dataGridView.SelectionChanged += selectionChanged;
        }
    }
}
