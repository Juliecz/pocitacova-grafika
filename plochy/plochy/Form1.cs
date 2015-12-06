using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace plochy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        const int step = 100;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Bitmap myBitmap = plocha()
            //g.DrawImage(myBitmap, 10, 50);
            //Bitmap nova = new Bitmap(1800, 1800);

            PointF[,] points = new PointF[101, 101];
            PointF[,] BP = new PointF[4, 4] {
            {new PointF(100, 100), new PointF(150, 130), new PointF(230, 100), new PointF(320, 100)},
            {new PointF(150, 170), new PointF(150, 180), new PointF(240, 190), new PointF(340, 250)},
            {new PointF(70, 220), new PointF(110, 210), new PointF(200, 300), new PointF(310, 300)},
            {new PointF(70, 360), new PointF(130, 300), new PointF(230, 240), new PointF(300, 320)}
            };
            for (int x = 0; x <= 100; x++)
            {
                for (int y = 0; y <= 100; y++)
                {
                    float u = x / 100.0F;
                    float v = y / 100.0F;
                    PointF p = new PointF(0, 0);

                    for (int i = 0; i <= 3; i++)
                    {
                        for (int j = 0; j <= 3; j++)
                        {
                            p.X += BP[i, j].X * Bernstein(i, u) * Bernstein(j, v);
                            p.Y += BP[i, j].Y * Bernstein(i, u) * Bernstein(j, v);

                        }
                       
                    }
                    points[x, y] = p;
                }
            }

            Graphics g = CreateGraphics();

            for (int x = 1; x <= 100; x++)
            {
                for (int y = 1; y <= 100; y++)
                {
                    g.DrawLine(Pens.Green, points[x, y], points[x - 1, y]);
                    g.DrawLine(Pens.Black, points[x, y], points[x, y - 1]);
                }
            }
            /*for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    g.DrawLine(Pens.Green, BP[x, y].X - 5, BP[x, y].Y - 5, 10, 10);
                }
            }*/
        }
        /*private Bitmap plocha(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4, double px1, double px2, double px3, double py1, double py2, double py3, Color barva)
        {
            Bitmap nova = new Bitmap(1800, 1800);
            
            Point[,] points = new Point[step, step];
            Point[,] BP = new Point[4, 4] {
            {new Point(100, 100), new Point(150, 130), new Point(230, 100), new Point(320, 100)},
            {new Point(50, 170), new Point(250, 280), new Point(240, 190), new Point(340, 250)},
            {new Point(30, 220), new Point(110, 210), new Point(200, 300), new Point(310, 300)},
            {new Point(20, 360), new Point(130, 300), new Point(230, 240), new Point(300, 320)}
            };
            for (int x = 0; x <= 100; x++)
            {
                for (int y = 0; y <= 100; y++)
                {
                    float u = x / (float)step;
                    float v = y / (float)step;
                    Point p = new Point(0,0);

                    for (int i = 0; i <= 3; i ++)
                    {
                        for (int j = 0; j <= 3; j ++)
                        {
                            p.X = BP[i, j].X * (int)Bernstein(i, u) * (int)Bernstein(i, v);
                            p.Y = BP[i, j].Y * (int)Bernstein(i, u) * (int)Bernstein(i, v);
                        }
                        points[x,y] = p;
                    }
                }
            }


            Graphics g = CreateGraphics();
            for (int x =0; x<step; x++)
            {
                for (int y=0; y<step; y++)
                {
                    g.DrawLine(Pens.Black, points[x,y], points[x-1, y]);
                    g.DrawLine(Pens.Black, points[x,y], points[x, y-1]);
                }
            }
            for (int x =0; x<4; x++)
            {
                for (int y=0; y<4; y++)
                {
                    g.DrawLine(Pens.Green, BP[x,y].X -5, BP[x,y].Y -5, 10, 10);
                }
            }
            return nova;
        }*/

        private float Bernstein(int i, float t)
        {
            float tt = 1-t;
            switch (i)
            {
                case 0: return tt * tt * tt;
                case 1: return 3 * t * tt * tt;
                case 2: return 3 * t * t * tt;
                case 3: return t * t * t;

            }
            throw new Exception("unknown ");
        }
    }
}
