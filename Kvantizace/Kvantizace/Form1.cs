using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kvantizace
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap myBitmap = new Bitmap(@"C:\Users\Yuliya\Documents\Visual Studio 2010\Images\image01.png");
            Graphics g = this.CreateGraphics();
            g.DrawImage(myBitmap, 10, 65);

            for (int m = 0; m < 2; m++)
            {
                Bitmap nova = gray(myBitmap, m);
                g.DrawImage(nova, 255 * m + 10, 265);
            }
            
            int i = 10;
            for (int n = 2; n < 10; n = n + 2)
            {
                Bitmap nova2 = Small(g, myBitmap, n);
                g.DrawImage(nova2, i+ 470, 50);
                i = i + nova2.Width;
            }
            //SmallSuperSampling(g, myBitmap, 3);
            //g.DrawImage(nova7, 400, 325);
            //SmallSuperSampling(g, myBitmap, 3);
            Sampling(g, myBitmap, 5);
            Kvantizace(g, myBitmap, 3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private static Bitmap gray(Bitmap b1, int m)
        {
            Bitmap newB = new Bitmap(b1.Width, b1.Height);
            int intensity;
            for (int i = 0; i < newB.Width; i++)
                for (int j = 0; j < newB.Height; j++)
                {
                    Color c = b1.GetPixel(i, j);
                    if (m == 1)
                        intensity = (c.R + c.G + c.B) / 3;
                    else
                        intensity = (int)(0.299 * c.R + 0.587 * c.G + 0.114 * c.B);
                    newB.SetPixel(i, j, Color.FromArgb(intensity, intensity, intensity));
                }
            return newB;
        }
        //Алиасинг
        private static Bitmap Small(Graphics gr, Bitmap b1, int k)
        {
            Bitmap newB = new Bitmap(b1.Width / k, b1.Height / k);
            for (int i = 0; i < newB.Width; i++)
                for (int j = 0; j < newB.Height; j++)
                {
                    Color c = b1.GetPixel(i * k, j * k);
                    newB.SetPixel(i, j, c);
                }
            //gr.DrawImage(newB, 470, 50);
            return newB;
        }
        //СуперСамплинг Маленькая
        private static Bitmap SmallSuperSampling(Graphics gr, Bitmap b1, int k)
        {
            Bitmap newB = new Bitmap(b1.Width / k, b1.Height / k);
            for (int i = 0; i < newB.Width; i++)
                for (int j = 0; j < newB.Height; j++)
                {
                    int r = 0, g = 0, b = 0;
                    for (int m = i * k; m < k + i * k; m++)
                    {
                        for (int n = j * k; n < k + j * k; n++)
                        {
                            Color c = b1.GetPixel(m, n);
                            r += c.R;
                            g += c.G;
                            b += c.B;
                        }
                    }
                    r /= k * k;
                    g /= k * k;
                    b /= k * k;
                    newB.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            gr.DrawImage(newB, 500, 100);
            return newB;
        }
        //Самплинг
        private static Bitmap Sampling(Graphics gr, Bitmap b1, int k)
        {
            Bitmap newB = new Bitmap(b1.Width, b1.Height);
            Color c;
            for (int i = 0; i < (newB.Width - k); i = i + k)
                for (int j = 0; j < (newB.Height - k); j = j + k)
                {
                    int r = 0, g = 0, b = 0;
                    for (int m = i; m < k + i; m++)
                    {
                        for (int n = j; n < k + j; n++)
                        {
                            c = b1.GetPixel(m, n);
                            r += c.R;
                            g += c.G;
                            b += c.B;
                        }
                    }
                    r /= k * k;
                    g /= k * k;
                    b /= k * k;

                    for (int m = i; m < k + i; m++)
                    {
                        for (int n = j; n < k + j; n++)
                        {
                            newB.SetPixel(m, n, Color.FromArgb(r, g, b));
                        }
                    }
                }
            gr.DrawImage(newB, 500, 270);
            return newB;
        }

        private static Bitmap Kvantizace(Graphics gr, Bitmap b1, int n)
        {
            Bitmap newB = new Bitmap(b1.Width, b1.Height);
            int intensity = 0;
            int prvni = 0;
            int druhy = 255 / n;

            for (int k = 0; k < n; k++)
            {
                int interval = 255 / n;
                prvni = interval * k;
                druhy = interval * (k + 1);
                if (k == (n - 1)) intensity = 255;
                else intensity = prvni;
                for (int i = 0; i < newB.Width; i++)
                    for (int j = 0; j < newB.Height; j++)
                    {
                        Color c = b1.GetPixel(i, j);
                        if (c.R >= prvni && c.R < druhy)
                        {
                            newB.SetPixel(i, j, Color.FromArgb(intensity, intensity, intensity));
                        }
                    }
            }
            gr.DrawImage(newB, 270, 50);
            return newB;
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            button1.Text = "Button";
            button2.Text = "Exit";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
