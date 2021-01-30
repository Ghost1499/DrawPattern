using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;
using DrawPattern.Exceptions;

namespace DrawPattern
{
    public partial class DataGridViewBehaiviorController
    {
        public int Width { get; set; }
        public int Height { get; set; }
        private int ColumnCount { get; set; }
        private int RowCount { get; set; }
        public int ColumnCountWithHeader { get => ColumnCount + 1; }
        public int RowCountWithHeader { get => RowCount + 1; }
        public int CellWidth { get; set; }
        public int CellHeight { get; set; }



        private void SetUpSize(int width, int heigth)
        {
            ColumnCount = width;
            RowCount = heigth;
            ChangeSize();
        }

        private void ChangeSize()
        {
            Width = dataGridView.Parent.Width / 2 - 100;
            Height = dataGridView.Parent.Height - dataGridView.Location.Y - dataGridView.Parent.Padding.Bottom - 40;
            CellWidth = Width / ColumnCountWithHeader;
            CellHeight = Height / RowCountWithHeader;
            if (CellWidth > CellHeight)
            {
                CellWidth = CellHeight;
            }
            else if (CellWidth < CellHeight)
            {
                CellHeight = CellWidth;
            }
            Width = CellWidth * ColumnCountWithHeader + 2;
            Height = CellHeight * RowCountWithHeader + 2;

            Resize();
        }


        private void Resize()
        {
            dataGridView.Width = Width;
            dataGridView.Height = Height;
            dataGridView.ColumnCount = ColumnCount;
            dataGridView.RowCount = RowCount;
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.Width = CellWidth;
            }
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                row.Height = CellHeight;
            }
            dataGridView.RowHeadersWidth = CellWidth;
            dataGridView.ColumnHeadersHeight = CellHeight;
            //if (CellHeight < dataGridView.Font.Height)
            //{
            //    dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView.Font.FontFamily, CellHeight-2);
            //    dataGridView.RowHeadersDefaultCellStyle.Font = new Font(dataGridView.Font.FontFamily, CellHeight);
            //}

            SetUpHeaders();
        }

        private void SetUpHeaders()
        {
            for (int i = 0; i < ColumnCount; i++)
            {
                dataGridView.Columns[i].Name = i.ToString();
            }
            for (int i = 0; i < RowCount; i++)
            {
                dataGridView.Rows[i].HeaderCell.Value = i.ToString();
            }
        }
        public void AddColumn(int count = 1)
        {
            try
            {
                ColumnCount += count;
                ChangeSize();
                patternField.AddColumns(count);

            }
            catch (BaseException ex)
            {
                Log.Write(ex);
                MessageBox.Show("Ошибка добавления столбцов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AddRow(int count = 1)
        {
            try
            {

                RowCount += count;
                ChangeSize();
                patternField.AddRows(count);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                MessageBox.Show("Ошибка добавления строк", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void DeleteColumn(int count = 1)
        {
            try
            {
                ColumnCount -= count;
                ChangeSize();
                patternField.DeleteColumns(count);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                MessageBox.Show("Ошибка удаления столбцов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeleteRow(int count = 1)
        {
            try
            {
                RowCount -= count;
                ChangeSize();
                patternField.DeleteRows(count);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                MessageBox.Show("Ошибка удаления строк", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SetColumns(int count)
        {
            if (count <= maxColumnsCount && count >= minColumnsCount)
            {
                ColumnCount = count;
                ChangeSize();
            }
            else
            {
                throw new Exception();
            }


        }
        public void SetRows(int count)
        {
            if (count <= maxRowsCount && count >= minRowsCount)
            {
                RowCount = count;
                ChangeSize();
            }
            else
            {
                throw new Exception();
            }

        }
        private void SetUpDataGridView()
        {

            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.RowHeadersDefaultCellStyle.BackColor = Color.Navy;
            dataGridView.RowHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView.Font, FontStyle.Bold);
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridView.GridColor = Color.Black;
            dataGridView.RowHeadersVisible = true;
            dataGridView.ColumnHeadersVisible = true;

            dataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView.MultiSelect = true;
        }



    }

    public static class ExtensionMethods
    {
        public static void DoubleBuffered(this DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }
    }
}
