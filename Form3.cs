using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Configuration;

namespace ApproximationOfTranscendentalNumbers
{
    public partial class Form3 : Form
    {
        Thread th;
        Graphics g;
        Graphics fG;
        Bitmap btm;
        Pen p;
        Rectangle large;
        int largeX = 500;
        int largeY = 119;
        int vel = -2;
        public Form3()
        {

            InitializeComponent();

        }

        public void drawRect(int xPos, int yPos)
        {
            btm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(btm);
            p = new Pen(Brushes.Red);
            large = new Rectangle(largeX, largeY, 80, 80);
            g.DrawRectangle(p, large);

        }
        public void updatePos()
        {
            largeX += vel;
            drawRect(largeX, largeY);
            pictureBox1.Image = btm;
            label1.Text = large.X.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            drawRect(largeX, largeY);
            pictureBox1.Image = btm;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            updatePos();

        }



    }
}
