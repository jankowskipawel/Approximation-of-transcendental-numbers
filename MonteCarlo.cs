﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApproximationOfTranscendentalNumbers
{
    public partial class MonteCarlo : UserControl
    {
        public MonteCarlo()
        {
            InitializeComponent();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 second = new Form2();
            
            second.ShowDialog();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
