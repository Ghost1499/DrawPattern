using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawPattern
{
    public partial class MainForm : Form
    {
        DataGridView dataGridView;
        DataGridViewController dataGridViewController;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SetUpDataGridView();
            dataGridViewController = new DataGridViewController(dataGridView);
        }

        private void SetUpDataGridView()
        {
            dataGridView = mainGridView;

            dataGridView.ColumnCount = 5;
            dataGridView.RowCount = 5;
            int columnCount = 5, rowCount = 5;
            int width = this.Width * 3 / 4;
            int heigth = this.Height*3/4 ;
            int cellWidth = width / (columnCount + 1);
            int cellHeigth = heigth / (rowCount+ 1);
            if (cellWidth > cellHeigth)
            {
                cellWidth = cellHeigth;
            }
            else if (cellWidth < cellHeigth)
            {
                cellHeigth = cellWidth;
            }
            width = cellWidth * (columnCount + 1)+2;
            heigth = cellHeigth * (rowCount + 1)+2;
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.Width = cellWidth;
            }
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                row.Height= cellHeigth;
            }

            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView.RowHeadersWidth = cellWidth;
            dataGridView.ColumnHeadersHeight = cellHeigth;
            dataGridView.Width = width;
            dataGridView.Height = heigth;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            //dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView.Font, FontStyle.Bold);
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridView.GridColor = Color.Black;
            dataGridView.RowHeadersVisible = true;
            dataGridView.ColumnHeadersVisible = true;

            dataGridView.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            dataGridView.MultiSelect = true;
        }


    }
}
