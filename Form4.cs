using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApproximationOfTranscendentalNumbers
{
    public partial class Form4 : Form
    {
        Graphics g;
        Graphics g2;
        Bitmap btm;
        Bitmap btm2;
        Pen p;
        Pen p2;
        Brush b1 = new SolidBrush(Color.DarkMagenta);
        float pi = 4;
        int i = 0;
        List<float> memory = new List<float>();
        List<float> memory2 = new List<float>();
        double ojler = 0;
        ulong sumCounter = 0;
        ulong x = 0;

        public Form4()
        {
            
            InitializeComponent();
            btm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(btm);
            btm2 = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            g2 = Graphics.FromImage(btm2);
            p = new Pen(Brushes.White,2);
            p2 = new Pen(Brushes.Red);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
            timer1.Start();
            memory.Add(3.5f);
           
        }
        public void Draw(List<float> memory)
        {
            for (int i = 1; i < memory.Count();i++)
            {
                float spacing = pictureBox1.Width / (float)memory.Count();
                float x = i * spacing;
                g.DrawLine(p, x-spacing, memory[i - 1]*400-1030, x, memory[i]*400-1030);
                g.DrawLine(p2, 0, (float)Math.PI*400-1030, pictureBox1.Width, (float)Math.PI * 400-1030);
                pictureBox1.Image = btm;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            float denominator = i * 2 + 3;
            if(i % 2 == 0)
            {
                pi -= (4 / denominator);
            }
            else
            {
                pi += (4 / denominator);
            }
            if (memory.Count >= pictureBox1.Width/8)
            {
                memory.RemoveAt(0);
            }
            memory.Add(pi);
            label1.Text = memory.Count().ToString();
            i++;
            g.Clear(Color.Black);
            label2.Text = memory[memory.Count-1].ToString();
            Draw(memory);
            
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Draw(memory);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            x = Convert.ToUInt64(textBox1.Text);
            timer2.Start();
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            float spacing = pictureBox2.Width / (float)memory.Count();
            if (sumCounter < 20)
            {
                ojler += Math.Pow(x, sumCounter) / (double)Factorial(sumCounter);
                sumCounter++;
            }
            memory2.Add((float)ojler);
            label6.Text = ojler.ToString();
            label4.Text = sumCounter.ToString();
            g.Clear(Color.Black);
            DrawOjler(memory2);
        }

        public void DrawOjler(List<float> memoryOjler)
        {
            for (int i = 1; i < memoryOjler.Count(); i++)
            {
                //float spacing = pictureBox2.Width / (float)memoryOjler.Count();
                //float xd = i * spacing;
                g2.DrawLine(p, i - 1, memoryOjler[i - 1], i, memoryOjler[i]);
                g2.DrawLine(p2, 0, (float)Math.E * 1500 - 3925, pictureBox2.Width, (float)Math.E * 1500 - 3925);
                pictureBox2.Image = btm2;
            }
        }


        public ulong Factorial(ulong x)
        {
            ulong result = 1;
            for (ulong i = x; i > 0; i--)
                result *= i;
            return result;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Factorial(20).ToString());
        }
        
    }
}
