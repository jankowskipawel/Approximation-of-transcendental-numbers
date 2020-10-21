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
        
        double counter = 0;
        double timesteps;
        Block small;
        Block large;
        int digits;
        
       
        public struct Block
        {
            public double x;
            public double width;
            public double mass;
            public double velocity;
            public Block(double x, double width, double mass, double velocity)
            {
                this.x = x;
                this.width = width;
                this.mass = mass;
                this.velocity = velocity;
            }
            public void UpdatePos()
            {
                x += velocity;
            }
            public bool IsColliding(Block other)
            {
                if(x + width < other.x || x > other.x + other.width)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            public double ElasticCollision(Block other)
            {
                double sum = mass + other.mass;
                double newVelocity = (mass - other.mass) / sum * velocity + (2 * other.mass / sum) * other.velocity;
                return newVelocity;
            }
            public bool Wall()
            {
                if (x <= 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        public Form3()
        {
            InitializeComponent();
            digits = Convert.ToInt32(numericUpDown1.Value);
            timesteps = Math.Pow(10, digits);
            if(timesteps > 100000)
            {
                timesteps = 500000;
            }
            if (digits > 8)
            {
                timesteps = 5000000;
            }
            small = new Block(100, 20, 1, 0);
            large = new Block(300, 80, Math.Pow(100,digits-1), -2/timesteps);
        }
        public void DrawBlocks(Block small, Block large)
        {
            if(large.x < small.x+small.width)
            {
                large.x = small.x + small.width;
            }
            RectangleF block1 = new RectangleF((float)large.x, 119, (float)large.width, (float)large.width);
            RectangleF block2 = new RectangleF((float)small.x, 179, (float)small.width, (float)small.width);
            btm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(btm);
            SolidBrush Red = new SolidBrush(Color.Red);
            SolidBrush Yellow = new SolidBrush(Color.Yellow);
            g.FillRectangle(Red, block1);
            g.FillRectangle(Yellow, block2);
            pictureBox1.Image = btm;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            digits = Convert.ToInt32(numericUpDown1.Value);

            timesteps = Math.Pow(10,digits);
            if (digits > 5)
            {
                timesteps = 500000;
            }
            if(digits > 8)
            {
                MessageBox.Show("to chwile potrwa");
                timesteps = 5000000;
            }
            counter = 0;
            small = new Block(100, 20, 1, 0);
            large = new Block(300, 80, Math.Pow(100, digits - 1), -2 / timesteps);
            label5.Text = small.mass.ToString();
            label6.Text = large.mass.ToString();
            DrawBlocks(small, large);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            for(int i = 0; i < timesteps; i++)
            {
                if(small.IsColliding(large))
                {
                    double v1 = small.ElasticCollision(large);
                    double v2 = large.ElasticCollision(small);
                    small.velocity = v1;
                    large.velocity = v2;
                    counter++;
                    
                    
                }
                if(small.Wall())
                {
                    small.velocity *= -1;
                    counter++;
                    
                }
            
                small.UpdatePos();
                large.UpdatePos();


            }
            
            label1.Text = counter.ToString();
            DrawBlocks(small, large);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
        }
    }

}

