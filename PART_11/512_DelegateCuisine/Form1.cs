using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _512_DelegateCuisine
{
    public partial class Form1 : Form
    {
        GetSecretIngridient ingridientMethod = null;
        Suzanne suzanne = new Suzanne();
        Amy amy = new Amy();

        public Form1()
        {
            InitializeComponent();            
        }
        private void useIngridientButton_Click(object sender, EventArgs e)
        {
            if (ingridientMethod != null)
                Console.WriteLine("I'll add " + ingridientMethod((int)amountNum.Value));
            else
                Console.WriteLine("I don't have a secret ingridient!");
        }
        private void getSuzanneButton_Click(object sender, EventArgs e)
        {
            ingridientMethod = new GetSecretIngridient(suzanne.MySecretIngridientMethod);
        }

        private void getAmyButton_Click(object sender, EventArgs e)
        {
            ingridientMethod = new GetSecretIngridient(amy.AmysSecretIngridientMethod);
        }


    }
}
