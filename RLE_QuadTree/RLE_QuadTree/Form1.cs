using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace RLE_QuadTree
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            Bitmap myBitmap = new Bitmap(@"C:\Users\yuliya\Documents\Visual Studio 2010\Images\image02.png");
            Graphics g = CreateGraphics();
            g.DrawImage(myBitmap, 10, 50);
            //Bitmap nova = QuadTree(myBitmap, 10, 10, label1, label2);
            textBox1.Text = RLE(myBitmap);
        }

        private Bitmap QuadTree(Bitmap b1, int sirka, int vyska, int x, int y/*x=0, y=velikObrazku*/, Label l)
        {
            int i, j;
            l.Text = "";
            bool jinaBarva = false;
            Bitmap newB = new Bitmap(b1.Width, b1.Height);
            Color barva1 = b1.GetPixel(0, 0), barva2;
            for (i = 0; i < sirka; i= i++)
            {
                for (j = 0; j < vyska; j++)
                {
                    barva2 = b1.GetPixel(i, j);
                    if (barva2 != barva1)
                    {
                        jinaBarva = true;
                        break;
                    }
                }
                l.Text += "\n";
            }
            if (jinaBarva) {
                /*QuadTree();
                QuadTree();
                QuadTree();
                QuadTree();*/
            }
            return newB;
        }

        private string RLE(Bitmap b1) {
            int citac = 0;
            string c = "", text = "";
            Color barva1, barva2;
            //barva1 = b1.GetPixel(0, 0);
            
            for (int i = 0; i < b1.Height; i++)
            {
                barva1 = b1.GetPixel(0,i);
                citac = 0;
                text += (i+1) + " ";
                for (int j = 0; j < b1.Width; j++)
                {
                    barva2 = b1.GetPixel(j,i);
                    if (barva1 == barva2) {
                        citac++;
                    }
                    else {
                        /*if (barva1 == Color.FromArgb(0, 0, 0)) c = "C";
                        else if (barva1 == Color.FromArgb(255, 255, 255)) c = "B";
                        else c = "Z";*/
                        text += " (" + citac + " , Barva)";
                        barva1 = barva2;
                        citac = 1;
                    }
                }
                /*if (barva1 == Color.FromArgb(0, 0, 0)) c = "C";
                else if (barva1 == Color.FromArgb(255, 255, 255)) c = "B";
                else c = "Z";*/
                //text += " (" + citac + " ," + c + ")\r\n";
                if (citac != 0)
                {
                    text += " (" + citac + " , Barva)\r\n";
                }
                //citac = 0;
            }
            return text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
