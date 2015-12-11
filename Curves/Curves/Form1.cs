using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Curves
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            Bitmap myBitmap = bezierCurve(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text), Convert.ToDouble(textBox3.Text), Convert.ToDouble(textBox4.Text), Convert.ToDouble(textBox5.Text), Convert.ToDouble(textBox6.Text), Convert.ToDouble(textBox7.Text), Convert.ToDouble(textBox8.Text), Color.Black);
            g.DrawImage(myBitmap, 10, 70);
        }

        private Bitmap bezierCurve(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4, Color barva) 
        {
            Bitmap nova = new Bitmap(700, 700);
            double t, x, y;
            x = x1; y = y1;
            nova.SetPixel((int)x, (int)y, barva);
            for (t = 0; t <= 1; t += 0.005)
            {
                x = Math.Pow((1 - t), 3) * x1 + 3 * t * Math.Pow((1 - t), 2) * x2 + 3 * t * t * (1 - t) * x3 + Math.Pow(t, 3) * x4;
                y = Math.Pow((1 - t), 3) * y1 + 3 * t * Math.Pow((1 - t), 2) * y2 + 3 * t * t * (1 - t) * y3 + Math.Pow(t, 3) * y4;
                nova.SetPixel((int)x+50, (int)y+50, barva);
            }
            
            return nova;
        }
        private Bitmap fergusonCurve(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4, Color barva)
        {
            Bitmap nova = new Bitmap(700, 700);
            double t, x, y;
            x = x1; y = y1;
            double v1X = 3*(x2-x1), v1Y = 3*(y2-y1);
            double v2X = 3*(x4-x3), v2Y = 3*(y4-y3);
            nova.SetPixel((int)x + 50, (int)y + 50, barva);

            for (t = 0; t <= 1; t += 0.005)
            {
                x = (2 * Math.Pow(t, 3) - 3 * t * t + 1) * x1 + (-2 * Math.Pow(t, 3) + 3 * t * t) * x4 + (Math.Pow(t, 3) - 2 * t * t + t) * v1X + (Math.Pow(t, 3) - t * t) * v2X;
                y = (2 * Math.Pow(t, 3) - 3 * t * t + 1) * y1 + (-2 * Math.Pow(t, 3) + 3 * t * t) * y4 + (Math.Pow(t, 3) - 2 * t * t + t) * v1Y + (Math.Pow(t, 3) - t * t) * v2Y;
                nova.SetPixel((int)(x)+50, (int)(y)+50, barva);
            }
            nova.SetPixel((int)x1 + 50, (int)y1 + 50, Color.Brown);
            nova.SetPixel((int)x2 + 50, (int)y2 + 50, Color.Brown);
            nova.SetPixel((int)x3 + 50, (int)y3 + 50, Color.Brown);
            nova.SetPixel((int)x4 + 50, (int)y4 + 50, Color.Brown);

            return nova;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            Bitmap myBitmap = fergusonCurve(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text), Convert.ToDouble(textBox3.Text), Convert.ToDouble(textBox4.Text), Convert.ToDouble(textBox5.Text), Convert.ToDouble(textBox6.Text), Convert.ToDouble(textBox7.Text), Convert.ToDouble(textBox8.Text), Color.Black);           
            g.DrawImage(myBitmap, 10, 70);
            Pen pen = new Pen(Color.Red, 1);
            g.DrawBezier(pen, new Point(100, 200), new Point(70, 50), new Point(260, 55), new Point(200, 200));
            
        }
    }
}
