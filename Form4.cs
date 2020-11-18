using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        Bitmap btm;
        Pen p;
        double pi = 4;
        int i = 0;
        List<double> memory = new List<double>();
        PointF[] points;
        public Form4()
        {
            
            InitializeComponent();
            btm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(btm);
            p = new Pen(Brushes.White);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
            timer1.Start();
        }
        /*public void Draw(List<double>memory)
        {
            double spacing = pictureBox1.Width / memory.Count();
            for (int i = 0; i < memory.Count();i++)
            {
                double x = i * spacing;
                double y = memory[i];
                
                g.DrawLine(p,)
                
                pictureBox1.Image = btm;
                
                
            }
        }*/
        public double Remap(double value, double from1, double to1, double from2, double to2)
        {
            return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            double divider = i * 2 + 3;
            if(i % 2 == 0)
            {
                pi -= (4 / divider);
            }
            else
            {
                pi += (4 / divider);
            }
            memory.Add(pi);
            label1.Text = memory.Count().ToString();
            
            
            
            i++;
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
