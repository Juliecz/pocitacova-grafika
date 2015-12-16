using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DDA_Bres
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            Bitmap myBitmap = new Bitmap(1500, 1500);

            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "") {
                LineDDA(myBitmap, Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text));
                g.DrawImage(myBitmap, 10, 50);
            }

            LineDDA(myBitmap, 10, -50, 210, -50);
            LineDDA(myBitmap, 10, -50, 10, 20);
            LineDDA(myBitmap, 210, -50, 10, 20);
            LineDDA(myBitmap, 10, 20, 210, 20);
            LineDDA(myBitmap, 10, 20, 210, -50);
            LineDDA(myBitmap, 210, -50, 210, 20);
            LineDDA(myBitmap, 10, -50, 110, -120);
            LineDDA(myBitmap, 110, -120, 210, -50);
            g.DrawImage(myBitmap, 10, 50);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            Bitmap myBitmap = new Bitmap(1500, 1500);
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                LineBres(myBitmap, Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text));
                g.DrawImage(myBitmap, 10, 50);
            }
            LineBres(myBitmap, 200, 0, 400, 0);
            LineBres(myBitmap, 200, 0, 200, 70);
            LineBres(myBitmap, 400, 0, 200, 70);
            LineBres(myBitmap, 200, 70, 400, 70);
            LineBres(myBitmap, 200, 70, 400, 0);
            LineBres(myBitmap, 400, 0, 400, 70);
            LineBres(myBitmap, 200, 0, 300, -70);
            LineBres(myBitmap, 300, -70, 400, 0);
            g.DrawImage(myBitmap, 10, 50);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();

            Bitmap myBitmap = new Bitmap(1500, 1500);
            if (textBox1.Text != "" && textBox2.Text != "" && textBox5.Text != "")
            {
                CircleDDA(myBitmap, Convert.ToInt32(textBox1.Text) + 100, Convert.ToInt32(textBox2.Text) + 100, Convert.ToInt32(textBox5.Text), Color.Black);
                g.DrawImage(myBitmap, 10, 50);
            }
            else if (textBox1.Text == "" && textBox2.Text == "" && textBox5.Text != "")
            {
                CircleDDA(myBitmap, 100, 100, Convert.ToInt32(textBox5.Text), Color.Black);
                g.DrawImage(myBitmap, 10, 50);
            }
            CircleDDA(myBitmap, 190, 200, 20, Color.Black);
            CircleDDA(myBitmap, 300, 180, 30, Color.Black);
            g.DrawImage(myBitmap, 10, 50);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            Bitmap myBitmap = new Bitmap(1500, 1500);
            if (textBox1.Text != "" && textBox2.Text != "" && textBox5.Text != "")
            {
                CircleBres(myBitmap, Convert.ToInt32(textBox1.Text) + 100, Convert.ToInt32(textBox2.Text) + 100, 0, Convert.ToInt32(textBox5.Text), Color.Black);
                g.DrawImage(myBitmap, 10, 50);
            }
            else if (textBox1.Text == "" && textBox2.Text == "" && textBox5.Text != "")
            {
                CircleBres(myBitmap, 100, 100, 0, Convert.ToInt32(textBox5.Text), Color.Black);
                g.DrawImage(myBitmap, 10, 50);
            }
            CircleBres(myBitmap, 190, 200, 0, 40, Color.Black);
            CircleBres(myBitmap, 300, 180, 0, 50, Color.Black);
            g.DrawImage(myBitmap, 10, 50);
        } 

        private Bitmap LineDDA(Bitmap nova, int x1, int y1, int x2, int y2)
        {
            if (x1 < 0) x1 = Math.Abs(x1);
            if (x2 < 0) x2 = Math.Abs(x2);
            if (x1 > x2) { int a = x1; x1 = x2; x2 = a;  }
            float dy = (y2 - y1), dx = (x2 - x1);
            float m = dy / dx;
            m = Math.Abs(m);
            if (m > 1) m = Math.Abs(dx / dy);
            nova.SetPixel(x1, y1 + nova.Height / 6, Color.Black);
            
            if (Math.Abs(dy)==Math.Abs(dx)) {
                while (x1 < x2)
                {
                    if (y2 > 0)
                    {
                        y1++;
                    }
                    else if (y2 < 0)
                    {
                        y1--;
                    }
                    x1++;
                    nova.SetPixel(x1, y1 + nova.Height / 6, Color.Black);
                }
            }
            else if (Math.Abs(dy) > Math.Abs(dx) && m > 0)
            {
                float x = x1;
                if (y1 > y2) {
                    while (y2 < y1)
                    {
                        y1--;
                        x += m;
                        nova.SetPixel(Convert.ToInt32(Math.Round(x)), y1 + nova.Height / 6, Color.Black);
                    }
                }
                else if (y1 < y2) {
                    while (y1 < y2)
                    {
                        y1++;
                        x += m;
                        nova.SetPixel(Convert.ToInt32(Math.Round(x)), y1 + nova.Height / 6, Color.Black);
                    }
                }
            }
            else if (Math.Abs(dy)<Math.Abs(dx))
            {
                float y = y1;
                while (x1 < x2)
                {
                    x1++;
                    if (y2 < y1) { y -= m; }
                    else if (y2 > y1) { y += m; }
                    nova.SetPixel(x1, Convert.ToInt32(Math.Round(y)) + nova.Height / 6, Color.Black);
                }
            }
            else if (dx==0) {
                if (y1 < y2)
                {
                    while (y1 < y2)
                    {
                        y1++;
                        nova.SetPixel(x1, y1 + nova.Height / 6, Color.Black);
                    }
                }
                else {
                    while (y2 < y1) {
                        y1--;
                        nova.SetPixel(x1, y1 + nova.Height / 6, Color.Black);
                    }
                }
            }

            return nova;
        }

        private Bitmap LineBres(Bitmap nova, int x1, int y1, int x2, int y2)
        {
            if (x1 > x2) { int a = x1; x1 = x2; x2 = a; } 
            int dx = (x2 - x1), dy = (Math.Abs(y2) - y1);
            if (Math.Abs(dy) < dx) //osa x
            {
                int d = 2 * Math.Abs(dy) - dx;
                int inc1 = 2 * Math.Abs(dy), inc2 = 2 * (Math.Abs(dy) - dx);
                nova.SetPixel(x1, y1 + nova.Height / 6, Color.Black);
                while (x1 < x2)
                {
                    if (d <= 0) d += inc1;
                    else
                    {
                        d += inc2;
                        if (y2 > y1) { y1++; }
                        else if (y2 < y1) { y1--; }
                    }
                    x1++;
                    nova.SetPixel(x1, y1 + nova.Height / 6, Color.Black);
                }
            }
            else if (dx < dy) //osa y
            {
                int d = 2 * dx - dy;
                int inc1 = 2 * dx, inc2 = 2 * (dx - dy);
                nova.SetPixel(x1, y1 + nova.Height / 6, Color.Black);
                if (y1 < y2)
                {
                    while (y1 < y2)
                    {
                        if (d <= 0) d += inc1;
                        else
                        {
                            d += inc2;
                            x1++;
                        }
                        y1++;
                        nova.SetPixel(x1, y1 + nova.Height / 6, Color.Black);
                    }
                }
                else if (y1 > y2) {
                    while (y2 < y1)
                    {
                        if (d <= 0) d += inc1;
                        else
                        {
                            d += inc2;
                            x1++;
                        }
                        y1--;
                        nova.SetPixel(x1, y1 + nova.Height / 6, Color.Black);
                    }
                }
            }
            else if (Math.Abs(dy) == Math.Abs(dx))
            {
                while (x1 < x2) {
                    if (y1 > y2) { y1--; }
                    else if (y1 < y2) { y1++; }
                    x1++;
                    nova.SetPixel(x1, y1 + nova.Height / 6, Color.Black);
                }
            }
            return nova;
        }

        private Bitmap CircleDDA(Bitmap btm, double xx, double yy, int r, Color color)
        {
            double v, x1, y1, x2, y2, startx, starty, a;
            int i;

            x1 = r * Math.Cos(0);
            y1 = r * Math.Sin(0);
            startx = x1;
            starty = y1;

            i = 0;
            v = Math.Pow((double)2, (double)i);
            while (v < r)
            {
                v = Math.Pow((double)2, (double)i);
                i++;
            }
            a = 1 / Math.Pow(2, i - 1);
            x2 = x1 + y1 * a;
            y2 = y1 - a * x2;
            btm.SetPixel((int)(xx + x2), (int)(yy + y2), color);
            while ((y2 - starty) < a || (startx - x1) > a)
            {
                x1 = x2;
                y1 = y2;
                x2 = x1 + y1 * a;
                y2 = y1 - a * x2;
                btm.SetPixel((int)(xx + x2), (int)(yy + y2), color);
            }
            return btm;
        }

        private Bitmap CircleBres(Bitmap btm, int x, int y, int a, int r, Color color) 
        {
            //Bitmap btm = new Bitmap(1500, 1500);
            int x1 = a, y1 = r;
            int p = 1 - r;
            btm = CirclePoints(btm, x1, y1, x, y, color);
            while (x1 < y1)
            {
                x1++;
                if (p < 0)
                {
                    p += 2 * x1 + 3;
                }
                else
                {
                    y1--;
                    p += 2 * (x1 - y1) + 5;
                }
                btm = CirclePoints(btm, x1, y1, x, y, color);
            }
            return btm;
        }

        private Bitmap CirclePoints(Bitmap btm, int x, int y, int x1, int y1, Color color)
        {
            
            btm.SetPixel(x1 + x, y1 + y, color);
            btm.SetPixel(x1 - x, y1 + y, color);
            btm.SetPixel(x1 + x, y1 - y, color);
            btm.SetPixel(x1 - x, y1 - y, color);
            btm.SetPixel(x1 + y, y1 + x, color);
            btm.SetPixel(x1 - y, y1 + x, color);
            btm.SetPixel(x1 + y, y1 - x, color);
            btm.SetPixel(x1 - y, y1 - x, color);
            return btm;
        }
    }
}
