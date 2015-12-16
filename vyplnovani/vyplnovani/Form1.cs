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
            Bitmap myBitmap = new Bitmap(@"C:\Users\yuliya\Documents\Visual Studio 2010\Images\image08.png"); //image08
            g.DrawImage(myBitmap, 10, 10);
            Random rand = new Random();
            int x = 0, y = 0;
            bool k = false;
            int[] pole = minMax(myBitmap);
            do
            {
                x = rand.Next(myBitmap.Width);
                y = rand.Next(myBitmap.Height);
                k = kontrola(myBitmap, x, y);
                if (y < pole[2] || y > pole[3]) { k = false; }
                if (x < pole[0] || x > pole[1]) { k = false; }
            } while (!k);
            //label1.Text = "x: " + x + " y: " + y;
            g.DrawImage(myBitmap, 10, 200);
            Bitmap nova = scanLine(myBitmap, x, y, Color.Yellow);
            g.DrawImage(nova, 10, 200);
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
        private Bitmap radek(Graphics g, Bitmap btm, int x, int y, Color newC)
        {
            int [] pole = minMax(btm);
            Point nahoru = new Point();
            nahoru = vyplnitRadek(g, btm, x, y, newC);
            Point dolu = nahoru;
            //label1.Text = "x: " + dolu.X + " y: " + dolu.Y;
            while (nahoru.Y > pole[2])
            {
                if (btm.GetPixel(nahoru.X, nahoru.Y).R == 0) { nahoru.X++; continue; }
                if (nahoru.X < pole[1] && nahoru.X > pole[0]) { vyplnitRadek(g, btm, nahoru.X, nahoru.Y, newC); }
                nahoru.Y--;
            }
            while (dolu.Y < pole[3])
            {
                if (btm.GetPixel(dolu.X, dolu.Y).R == 0) { dolu.X++; continue; }
                if (dolu.X < pole[1] && dolu.X > pole[0]) vyplnitRadek(g, btm, dolu.X, dolu.Y, newC);
                dolu.Y++;
            }
            //label1.Text += "x: "+dolu.X+" y: "+dolu.Y;
            return btm;
        }
        private Point vyplnitRadek(Graphics g, Bitmap btm, int x, int y, Color newC)
        {
            for (int i = x; i < btm.Width; i++)
            {
                if (btm.GetPixel(i, y).R != 0) { btm.SetPixel(i, y, newC); }
                else { break; }
            }
            for (int i = x; i > 0; i--)
            {
                if (btm.GetPixel(i, y).R != 0) { btm.SetPixel(i, y, newC); }
                else { Point p = new Point(i, y); return p; }
            }
            Point p1 = new Point(btm.Width, btm.Height);
            return p1;
        }
        
        private int[] minMax(Bitmap btm)
        {
            int[] pole = new int[4];
            int minX = 0, maxX = 0, minY = 0, maxY = 0;
            for (int i = 0; i < btm.Height; i++)
            {
                for (int j = 0; j < btm.Width; j++)
                {
                    if (btm.GetPixel(j, i).R == 0 && minY == 0)
                    {
                        minY = i;
                        break;
                    }
                }
            }
            for (int i = btm.Height - 1; i > 0; i--)
            {
                for (int j = btm.Width - 1; j > 0; j--)
                {
                    if (btm.GetPixel(j, i).R == 0 && maxY == 0)
                    {
                        maxY = i;
                        break;
                    }
                }
            }
            for (int j = btm.Width - 1; j > 0; j--)
            {
                for (int i = btm.Height - 1; i > 0; i--)
                {
                    if (btm.GetPixel(j, i).R == 0 && maxX == 0)
                    {
                        maxX = j;
                        break;
                    }
                }
            }
            for (int j = 0; j < btm.Width; j++)
            {
                for (int i = 0; i < btm.Height; i++)
                {
                    if (btm.GetPixel(j, i).R == 0 && minX == 0)
                    {
                        minX = j;
                        break;
                    }
                }
            }
            pole[0] = minX;
            pole[1] = maxX;
            pole[2] = minY;
            pole[3] = maxY;
            return pole;
        }
        private bool kontrola(Bitmap btm, int x, int y)
        {
            bool k = false, k1 = false, k2 = false;
            int kX = 0, kY = 0;
            
            for (int i = x; i < btm.Width; i++)
            {
                if (btm.GetPixel(i, y).R == 0 && btm.GetPixel(i + 1, y).R == 255)
                {
                    kX++;
                }
            }
            for (int i = y; i < btm.Height; i++)
            {
                if (btm.GetPixel(x, i).R == 0 && btm.GetPixel(x, i + 1).R == 255)
                {
                    kY++;
                }
            }
            if (kX % 2 != 0) { k1 = true; }
            if (kY % 2 != 0) { k2 = true; }
            if (k1 && k2) { return k = true; }
            else if (!k1 || !k2) { return k = false; }
            return k;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            Bitmap myBitmap = new Bitmap(@"C:\Users\yuliya\Documents\Visual Studio 2010\Images\kocourMaly.png");
            g.DrawImage(myBitmap, 10, 10);
            halftoning(myBitmap, g);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            Bitmap myBitmap = new Bitmap(@"C:\Users\yuliya\Documents\Visual Studio 2010\Images\image08.png");
            g.DrawImage(myBitmap, 10, 10);
            Random rand = new Random();
            int x = 0, y = 0;
            bool k = false;
            int[] pole = minMax(myBitmap);
            do
            {
                x = rand.Next(myBitmap.Width);
                y = rand.Next(myBitmap.Height);
                k = kontrola(myBitmap, x, y);
                if (y < pole[2] || y > pole[3]) { k = false; }
                if (x < pole[0] || x > pole[1]) { k = false; }
                if (myBitmap.GetPixel(x, y).R == 0) { k = false; }
            } while (!k);
            //label1.Text = "x: " + x + " y: " + y;
            Bitmap nova = radek(g, myBitmap, x, y, Color.RosyBrown);
            g.DrawImage(nova, 10, 200);
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
            for (int i = 0; i < btm.Width-1; i++)
            {
                for (int j = 0; j < btm.Height-1; j++)
                {
                    Color oldP = btm.GetPixel(i, j);
                    Color newP;
                    if (oldP.R < 128) { newP = Color.FromArgb(0, 0, 0); }
                    else { newP = Color.FromArgb(255, 255, 255); btm.SetPixel(i, j, newP); continue; }
                    btm.SetPixel(i, j, newP);
                    int qErr = oldP.R - newP.R;
                    Color c = btm.GetPixel(i+1, j);
                    int a = (int)(c.R + 7 / 16.0 * qErr);
                    if (a < 0) { a = 0; }
                    if (a > 255) { a = 255; }
                    btm.SetPixel(i+1,j, Color.FromArgb(a, a, a));
                    c = btm.GetPixel(i, j+1);
                    a = (int)(c.R + 5 / 16.0 * qErr);
                    if (a < 0) { a = 0; }
                    if (a > 255) { a = 255; }
                    btm.SetPixel(i, j+1, Color.FromArgb(a, a, a));
                    c = btm.GetPixel(i + 1, j + 1);
                    a = (int)(c.R + 1 / 16.0 * qErr);
                    if (a < 0) { a = 0; }
                    if (a > 255) { a = 255; }
                    btm.SetPixel(i + 1, j + 1, Color.FromArgb(a, a, a));
                    if (i > 0)
                    {
                        c = btm.GetPixel(i - 1, j + 1);
                        a = (int)(c.R + 3 / 16.0 * qErr);
                        if (a < 0) { a = 0; }
                        if (a > 255) { a = 255; }
                        btm.SetPixel(i - 1, j + 1, Color.FromArgb(a, a, a));
                    }
                }
            }
            g.DrawImage(btm, 10, 200);
            return btm;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            Bitmap myBitmap = new Bitmap(@"C:\Users\yuliya\Documents\Visual Studio 2010\Images\kocour.png");
            g.DrawImage(myBitmap, 10, 10);
            floydSteinberg(myBitmap, g);
        }

    }
}
