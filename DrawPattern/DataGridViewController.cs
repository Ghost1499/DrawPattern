using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawPattern
{
    public class DataGridViewController
    {
        DataGridView dataGridView;
        PatternField patternField;
        public Color ActiveCellColor { get; set; }
        public Color InactiveCellColor { get; set; }
        public DataGridViewController(DataGridView dataGridView, int width = 5,int height=5)
        {        
            this.dataGridView = dataGridView ?? throw new ArgumentNullException(nameof(dataGridView));

            SetUp(width,height);

        }

        private void SetUp(int width, int heigth)
        {
            patternField = new PatternField(width,heigth);
            dataGridView.SelectionChanged += gridView_SelectionChanged;

            ActiveCellColor = Color.Green;
            InactiveCellColor = dataGridView.DefaultCellStyle.BackColor;

            this.dataGridView.SelectionChanged -= gridView_SelectionChanged;
            this.dataGridView.ClearSelection();
            this.dataGridView.SelectionChanged += gridView_SelectionChanged;

            for (int i = 0; i < width; i++)
            {
                dataGridView.Columns[i].Name = i.ToString();
            }
            for (int i = 0; i < heigth; i++)
            {
                dataGridView.Rows[i].HeaderCell.Value = i.ToString();
            }

        }

        private void gridView_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            //suppresss the SelectionChanged event
            this.dataGridView.SelectionChanged -= gridView_SelectionChanged;

            //grab the selectedIndex, if needed, for use in your custom code
            // do your custom code here
            if (dataGridView.CurrentCell.Style.BackColor != ActiveCellColor)
                dataGridView.CurrentCell.Style.BackColor = ActiveCellColor;
            else
            {
                dataGridView.CurrentCell.Style.BackColor = InactiveCellColor;
            }

            // finally, clear the selection & resume (reenable) the SelectionChanged event 
            this.dataGridView.ClearSelection();
            this.dataGridView.SelectionChanged += gridView_SelectionChanged;
        }
    }
}
