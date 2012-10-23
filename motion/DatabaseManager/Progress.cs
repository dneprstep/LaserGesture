using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TIRDatabase
{
    public partial class Progress : Form
    {
        public Progress()
        {
            InitializeComponent();
        }
        public void SetBarSize(int size)
        {
            progressBar1.Maximum = size;
        }
        public void Increment()
        {
            progressBar1.Value++;
        }
    }
}
