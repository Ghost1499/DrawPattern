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
    public partial class Form1 : Form
    {
        Bitmap Bitmap;
        Graphics graphics;
        Point prev;
        int borderWidth;
        public Form1()
        {
            InitializeComponent();
            Bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //this.BackgroundImage = Bitmap;
            pictureBox1.Image = Bitmap;
            graphics = Graphics.FromImage(Bitmap);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);

            borderWidth = 1;
            int columnCount=50, rowCount = 50;
            double cellWidth, cellHeight;
            cellWidth = Bitmap.Width / columnCount;
            cellHeight = Bitmap.Height / rowCount;

            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseUp += pictureBox1_MouseUp;
            CreateGrid(cellWidth, cellHeight, columnCount, rowCount, borderWidth);
            //graphics = this.CreateGraphics();
        }


        private void CreateGrid(double cellWidth, double cellHeight, int columnCount, int rowCount, int borderWidth)
        {
            double x=0, y=0;
            int rx, ry;
            for (int i = 0; i <= columnCount+1; i++)
            {
                rx = (int)Math.Round(x);
                graphics.DrawLine(new Pen(Brushes.Black), rx, 0, rx, Bitmap.Height - 1);
                x += cellWidth;
            }
            for (int i = 0; i <= rowCount+1; i++)
            {
                ry = (int)Math.Round(y);
                graphics.DrawLine(new Pen(Brushes.Black),0, ry, Bitmap.Width - 1,ry);
                y += cellHeight;
            }
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox1.MouseMove += PictureBox1_MouseMove;
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Draw(e);
            pictureBox1.Invalidate();
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
                    if (prev != null && !prev.IsEmpty) {
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

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox1.MouseMove -= PictureBox1_MouseMove;
            prev = Point.Empty;
        }
    }
}
