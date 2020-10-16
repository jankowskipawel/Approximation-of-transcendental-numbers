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
        Rectangle small;
        int vel = -2;
        
        public Form3()
        {
            large = new Rectangle(500, 119,80,80);
            small = new Rectangle(100, 179, 20, 20);
            

            InitializeComponent();

        }

        public void drawRect(Rectangle rectLarge, Rectangle rectSmall)
        {
            btm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(btm);
            p = new Pen(Brushes.Red);
            g.DrawRectangle(p, rectLarge);
            g.DrawRectangle(p, rectSmall);

        }
        public Rectangle updatePos(Rectangle rect)
        {
            rect.X += vel;
            Rectangle newRect = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
            
            //label1.Text = newRect.X.ToString();
            return newRect;
        }
        public void collide(Rectangle rect, Rectangle rectSmall)
        {
            if(rect.X + rect.Width < rectSmall.X || rect.X > rectSmall.X + rectSmall.Width)
            {
                label1.Text = "not collide";
            }
            else
            {
                label1.Text = "collide";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            drawRect(large,small);
            
            
            
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            drawRect(large, small);
            large = updatePos(large);
            collide(large, small);
            pictureBox1.Image = btm;

        }



    }
}
