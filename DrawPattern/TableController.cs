using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;
using DrawPattern.Exceptions;

namespace DrawPattern
{
    public class TableController
    {
        Field patternField;
        GraphicField canvasTable;
        PictureBox pictureBox;
        public Color ActiveCellColor { get; set; }
        public Color InactiveCellColor { get; set; }
        Dictionary<MouseButtons, Color> drawColorsDictionary;
        Dictionary<MouseButtons, char> selectCellCharDictionary;
        const int maxColumnsCount = 55;
        const int maxRowsCount = 55;
        const int minColumnsCount = 1;
        const int minRowsCount = 1;

        public char SelectChar { get; private set; }
        public char UnselectChar { get; private set; }

        public TableController(PictureBox pictureBox, int rows = 40, int columns = 40, char selectChar='0', char unselectChar='1')
        {
            this.pictureBox = pictureBox ?? throw new ArgumentNullException(nameof(pictureBox));
            SelectChar = selectChar;
            UnselectChar = unselectChar;
            selectCellCharDictionary = new Dictionary<MouseButtons, char>();
            selectCellCharDictionary[MouseButtons.Left] = SelectChar;
            selectCellCharDictionary[MouseButtons.Right] = UnselectChar;

            ActiveCellColor = Color.Green;
            InactiveCellColor = pictureBox.BackColor;
            drawColorsDictionary = new Dictionary<MouseButtons, Color>();
            drawColorsDictionary[MouseButtons.Left] = ActiveCellColor;
            drawColorsDictionary[MouseButtons.Right] = InactiveCellColor;


            canvasTable = new GraphicField(pictureBox, rows, columns);
            patternField = new Field(rows, columns, UnselectChar);

            //inputSimulator = new InputSimulator();
            SetUp();
        }

        private void SetUp()
        {
            pictureBox.MouseDown += MouseDown;
            pictureBox.MouseUp += MouseUp;

        }
        private void MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox.MouseMove += MouseMove;
            Select(e);
        }

        private void MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
               Select(e);
            }
            catch (Exception ex)
            {
                //throw;
            }
        }

        private void MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox.MouseMove -= MouseMove;
        }
        private void Select(MouseEventArgs e)
        {
            try
            {
                Point fieldLoc = canvasTable.DrawCellByPoint(e.X, e.Y, drawColorsDictionary[e.Button]);
                patternField.Set(fieldLoc.X, fieldLoc.Y, selectCellCharDictionary[e.Button]);

                pictureBox.Invalidate();

            }
            catch (DrawCellByPointException ex)
            {
                Log.Write(ex);
                throw;
            }
            catch (FindCellByPointException ex)
            {
                Log.Write(ex);
                throw;

                //MessageBox.Show("")
            }
            catch (BaseException ex)
            {
                Log.Write(ex);
                throw;

            }
            catch (Exception ex)
            {
                Log.Write(ex);
                throw;
            }
        }


        public void AddRow(int count=1)
        {
            if (false)
            {

            }
            try
            {
                canvasTable.AddRows(count);
                patternField.AddRows(count);
                pictureBox.Invalidate();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AddColumn(int count=1)
        {
            try
            {
                canvasTable.AddColumns(count);
                patternField.AddColumns(count);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteRow(int count=1)
        {
            try
            {
                canvasTable.DeleteRows(count);
                patternField.DeleteRows(count);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void DeleteColumn(int count=1)
        {
            try
            {
                canvasTable.DeleteColumns(count);
                patternField.DeleteColumns(count);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void SaveToFile(string filename)
        {
            try
            {
                patternField.PrintToFile(filename);
            }
            catch (BaseException ex)
            {
                Log.Write(ex);
                MessageBox.Show("Ошибка записи в файл");
            }
            catch(Exception ex)
            {
                Log.Write(ex);
                MessageBox.Show("Ошибка записи в файл");
            }
            
        }
    }
}
