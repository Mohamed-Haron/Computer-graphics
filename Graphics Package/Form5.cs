using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Graphics_Package
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
       
    void ellipseMidpoint(int xCenter, int yCenter, int Rx, int Ry)
        {
            int Rx2 = Rx * Rx;
            int Ry2 = Ry * Ry;
            int twoRx2 = 2 * Rx2;
            int twoRy2 = 2 * Ry2;
            int p;
            int x = 0;
            int y = Ry;
            int px = 0;
            int py = twoRx2 * y;

            ellipsePlotPoints(xCenter, yCenter, x, y);
             p = (int) (Ry2 - (Rx2 * Ry) + (0.25 * Rx2));
            while (px < py)
            {
                x++;
                px += twoRy2;
                if (p < 0)
                    p += Ry2 + px;
                else
                {
                    y--;
                    py -= twoRx2;
                    p += Ry2 + px - py;
                }
                ellipsePlotPoints(xCenter, yCenter, x, y);
            }

            p = (int) (Ry2 * (x + 0.5) * (x + 0.5) + Rx2 * (y - 1) * (y - 1) - Rx2 * Ry2);
            while (y > 0)
            {
                y--;
                py -= twoRx2;
                if (p > 0)
                    p += Rx2 - py;
                else
                {
                    x++;
                    px += twoRy2;
                    p += Rx2 - py + px;
                }
                ellipsePlotPoints(xCenter, yCenter, x, y);
            }
        }

        void ellipsePlotPoints(int xCenter, int yCenter, int x, int y)
         {
            var abrush = Brushes.Black;
            var g = panel1.CreateGraphics();
            
            g.FillRectangle(abrush,xCenter + x, yCenter + y, 2, 2);
            g.FillRectangle(abrush,xCenter - x, yCenter + y, 2, 2);
            g.FillRectangle(abrush,xCenter + x, yCenter - y, 2, 2);
            g.FillRectangle(abrush,xCenter - x, yCenter - y,2,2);

            
        }

    private void button3_Click(object sender, EventArgs e)
        {
            ellipseMidpoint(Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text), Int32.Parse(textBox3.Text), Int32.Parse(textBox4.Text));
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            panel1.Refresh();
        }
    }
}
