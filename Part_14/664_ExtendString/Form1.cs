using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _664_MyExtension;

namespace _664_ExtendString
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = "The farm is destroing by clones! Help!";
            if (message.IsDistressCall())
                MessageBox.Show("Already on a way to farm!");
        }
    }
}
