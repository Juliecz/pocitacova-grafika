using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace rgbKrychle
{
    public partial class Form1 : Form
    {
        Graphics g;
        public Form1()
        {
            InitializeComponent();
        }
        Bitmap myBitmap = new Bitmap(256, 256);
        Bitmap vybrana = new Bitmap(200, 100);
        int red;
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void krychle(int red)
        {
            Graphics g = this.CreateGraphics();
            for (int i = 0; i < 255; i++)
            {
                for (int j = 0; j < 255; j++)
                {
                    myBitmap.SetPixel(i, j, Color.FromArgb(red, i, j));
                }
            }
            g.DrawImage(myBitmap, 20, 20);
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            red = hScrollBar1.Value;
            numericUpDown1.Value = red;
            krychle(red);
            vybranaBarva(red, (int)numericUpDown2.Value, (int)numericUpDown3.Value);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            krychle(0);
            vybranaBarva(0,0,0);
        }
        private void vybranaBarva(int cervena, int zelena, int modra)
        {
            Graphics g = this.CreateGraphics();
            for (int i = 0; i < 200; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    vybrana.SetPixel(i, j, Color.FromArgb(cervena, zelena, modra));
                }
            }
            g.DrawImage(vybrana, 320, 20);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Point bod = e.Location;
            if (bod.X > 20 && bod.X < 276 && bod.Y > 20 && bod.Y < 276)
            {
                numericUpDown1.Value = myBitmap.GetPixel(bod.X-20, bod.Y-20).R;
                numericUpDown2.Value = myBitmap.GetPixel(bod.X-20, bod.Y-20).G;
                numericUpDown3.Value = myBitmap.GetPixel(bod.X-20, bod.Y-20).B;
                vybranaBarva((int)numericUpDown1.Value, (int)numericUpDown2.Value, (int)numericUpDown3.Value);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            vybranaBarva((int)numericUpDown1.Value, (int)numericUpDown2.Value, (int)numericUpDown3.Value);
            hScrollBar1.Value = (int)numericUpDown1.Value;
            krychle((int)numericUpDown1.Value);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            vybranaBarva((int)numericUpDown1.Value, (int)numericUpDown2.Value, (int)numericUpDown3.Value);
            //hScrollBar1.Value = (int)numericUpDown1.Value;
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            vybranaBarva((int)numericUpDown1.Value, (int)numericUpDown2.Value, (int)numericUpDown3.Value);
            //hScrollBar1.Value = (int)numericUpDown1.Value;
        }
    }
}
