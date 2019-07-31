using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _435_Symbols
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            File.WriteAllText("eureka.txt", "Eureka!");

            byte[] eurekaBytes = File.ReadAllBytes("eureka.txt");
            if (cbReverse.Checked)
                Array.Reverse(eurekaBytes);            
            foreach (byte b in eurekaBytes)
            {
                Console.Write("{0} ", b);
            }
            Console.WriteLine();
            File.WriteAllBytes("eureka.txt", eurekaBytes);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            File.WriteAllText("eureka.txt", "Eureka!");

            byte[] eurekaBytes = File.ReadAllBytes("eureka.txt");
            if (cbReverse.Checked)
                Array.Reverse(eurekaBytes);
            foreach (byte b in eurekaBytes)
            {
                Console.Write("{0:x2} ", b);
            }
            Console.WriteLine();
            File.WriteAllBytes("eureka.txt", eurekaBytes);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            File.WriteAllText("eureka.txt", "שלום", Encoding.Unicode);

            byte[] eurekaBytes = File.ReadAllBytes("eureka.txt");
            if (cbReverse.Checked)
                Array.Reverse(eurekaBytes);            
            foreach (byte b in eurekaBytes)
            {
                Console.Write("{0:x2} ", b);
            }
            Console.WriteLine();
            File.WriteAllBytes("eureka.txt", eurekaBytes);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string eurekaResult;
            eurekaResult = File.ReadAllText("eureka.txt");
            Console.WriteLine(eurekaResult);
        }
    }
}
