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
    public partial class CollidingBlocks : UserControl
    {
        public CollidingBlocks()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 third = new Form3();
            third.ShowDialog();

        }
    }
}
