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
            timer1.Interval = 10000;
            p.Push(new Point(x, y));
            while (p.Count > 0)
            {
                Point pZasobnik = p.Pop();
                if (btm.GetPixel(pZasobnik.X, pZasobnik.Y) == oldC)
                {
                    timer1.Start();
                    btm.SetPixel(pZasobnik.X, pZasobnik.Y, newC);
                    timer1.Stop();
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
            Bitmap myBitmap = new Bitmap(@"C:\Users\yuliya\Documents\Visual Studio 2010\Images\image04.png");
            g.DrawImage(myBitmap, 10, 10);
            Bitmap nova = new Bitmap(myBitmap.Height , myBitmap.Width);
            //nova = halftoning(myBitmap);
            g.DrawImage(nova, 10, 200);
        }
        private Bitmap halftoning(Bitmap btm)
        {
            //Bitmap btm2 = new Bitmap(btm.Width*3, btm.Height*3);
            Bitmap btm2 = new Bitmap(btm.Width, btm.Height);
            Bitmap btm3x3 = new Bitmap(3, 3);
            Color barva;
            for (int i = 0; i < btm.Height-3; i=i+3)
            {
                for (int j = 0; j < btm.Width-3; j=j+3)
                {
                    //barva = btm.GetPixel(i, j);
                    int r = 0, g = 0, b = 0;
                    for (int m = i * 3; m < i * 3 + 3; m++)
                    {
                        for (int n = j * 3; n < j * 3 + 3; n++)
                        {
                            barva = btm.GetPixel(m, n);
                            r += barva.R;
                            g += barva.G;
                            b += barva.B;
                        }
                    }
                    r /= 9; g /= 9; b /= 9;
                    double intensity = 0.299 * r + 0.587 * g + 0.114 * b;
                    int prvni = 0, druhy = 255 / 9;
                    int k;
                    for (k = 0; k < 9; k++)
                    {
                        if (intensity > prvni || intensity < druhy) { break; }
                        prvni = druhy;
                        druhy += 255 / 9;
                    }
                    Color[] c = new Color[9];
                    switch (k)
                    {
                        case 0: c[0] = Color.White; c[1] = Color.White; c[2] = Color.White;
                            c[3] = Color.White; c[4] = Color.Black; c[5] = Color.White; c[6] = Color.White;
                            c[7] = Color.White; c[8] = Color.White;
                            break;
                        case 1: c[0] = Color.White; c[1] = Color.White; c[2] = Color.White; c[3] = Color.Black;
                            c[4] = Color.Black; c[5] = Color.White; c[6] = Color.White;
                            c[7] = Color.White; c[8] = Color.White;
                            break;
                        case 2: c[0] = Color.White; c[1] = Color.White; c[2] = Color.White;
                            c[3] = Color.Black; c[4] = Color.Black; c[5] = Color.White; c[6] = Color.White;
                            c[7] = Color.Black; c[8] = Color.White;
                            break;
                        case 3: c[0] = Color.White; c[1] = Color.White; c[2] = Color.White;
                            c[3] = Color.Black; c[4] = Color.Black; c[5] = Color.Black; c[6] = Color.White;
                            c[7] = Color.Black; c[8] = Color.White;
                            break;
                        case 4: c[0] = Color.White; c[1] = Color.White; c[2] = Color.Black;
                            c[3] = Color.Black; c[4] = Color.Black; c[5] = Color.Black; c[6] = Color.White;
                            c[7] = Color.Black; c[8] = Color.White;
                            break;
                        case 5: c[0] = Color.White; c[1] = Color.White; c[2] = Color.Black;
                            c[3] = Color.Black; c[4] = Color.Black; c[5] = Color.Black; c[6] = Color.White;
                            c[7] = Color.Black; c[8] = Color.White;
                            break;
                        case 6: c[0] = Color.Black; c[1] = Color.White; c[2] = Color.Black;
                            c[3] = Color.Black; c[4] = Color.Black; c[5] = Color.Black; c[6] = Color.Black;
                            c[7] = Color.Black; c[8] = Color.White;
                            break;
                        case 7: c[0] = Color.Black; c[1] = Color.White; c[2] = Color.Black;
                            c[3] = Color.Black; c[4] = Color.Black; c[5] = Color.Black; c[6] = Color.Black;
                            c[7] = Color.Black; c[8] = Color.Black;
                            break;
                        case 8: c[0] = Color.Black; c[1] = Color.Black; c[2] = Color.Black;
                            c[3] = Color.Black; c[4] = Color.Black; c[5] = Color.Black; c[6] = Color.Black;
                            c[7] = Color.Black; c[8] = Color.Black;
                            break;
                    }
                    btm3x3 =  bitmap3x3(c);
                    k = 0;
                    for (int m = i * 3; m < i * 3 + 3; m++)
                    {
                        for (int n = j * 3; n < j * 3 + 3; n++)
                        {
                            btm2.SetPixel(m, n, c[k]);
                            k++;
                        }
                    }
                }
            }
            return btm2;
        }
        private Bitmap bitmap3x3(Color[] color/*, Color c2, Color c3, Color c4, Color c5, Color c6, Color c7, Color c8, Color c9*/)
        {
            Bitmap btm = new Bitmap(3,3);
            int k=0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    btm.SetPixel(i,j, color[k]);
                    k++;
                }
            }
            return btm;
        }
        private Bitmap floydSteinberg(Bitmap btm)
        {
            for (int i = 0; i < btm.Height; i++)
            {
                for (int j = 0; j < btm.Width; j++)
                {
                    int ci = i * btm.Width + j;
                    Color oldC = btm.GetPixel(i, j);
                    Point pixel = new Point(i, j);
                    Point oldP = pixel;
                    //Point newP = new Point(newP.X / 256, newP.Y / 256);
                    //pixel = newP;
                    //Point er = new Point(oldP.X - newP.X, oldP.Y - newP.Y);
                    //(pixel.X + 1) = pixel.X + 1 + er.X * 7 / 16;
                }
            }
            return btm;
        }
    }
}
