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
            Bitmap myBitmap = new Bitmap(@"C:\Users\yuliya\Documents\Visual Studio 2010\Images\image03.png");
            Graphics g = CreateGraphics();
            g.DrawImage(myBitmap, 10, 50);
            textBox1.Text = RLE(myBitmap);
            label1.Text = "Kvadrantovy strom: ";
            label1.Text += kvadrantovyS(0, 0, myBitmap.Width, myBitmap.Height, myBitmap);
        }

        private string RLE(Bitmap b1) {
            int citac = 0;
            string  text = "";
            Color barva1, barva2;
            for (int i = 0; i < b1.Height; i++)
            {
                barva1 = b1.GetPixel(0,i);
                citac = 0;
                //text += (i+1) + " ";
                for (int j = 0; j < b1.Width; j++)
                {
                    barva2 = b1.GetPixel(j,i);
                    if (barva1 == barva2) {
                        citac++;
                    }
                    else {
                        text += " (" + citac + " , Barva)";
                        barva1 = barva2;
                        citac = 1;
                    }
                }
                if (citac != 0)
                {
                    text += " (" + citac + " , Barva)\r\n";
                }
            }
            return text;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public string kvadrantovyS(int x, int y, int sirka, int vyska, Bitmap btm)
        {
            string text = "";
            for (int i = x + 1; i < x + sirka; i++)
            {
                for (int j = y; j < y + vyska; j++)
                {
                    if (btm.GetPixel(i, j).ToArgb() != btm.GetPixel(i - 1, j).ToArgb())
                    {
                        text += "(" + kvadrantovyS(x, y, sirka / 2, vyska / 2, btm);
                        text += " " + kvadrantovyS(x + sirka / 2, y, sirka / 2, vyska / 2, btm);
                        text += " " + kvadrantovyS(x, y + vyska / 2, sirka / 2, vyska / 2, btm);
                        text += " " + kvadrantovyS(x + sirka / 2, y + vyska / 2, sirka / 2, vyska / 2, btm) + ")";
                        return text;
                    }
                }
            }
            return text += btm.GetPixel(x, y).R.ToString();
        }

    }


}
