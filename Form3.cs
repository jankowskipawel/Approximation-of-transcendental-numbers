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
        int counter = 0;
        float timesteps = 100;
        Block small;
        Block large;
        
       
        public struct Block
        {
            public float x;
            public float width;
            public float mass;
            public float velocity;
            public Block(float x,float width, float mass, float velocity)
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
            public float ElasticCollision(Block other)
            {
                float sum = mass + other.mass;
                float newVelocity = (mass - other.mass) / sum * velocity + (2 * other.mass / sum) * other.velocity;
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
            small = new Block(100, 20, 1, 0);
            large = new Block(300, 80, 100000000, -1/timesteps);
            InitializeComponent();
        }
        public void DrawBlocks(Block small, Block large)
        {
            RectangleF block1 = new RectangleF(large.x, 119, large.width, large.width);
            RectangleF block2 = new RectangleF(small.x, 179, small.width, small.width);
            btm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(btm);
            SolidBrush b = new SolidBrush(Color.Red);
            g.FillRectangle(b, block1);
            g.FillRectangle(b, block2);
            pictureBox1.Image = btm;
            
        }

        
        
        
        



        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = counter.ToString();
            
            for(int i = 0; i < timesteps; i++)
            {
                if(small.IsColliding(large))
                {
                    float v1 = small.ElasticCollision(large);
                    float v2 = large.ElasticCollision(small);
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
            DrawBlocks(small, large);





        }

       
    }
}
