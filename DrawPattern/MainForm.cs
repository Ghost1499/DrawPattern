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
        DataGridViewBehaiviorController dataGridViewController;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            dataGridView = mainGridView;
            dataGridViewController = new DataGridViewBehaiviorController(dataGridView);
            SetUpForm();
        }

        private void SetUpForm()
        {
            ExtensionMethods.DoubleBuffered(dataGridView, true);
            settingsPanel.Location =new Point(dataGridView.Location.X +dataGridView.Width + dataGridView.Margin.Right+settingsPanel.Margin.Left,settingsPanel.Location.Y);
            settingsPanel.Width = this.Width-settingsPanel.Location.X-settingsPanel.Margin.Right;
        }

        private void addColumnButton_Click(object sender, EventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            // ваш код
            int value;
            if(int.TryParse( addColumnsTextbox.Text,out value))
                dataGridViewController.AddColumn(value);
            else
                dataGridViewController.AddColumn();
            watch.Stop();
            label1.Text = watch.ElapsedMilliseconds.ToString();
        }

        private void deleteColumnButton_Click(object sender, EventArgs e)
        {
            int value;
            if (int.TryParse(deleteColumnsTextbox.Text, out value))
                dataGridViewController.DeleteColumn(value);
            else
                dataGridViewController.DeleteColumn();


        }

        private void addRowButton_Click(object sender, EventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            // ваш код
            int value;
            if (int.TryParse(addRowsTextbox.Text, out value))
                dataGridViewController.AddRow(value);
            else
                dataGridViewController.AddRow();
            watch.Stop();
            label1.Text=watch.ElapsedMilliseconds.ToString();

        }

        private void deleteRowButton_Click(object sender, EventArgs e)
        {
            int value;
            if (int.TryParse(deleteRowsTextbox.Text, out value))
                dataGridViewController.DeleteRow(value);
            else
                dataGridViewController.DeleteRow();

        }

        private void changeDGVCountButton_Click(object sender, EventArgs e)
        {
            try
            {
                int columns, rows;
                if (int.TryParse(columnTextbox.Text, out columns) && int.TryParse(rowTextbox.Text, out rows))
                {
                    dataGridViewController.SetColumns(columns);
                    dataGridViewController.SetRows(rows);

                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Неверные значения размеров поля");
            }
        }
    }

    
}
