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
                nova.SetPixel((int)x, (int)y, barva);
            }
            /*nova.SetPixel((int)x1, (int)y1, Color.Green);
            nova.SetPixel((int)x2, (int)y2, Color.Green);
            nova.SetPixel((int)x3, (int)y3, Color.Green);
            nova.SetPixel((int)x4, (int)y4, Color.Green);*/
            return nova;
        }
        private Bitmap fergusonCurve(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4, Color barva)
        {
            Bitmap nova = new Bitmap(700, 700);
            double t, x, y, v1, v2;
            x = x1; y = y1;
            nova.SetPixel((int)x + 50, (int)y + 50, barva);

            for (t = 0; t <= 1; t += 0.005)
            {
                double tx1 = (x2 - x1), tx2 = (x4 - x3), ty1 = (y2 - y1), ty2 = (y4 - y3);
                v1 = ty1 / tx1;
                v2 = ty2 / tx2;
                x = (2 * Math.Pow(t, 3) - 3 * t * t + 1) * x1 + (-2 * Math.Pow(t, 3) + 3 * t * t) * x4 + (Math.Pow(t, 3) - 2 * t * t + t) * v1*x1 + (Math.Pow(t, 3) - t * t) * v2*x4;
                y = (2 * Math.Pow(t, 3) - 3 * t * t + 1) * y1 + (-2 * Math.Pow(t, 3) + 3 * t * t) * y4 + (Math.Pow(t, 3) - 2 * t * t + t) * v1*x1 + (Math.Pow(t, 3) - t * t) * v2*x4;
                nova.SetPixel((int)(x+0.5)+50, (int)(y+0.5)+50, barva);
            }
            nova.SetPixel((int)x1, (int)y1, Color.Green);
            nova.SetPixel((int)x2, (int)y2, Color.Green);
            nova.SetPixel((int)x3, (int)y3, Color.Green);
            nova.SetPixel((int)x4, (int)y4, Color.Green);
            return nova;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            Bitmap myBitmap = fergusonCurve(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text), Convert.ToDouble(textBox3.Text), Convert.ToDouble(textBox4.Text), Convert.ToDouble(textBox5.Text), Convert.ToDouble(textBox6.Text), Convert.ToDouble(textBox7.Text), Convert.ToDouble(textBox8.Text), Color.Black);
            g.DrawImage(myBitmap, 10, 70);
            /*Pen pen = new Pen(Color.Red, 1);
            Point point1 = new Point(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text)),
                    point2 = new Point(Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text)),
                    point3 = new Point(Convert.ToInt32(textBox5.Text), Convert.ToInt32(textBox6.Text)),
                    point4 = new Point(Convert.ToInt32(textBox7.Text), Convert.ToInt32(textBox8.Text));
            Point[] cpoint = {point1, point2, point3, point4};
            g.DrawCurve(pen, cpoint);*/

        }
    }
}
