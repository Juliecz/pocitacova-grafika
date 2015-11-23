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
            //Bitmap myBitmap = LineDDA(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text));
            //g.DrawImage(myBitmap, 10, 50);
            /*Bitmap myBitmap0 = LineDDA(0, 0, 200, 0);
            Bitmap myBitmap2 = LineDDA(0, 0, 0, 70);
            g.DrawImage(myBitmap0, 10, 50);
            g.DrawImage(myBitmap2, 10, 50);
            Bitmap myBitmap3 = LineDDA(200, 0, 0, 70);
            Bitmap myBitmap4 = LineDDA(0, 70, 200, 70);
            g.DrawImage(myBitmap3, 10, 50);
            g.DrawImage(myBitmap4, 10, 50);
            Bitmap myBitmap5 = LineDDA(0, 70, 200, 0);
            g.DrawImage(myBitmap5, 10, 50);
            Bitmap myBitmap6 = LineDDA(200, 0, 200, 70);
            g.DrawImage(myBitmap6, 10, 50);
            Bitmap myBitmap7 = LineDDA(0, 0, 100, -70);
            g.DrawImage(myBitmap7, 10, 50);
            Bitmap myBitmap8 = LineDDA(100, -70, 200, 0);
            g.DrawImage(myBitmap8, 10, 50);*/
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "") {
                Bitmap myBitmap = LineDDA(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text));
                g.DrawImage(myBitmap, 10, 50);
            }
            Bitmap myBitmap0 = LineDDA(100, 0, 300, 0);
            Bitmap myBitmap2 = LineDDA(100, 0, 100, 70);
            g.DrawImage(myBitmap0, 10, 50);
            g.DrawImage(myBitmap2, 10, 50);
            Bitmap myBitmap3 = LineDDA(300, 0, 100, 70);
            Bitmap myBitmap4 = LineDDA(100, 70, 300, 70);
            g.DrawImage(myBitmap3, 10, 50);
            g.DrawImage(myBitmap4, 10, 50);
            Bitmap myBitmap5 = LineDDA(100, 70, 300, 0);
            g.DrawImage(myBitmap5, 10, 50);
            Bitmap myBitmap6 = LineDDA(300, 0, 300, 70);
            g.DrawImage(myBitmap6, 10, 50);
            Bitmap myBitmap7 = LineDDA(100, 0, 200, -70);
            g.DrawImage(myBitmap7, 10, 50);
            Bitmap myBitmap8 = LineDDA(200, -70, 300, 0);
            g.DrawImage(myBitmap8, 10, 50);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            Bitmap myBitmap = LineBres(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text));
            g.DrawImage(myBitmap, 10, 50);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();

            Bitmap myBitmap = new Bitmap(1500, 1500);
            CircleDDA(myBitmap, Convert.ToInt32(textBox1.Text) + 100, Convert.ToInt32(textBox2.Text) + 100, Convert.ToInt32(textBox5.Text), Color.Black);
            g.DrawImage(myBitmap, 10, 50);
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            Bitmap myBitmap = new Bitmap(1500, 1500);
            CircleBres(myBitmap, Convert.ToInt32(textBox1.Text) + 100, Convert.ToInt32(textBox2.Text) + 100, 0, Convert.ToInt32(textBox5.Text), Color.Black);
            g.DrawImage(myBitmap, 10, 50);
        } 

        private Bitmap LineDDA(int x1, int y1, int x2, int y2)
        {
            if (x1 < 0) x1 = 0;
            if (x2 < 0) x2 = 0;
            if (x1 > x2) { int a = x1; x1 = x2; x2 = a; }
            if ((y1 > y2 && y2>0) /*|| (y1<0 && y2>=0)*/ || (y1<0 && y2<0 && y1<y2)) 
            { int a = y1; y1 = y2; y2 = a; }
        
            Bitmap nova = new Bitmap(1500, 1500);
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
                        x1++;
                        y1++;
                        nova.SetPixel(x1, y1 + nova.Height / 6, Color.Black);
                    }
                    else if (y2 < 0)
                    {
                        x1++;
                        y1--;
                        nova.SetPixel(x1, y1 + nova.Height / 6, Color.Black);
                    }
                }
            }
            else if (Math.Abs(dy) > Math.Abs(dx) && m > 0)
            {
                float x = x1;
                if (y2 < 0)
                {
                    while (y2 < y1)
                    {
                        y1--;
                        x += m;
                        nova.SetPixel(Convert.ToInt32(Math.Round(x)), y1 + nova.Height / 6, Color.Black);
                    }
                }
                else if (y2 > 0)
                {
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
                    if (y2 > 0  || (y1<0 && y2>=0))
                    {
                        y += m;
                    }
                    else
                    {
                        y -= m;
                    }
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

        private Bitmap LineBres(int x1, int y1, int x2, int y2)
        {
            Bitmap nova = new Bitmap(700, 700);
            int dx = (x2 - x1), dy = (y2 - y1);
            if (dy < dx)
            {
                int d = 2 * dy - dx;
                int inc1 = 2 * dy, inc2 = 2 * (dy - dx);
                nova.SetPixel(x1, y1, Color.Black);
                while (x1 < x2)
                {
                    if (d <= 0) d += inc1;
                    else
                    {
                        d += inc2;
                        y1++;
                    }
                    x1++;
                    nova.SetPixel(x1, y1 + nova.Height / 4, Color.Black);
                }
            }
            else if (dx < dy) {
                int d = 2 * dx - dy;
                int inc1 = 2 * dx, inc2 = 2 * (dx - dy);
                nova.SetPixel(x1, y1, Color.Black);
                while (y1 < y2) {
                    if (d <= 0) d += inc1;
                    else {
                        d += inc2;
                        x1++;
                    }
                    y1++;
                    nova.SetPixel(x1, y1 + nova.Height / 4, Color.Black);
                }
            }
            return nova;
        }

        private Bitmap CircleDDA(Bitmap btm, double xx, double yy, int r, Color color) 
        {
            //Bitmap btm = new Bitmap(1500, 1500);
            
            double v, x1, y1, x2, y2, startx, starty, a;
            int i;

            x1 = r * Math.Cos(0);
            y1 = r * Math.Sin(0);
            startx = x1;
            starty = y1;

            i = 0;
            v = Math.Pow((double)2, (double)i);
            while (v < r) {
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
