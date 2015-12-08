using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace vyplnovani
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
            Bitmap myBitmap = new Bitmap(@"C:\Users\yuliya\Documents\Visual Studio 2010\Images\image04.png");
            g.DrawImage(myBitmap, 10, 10);
            Random rand = new Random();
            Color c;
            int x = 0, y = 0;
            do
            {
                x = rand.Next(myBitmap.Width);
                y = rand.Next(myBitmap.Height);
                c = myBitmap.GetPixel(x, y);
                if (Color.FromArgb(0, 255, 0) == c)
                {
                    scanLine(myBitmap, x, y, Color.FromArgb(244, 237, 202));
                    //radek(myBitmap, x, y, Color.FromArgb(244, 237, 202));
                    //vyplnitRadek(myBitmap, x, y);
                    break; 
                }
            } while (c != Color.FromArgb(0, 255, 0));
            g.DrawImage(myBitmap, 10, 200);
        }

        private Bitmap scanLine(Bitmap btm, int x, int y, Color newC)
        {
            Color oldC = btm.GetPixel(x, y);
            Stack<Point> p = new Stack<Point>();
            p.Push(new Point(x, y));
            while (p.Count > 0)
            {
                Point pZasobnik = p.Pop();
                if (btm.GetPixel(pZasobnik.X, pZasobnik.Y) == oldC)
                {
                    btm.SetPixel(pZasobnik.X, pZasobnik.Y, newC);
                    p.Push(new Point(pZasobnik.X + 1, pZasobnik.Y));
                    p.Push(new Point(pZasobnik.X - 1, pZasobnik.Y));
                    p.Push(new Point(pZasobnik.X, pZasobnik.Y + 1));
                    p.Push(new Point(pZasobnik.X, pZasobnik.Y - 1));

                }
            }

            return btm;
        }
        private Bitmap radek(Bitmap btm, int x, int y, Color newC)
        {
            /*Color barva = btm.GetPixel(x, y);
            int k=0;
            int ymin=0, ymax=0;
            for (int i = 0; i < btm.Height; i++)
            {
                if (ymin==0) {
                for (int j = 0; j < btm.Width; j++)
                {
                    Color c = btm.GetPixel(x, y);
                    if (c == Color.FromArgb(0, 255, 0)) { k++; }
                    if (k == 1) { ymin = i; break; }
                }
                }
                k = 0;
                for (int j = ymin; j < btm.Width; j++)
                {
                    Color c = btm.GetPixel(x, y);
                    if (c == Color.FromArgb(0, 255, 0)) { k++; }
                    if (k >= 1) { ymax = i; }
                }
            }
            l.Text = "min: "+ymin+" max: "+ymax;
            for (int i = 0; i < y; i++)
            {
                
                //Color c2;
                /*do {
                    c2 = btm.GetPixel(x, y);

                } while ()*
            }
            Random rand = new Random();
            Color c1 = btm.GetPixel(0, 0);
            do
            {
                x = rand.Next(btm.Width);
                y = rand.Next(btm.Height);
                c1 = btm.GetPixel(x, y);
            } while (c1 != Color.FromArgb(0, 255, 0));
            l.Text += "\n x: " + x + " y: " + y;
            //vyplnitRadek(btm, x, y);*/
            Queue<Point> q = new Queue<Point>();
            Point p = new Point(x, y);
            Color oldC = btm.GetPixel(x, y);
            q.Enqueue(p);
            while (q.Count > 0)
            {
                Point pFronta = q.Dequeue();
                if (btm.GetPixel(pFronta.X, pFronta.Y) == oldC)
                    continue;
                Point first = pFronta, second = new Point(pFronta.X, pFronta.Y);
                while(first.X >= 0 && btm.GetPixel(first.X, first.Y) == oldC)
                {
                    btm.SetPixel(first.X, first.Y, newC);
                    if (first.Y > 0 && btm.GetPixel(first.X, first.Y - 1) == oldC) { q.Enqueue(new Point(first.X, first.Y - 1)); }
                    if (first.Y < btm.Height - 1 && btm.GetPixel(first.X, first.Y + 1) == oldC) { q.Enqueue(new Point(first.X, first.Y + 1)); }
                    first.X--;
                }
                while (second.X <= btm.Width - 1 && btm.GetPixel(second.X, second.Y) == oldC)
                {
                    btm.SetPixel(second.X, second.Y, newC);
                    if (second.Y > 0 && btm.GetPixel(second.X, second.Y - 1) == oldC) { q.Enqueue(new Point(second.X, second.Y - 1)); }
                    if (second.Y < btm.Height - 1 && btm.GetPixel(second.X, second.Y + 1) == oldC) { q.Enqueue(new Point(second.X, second.Y + 1)); }
                    first.X++;
                }
            }
            return btm;
        }

        private Bitmap vyplnitRadek(Bitmap btm, int x, int y)
        {
            Color barva = btm.GetPixel(x, y);
            for (int i = 0; i < btm.Height; i++)
            {
                for (int j = 0; j < btm.Width; j++)
                {
                    Color b = btm.GetPixel(i,j);
                    if (b == barva)
                    {
                        btm.SetPixel(i,j, Color.Chocolate);
                    }
                }
            }
            return btm;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            Bitmap myBitmap = new Bitmap(@"C:\Users\yuliya\Documents\Visual Studio 2010\Images\kocourMaly.png");
            g.DrawImage(myBitmap, 10, 10);
            halftoning(myBitmap, g);
        }
        
        private Bitmap halftoning(Bitmap btm, Graphics g)
        {
            Bitmap btm2 = new Bitmap(btm.Width * 3, btm.Height * 3);
            int[,] pole = new int[,] { { 6, 8, 4 }, { 1, 0, 3 }, { 5, 2, 7 } };
            Color barva;
            for (int i = 0; i < btm.Height; i ++)
            {
                for (int j = 0; j < btm.Width; j ++)
                {
                    barva = btm.GetPixel(j, i);
                    int intensity = 0;
                    intensity = barva.R;
                    int prvni = 0, druhy = 255 / 9;
                    int k = 0;
                    for (k = 0; k < 9; k++)
                    {
                        if (intensity >= prvni && intensity <= druhy) { break; }
                        prvni = druhy;
                        druhy += 255 / 9;
                    }
                    for (int m = 0; m < 3; m++)
                    {
                        for (int n = 0; n < 3; n++)
                        {
                            if (pole[m, n] >= k || k == 9)
                            {
                                btm2.SetPixel(j * 3 + m, i * 3 + n, Color.Black);
                            }
                            else
                            {
                                btm2.SetPixel(j * 3 + m, i * 3 + n, Color.White);
                            }
                        }
                    }
                }
            }
            g.DrawImage(btm2, 10, 200);
            return btm2;
        }

        private Bitmap floydSteinberg(Bitmap btm, Graphics g)
        {
            for (int i = 0; i < btm.Width-1; i+=2)
            {
                for (int j = 0; j < btm.Height-1; j+=2)
                {
                    Color oldP = btm.GetPixel(i, j);
                    Color newP;
                    if(oldP.R<128) { newP = Color.FromArgb(0,0,0); }
                    else newP = Color.FromArgb(255, 255, 255);
                    btm.SetPixel(i, j, newP);
                    int qErr = oldP.R - newP.R;
                    Color c = btm.GetPixel(i+1, j);
                    int a = c.R + 7 / 255 * qErr;
                    btm.SetPixel(i+1,j, Color.FromArgb(a, a, a));
                    c = btm.GetPixel(i, j+1);
                    a = c.R + 3 / 255 * qErr;
                    btm.SetPixel(i, j+1, Color.FromArgb(a, a, a));
                    c = btm.GetPixel(i+1, j + 1);
                    a = c.R + 3 / 255 * qErr;
                    btm.SetPixel(i+1, j + 1, Color.FromArgb(a, a, a));
                    c = btm.GetPixel(i + 1, j + 1);
                    a = c.R + 5 / 255 * qErr;
                    btm.SetPixel(i + 1, j + 1, Color.FromArgb(a, a, a));
                    if (i > 0)
                    {
                        c = btm.GetPixel(i - 1, j + 1);
                        a = c.R + 1 / 255 * qErr;
                        btm.SetPixel(i - 1, j + 1, Color.FromArgb(a, a, a));
                    }
                }
            }
            g.DrawImage(btm, 10, 200);
            return btm;
        }
        private Point color(Point p)
        {
            Point newp = p;
            newp.X = (int)(p.X/256);
            newp.Y = (int)(p.Y/256);
            return newp;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            Bitmap myBitmap = new Bitmap(@"C:\Users\yuliya\Documents\Visual Studio 2010\Images\kocourMaly.png");
            g.DrawImage(myBitmap, 10, 10);
            floydSteinberg(myBitmap, g);
        }
    }
}
