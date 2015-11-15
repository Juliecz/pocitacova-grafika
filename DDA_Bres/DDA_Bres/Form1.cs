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
            Bitmap myBitmap = LineDDA(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text));
            g.DrawImage(myBitmap, 10, 50);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            Bitmap myBitmap = LineBres(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text));
            g.DrawImage(myBitmap, 10, 50);
        }

        private void button3_Click(object sender, EventArgs e)
        {
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            Bitmap myBitmap = CircleBres(20, Color.Black);
            g.DrawImage(myBitmap, 10, 50);
        } 

        private Bitmap LineDDA(int x1, int y1, int x2, int y2)
        {
            if (x1 > x2) { int a = x1; x1 = x2; x2 = a; }
            if (y1 > y2) { int a = y1; y1 = y2; y2 = a; }
            Bitmap nova = new Bitmap(700, 700);
            float dy = (y2 - y1), dx = (x2 - x1);
            float m = dy / dx;

            nova.SetPixel(x1, y1 + nova.Height / 4, Color.Black);

            //if (m=0) nova.SetPixel(x1, y1, Color.Black);
            if (m == 1)
            {
                while (x1 < x2)
                {
                    x1++;
                    y1++;
                    nova.SetPixel(x1, y1 + nova.Height / 4, Color.Black);
                }
            }
            else if (m < 1)
            {
                float y = y1;
                while (x1 < x2)
                {
                    x1++;
                    y = y + m;
                    nova.SetPixel(x1, Convert.ToInt32(Math.Round(y))+nova.Height/4, Color.Black);
                }
            }
            else if (m > 1)
            {
                float x = x1;
                m = dx / dy;
                while (y1 < y2)
                {
                    y1++;
                    x = x + m;
                    nova.SetPixel(Convert.ToInt32(Math.Round(x)), y1 + nova.Height / 4, Color.Black);
                }
            }
            return nova;
        }

        private Bitmap LineBres(int x1, int y1, int x2, int y2)
        {
            Bitmap nova = new Bitmap(700, 700);
            int dx = (x2 - x1), dy = (y2 - y1);
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
            return nova;
        }

        private void CircleDDA() 
        { 
            
        }

        private Bitmap CircleBres(int r, Color color) 
        {
            Bitmap btm = new Bitmap(700, 700);
            int x, y, d;
            x = 0;
            y = r;
            d = 1 - r;
            btm = CirclePoints(0, r, color);
            while (y > x) {
                if (d < 0) { d += 2 * x + 3; }
                else {
                    d += 2 * (x - y) + 5;
                    y--;
                }
                x++;
                btm = CirclePoints(x, y, color);
            }
            return btm;
        }

        private Bitmap CirclePoints(int x, int y, Color color)
        {
            Bitmap btm = new Bitmap(700, 700);
            btm.SetPixel(x, y, color);
            btm.SetPixel(y, x, color);
            btm.SetPixel(x, -y, color);
            btm.SetPixel(y, -x, color);
            btm.SetPixel(-x, y, color);
            btm.SetPixel(-y, x, color);
            btm.SetPixel(-x, -y, color);
            btm.SetPixel(-y, -x, color);
            return btm;
        }
    }
}
