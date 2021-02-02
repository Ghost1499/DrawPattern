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
        TableController tableController;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            tableController = new TableController(pictureBox);
            SetUpForm();

            
        }

        private void SetUpForm()
        {
            //ExtensionMethods.DoubleBuffered(pictureBox, true);
            settingsPanel.Location =new Point(pictureBox.Location.X +pictureBox.Width + pictureBox.Margin.Right+settingsPanel.Margin.Left,settingsPanel.Location.Y);
            settingsPanel.Width = this.Width-settingsPanel.Location.X-settingsPanel.Margin.Right;
            this.SetStyle(ControlStyles.UserPaint
                | ControlStyles.AllPaintingInWmPaint
                | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.ResizeRedraw, true);

            //saveFieldFileDialog.CreatePrompt = true;
            saveFieldFileDialog.OverwritePrompt = true;
            saveFieldFileDialog.DefaultExt = "txt";
            saveFieldFileDialog.AddExtension = true;
            saveFieldFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;

            //eventLog.
        }

        private void addColumnButton_Click(object sender, EventArgs e)
        {
            int value;
            if (int.TryParse(addColumnsTextbox.Text, out value))
                tableController.AddColumn(value);
            else
                tableController.AddColumn();
        }

        private void deleteColumnButton_Click(object sender, EventArgs e)
        {
            int value;
            if (int.TryParse(deleteColumnsTextbox.Text, out value))
                tableController.DeleteColumn(value);
            else
                tableController.DeleteColumn();


        }

        private void addRowButton_Click(object sender, EventArgs e)
        {
            int value;
            if (int.TryParse(addRowsTextbox.Text, out value))
                tableController.AddRow(value);
            else
                tableController.AddRow();

        }

        private void deleteRowButton_Click(object sender, EventArgs e)
        {
            int value;
            if (int.TryParse(deleteRowsTextbox.Text, out value))
                tableController.DeleteRow(value);
            else
                tableController.DeleteRow();

        }

        private void changeDGVCountButton_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    int columns, rows;
            //    if (int.TryParse(columnTextbox.Text, out columns) && int.TryParse(rowTextbox.Text, out rows))
            //    {
            //        dataGridViewController.SetColumns(columns);
            //        dataGridViewController.SetRows(rows);

            //    }
            //    else
            //    {
            //        throw new Exception();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Неверные значения размеров поля");
            //}
        }

        private void printToFileButton_Click(object sender, EventArgs e)
        {
            
            if (saveFieldFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFieldFileDialog.FileName;

            // сохраняем текст в файл
            tableController.SaveToFile(filename);
            MessageBox.Show("Файл сохранен");
        }
    }

    
}
