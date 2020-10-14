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
using System.Security.Cryptography;

namespace ApproximationOfTranscendentalNumbers
{
    public partial class Form2 : Form
    {
        //inicjowanie zmiennych
        Graphics g;
        Rectangle r;
        Pen p;
        Bitmap btm;
        Random rnd = new Random();
        Thread th;
        int points;
        Rectangle point;
        Rectangle centerPoint;
        int circlePoints;
        double pi;
        public Form2()
        {
            InitializeComponent();
            label1.Text = "0";
            label4.Text = "0";
            label6.Text = "0";
        }

        //rysowanie i tworzenie bitmapy
        public void drawMethod()
        {
            p = new Pen(Brushes.White);
            r = new Rectangle(20, 20, 400, 400);
            btm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(btm);

            //rysowanie kwadratu
            g.DrawRectangle(p, r);

            //rysowanie okregu
            g.DrawEllipse(p, r);
        }
        //rysowanie punktu
        public void drawPoint(Bitmap btm, Rectangle r)
        {
            int x = rnd.Next(20, r.Width + 20);
            int y = rnd.Next(20, r.Height + 20);
            int centerx = r.Width / 2 + 20;
            int centery = r.Height / 2 + 20;

            //rysowanie punktu w losowym miejscu
            point = new Rectangle(x, y, 1, 1);
            g = Graphics.FromImage(btm);
            //odleglosc wylosowanego punktu od srodka okregu
            double dist = Math.Sqrt(Math.Pow(centerx - x, 2) + Math.Pow(centery - y, 2));
            //jezeli punkt lezy w okregu zmien jego kolor na czerwony
            if (dist < r.Width / 2)
            {
                p = new Pen(Brushes.Red);
                circlePoints++;
                label4.Text = circlePoints.ToString();
            }
            else
            {
                p = new Pen(Brushes.White);

            }
            //pomocnicze rysowanie srodka okregu
            //centerPoint = new Rectangle(centerx, centery, 1, 1);
            //g.DrawRectangle(p, centerPoint);
            g.DrawRectangle(p, point);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            drawMethod();
            pictureBox1.Image = btm;
            timer1.Start();
        }
        //z kazdym tickiem zegara rysuje punkt
        private void timer1_tick(object sender, EventArgs e)
        {
            drawPoint(btm, r);
            pictureBox1.Image = btm;
            points++;
            //wyswietlanie liczby wszystkich punktow
            label1.Text = points.ToString();
            //obliczanie pi za pomoca metody monte carlo
            pi = 4 * ((double)circlePoints / (double)points);
            label6.Text = pi.ToString();
        }
        //zatrzymanie timera i reset zmiennych
        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            circlePoints = 0;
            points = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //zerowanie zmiennych
            points = 0;
            circlePoints = 0;
            drawMethod();
            pictureBox1.Image = btm;
            //wczytywanie liczby wszystkich punktow z text boxa
            for (int i = 0; i < Convert.ToInt32(textBox1.Text); i++)
            {
                points++;
                drawPoint(btm, r);
                //obliczanie pi za pomoca metody monte carlo
                pi = 4 * ((double)circlePoints / (double)points);

            }
            //wyswietlanie wyniku
            label1.Text = points.ToString();
            label6.Text = pi.ToString();
        }
    }

}
