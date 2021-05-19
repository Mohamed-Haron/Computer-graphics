using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Graphics_Package
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        void circleMidPoint(int xcenter , int ycenter , int radius)
        {
            int x = 0, y = radius, p = 1 - radius;

            circlePlotPoints(xcenter, ycenter, x, y);

            while(x < y)
            {
                x++;
                if (p < 0)
                    p += 2 * x + 1;
                else
                {
                    y--;
                    p += 2 * (x - y) + 1;
                }

                circlePlotPoints(xcenter, ycenter, x, y);
            }

        }

        void circlePlotPoints(int xcenter , int ycenter , int x , int y)
        {
            var abrush = Brushes.Black;
            var g = panel1.CreateGraphics();

            g.FillRectangle(abrush, xcenter + x, ycenter + y, 2, 2);
            g.FillRectangle(abrush, xcenter - x, ycenter + y, 2, 2);
            g.FillRectangle(abrush, xcenter + x, ycenter - y, 2, 2);
            g.FillRectangle(abrush, xcenter - x, ycenter - y, 2, 2);
            g.FillRectangle(abrush, xcenter + y, ycenter + x, 2, 2);
            g.FillRectangle(abrush, xcenter - y, ycenter + x, 2, 2);
            g.FillRectangle(abrush, xcenter + y, ycenter - x, 2, 2);
            g.FillRectangle(abrush, xcenter - y, ycenter - x, 2, 2);



        }



        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            circleMidPoint(Int32.Parse(textBox1.Text), Int32.Parse(textBox2.Text), Int32.Parse(textBox3.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            panel1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
        }
    }
}
