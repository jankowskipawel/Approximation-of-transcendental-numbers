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
        Kwadrat small;
        Kwadrat large;
        int counter = 0;
        double timesteps = 10;
       
        public struct Kwadrat
        {
            public Rectangle rect;
            public double mass;
            public double velocity;
            public Kwadrat(Rectangle rect, double mass, double velocity)
            {
                this.rect = rect;
                this.mass = mass;
                this.velocity = velocity;
            }
            public void UpdatePos()
            {
                rect.X += (int)velocity;
            }
            public bool Collide(Kwadrat other)
            {
                if (rect.X + rect.Width < other.rect.X || rect.X > other.rect.X + other.rect.Width)
                {

                    return false;
                }
                else
                {
                    return true;
                }
            }
            public bool Wall()
            {
                if(rect.X <= 0 )
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public void reverse()
            {
                velocity *= -1;
            }
            public double EllasticCollision (Kwadrat other)
            {
                double sum = mass + other.mass;
                double newV = (mass - other.mass) / sum * velocity + (2 * other.mass / sum) * other.velocity;
                return newV;
            }

        }


        public Form3()
        {
            
            small = new Kwadrat(new Rectangle(300, 179, 20, 20), 1, 0);
            large = new Kwadrat(new Rectangle(500, 119, 80, 80), 10000, -2);

            InitializeComponent();

        }

        /*public void DrawRect(Rectangle rectLarge, Rectangle rectSmall)
        {
            btm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(btm);
            p = new Pen(Brushes.Red);
            g.DrawRectangle(p, rectLarge);
            g.DrawRectangle(p, rectSmall);

        }*/
        public void DrawKwadrat(Kwadrat small,Kwadrat large )
        {
            btm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(btm);
            p = new Pen(Brushes.Red);
            
            g.DrawRectangle(p, small.rect);
            g.DrawRectangle(p, large.rect);
            pictureBox1.Image = btm;

        }
        
        /*public Rectangle updatePos(Rectangle rect, double vel)
        {
            rect.X += (int)vel;
            Rectangle newRect = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);

            //label1.Text = newRect.X.ToString();
            return newRect;
        }*/
        /*public bool isColliding(Rectangle rect, Rectangle rectSmall)
        {
            if (rect.X + rect.Width < rectSmall.X || rect.X > rectSmall.X + rectSmall.Width)
            {
                return false;
            }
            else
            {
                return true;
            }
        }*/



        private void button1_Click(object sender, EventArgs e)
        {
            
            


            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            
            if(small.Collide(large))
            {
                double v1 = small.EllasticCollision(large);
                double v2 = large.EllasticCollision(small);
                small.velocity = v1;
                large.velocity = v2;
                counter++;
            }
            if(small.Wall())
            {
                small.reverse();
                counter++;
            }
            
            small.UpdatePos();
            large.UpdatePos();
           
            DrawKwadrat(small, large);
            label1.Text = counter.ToString();
            label2.Text = large.velocity.ToString();
            
            
            

            /*Kwadrat duzy = new Kwadrat(large, 100, 5);
            Kwadrat maly = new Kwadrat(small, 1, 0);
            DrawKwadrat(duzy, maly);
            if (duzy.collide(maly))
            {
                label2.Text = "collide";

            }
            else
            {
                label2.Text = " not collide ";
            }
            large = updatePos(large, largeVel);
            small = updatePos(small, smallVel);
            pictureBox1.Image = btm;*/

        }



    }
}
