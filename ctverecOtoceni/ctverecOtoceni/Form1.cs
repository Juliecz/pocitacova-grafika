using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ctverecOtoceni
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        PointF[] point = { new PointF(50, 50), new PointF(50, 250), new PointF(250, 250), new PointF(250, 50) };
        Pen pen = new Pen(Brushes.Black);

        private void Form1_Load(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            Bitmap myBitmap = new Bitmap(300, 300);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            for (int i = 0; i < 4; i++)
            {
                if (i == 3) { g.DrawLine(pen, point[i], point[0]); }
                else { g.DrawLine(pen, point[i], point[i + 1]); }
            }
            Brush b = (Brush)Brushes.Black;
            g.FillRectangle(b, 150, 150, 1, 1);
            PointF[] p = new PointF[4];
            int alpha = 30;
            p = otocit(alpha, pen, g);
            
        }
        private PointF[] otocit(int alpha, Pen pen, Graphics g)
        {
            PointF[] p = new PointF[4];
            PointF center = new PointF(150, 150);
            PointF tempP = new PointF(150, 150);
            for (int i = 0; i < 4; i++)
            {
                tempP.X = point[i].X - center.X;
                tempP.Y = point[i].Y - center.Y;

                p[i].X = (float)(tempP.X * Math.Cos(alpha) - tempP.Y * Math.Sin(alpha));
                p[i].Y = (float)(tempP.X * Math.Sin(alpha) + tempP.Y * Math.Cos(alpha));
                point[i].X = p[i].X + center.X;
                point[i].Y = p[i].Y + center.Y;
                
            }
            return p;
        }
    }
}
