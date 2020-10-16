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
        int largeMass = 100;
        int smallMass = 1;
        int largeVel = -5;
        int smallVel = 0;
        
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
        public Rectangle updatePos(Rectangle rect,int vel)
        {
            rect.X += vel;
            Rectangle newRect = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
            
            //label1.Text = newRect.X.ToString();
            return newRect;
        }
        public bool isColliding(Rectangle rect, Rectangle rectSmall)
        {
            if(rect.X + rect.Width < rectSmall.X || rect.X > rectSmall.X + rectSmall.Width)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public int bounce(int largeMass,int smallMass, int largeVel, int smallVel)
        {
            int sum = largeMass + smallMass;
            int wynik = (largeMass - smallMass) / sum * largeVel;
            return wynik;
        }
        public int bounceBack(int largeMass,int smallMass, int largeVel, int smallVel)
        {
            return(2*largeMass/(largeMass+smallMass))*largeVel+((smallMass-largeMass)/(largeMass+largeMass))*smallVel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            drawRect(large,small);
            
            
            
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            drawRect(large, small);
            if(isColliding(large, small))
            {
                
                largeVel = -1;
                smallVel = -2;

            }
            large = updatePos(large,largeVel);
            small = updatePos(small, smallVel);
            pictureBox1.Image = btm;

        }



    }
}
