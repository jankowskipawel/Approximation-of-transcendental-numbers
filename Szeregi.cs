using System;
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
    public partial class Szeregi : UserControl
    {
        public Szeregi()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 fourth = new Form4();
            fourth.ShowDialog();
        }
    }
}
