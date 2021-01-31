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
        public Form1()
        {
            InitializeComponent();
            Bitmap = new Bitmap(this.Width, this.Height);
            this.BackgroundImage = Bitmap;
            graphics = Graphics.FromImage(Bitmap);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);

            //graphics = this.CreateGraphics();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            this.MouseMove += PictureBox1_MouseMove;
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Draw(e);
            Invalidate();
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
            this.MouseMove -= PictureBox1_MouseMove;
            prev = Point.Empty;
        }
    }
}
