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
        Graphics g;
        Bitmap btm;
        Pen p;
        Rectangle large;
        int largeX = 500;
        int largeY = 119;
        int vel = -2;
        
        public Form3()
        {
            large = new Rectangle(500, 119,80,80);
            
            

            InitializeComponent();

        }

        public void drawRect(Rectangle rect)
        {
            btm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(btm);
            p = new Pen(Brushes.Red);
            g.DrawRectangle(p, rect);

        }
        public Rectangle updatePos(Rectangle rect)
        {
            rect.X += vel;
            Rectangle newRect = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
            drawRect(newRect);
            pictureBox1.Image = btm;
            label1.Text = newRect.X.ToString();
            return newRect;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            drawRect(large);
            pictureBox1.Image = btm;
            
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            large = updatePos(large);
        }



    }
}
