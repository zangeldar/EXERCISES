using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _662_Extend_Sealed
{
    sealed class OrdinaryHuman
    {
        private int age;
        int weight;

        public OrdinaryHuman(int weight)
        {
            this.weight = weight;
        }

        public void GoToWork() { Console.WriteLine("I going to work! I'd like my job!"); }
        public void PayBills() { Console.WriteLine("Again? So many bills, I haven't a lot of money.."); }

    }
}
