using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _662_Extend_Sealed
{
    class Program
    {
        static void Main(string[] args)
        {
            OrdinaryHuman steve = new OrdinaryHuman(85);
            Console.WriteLine(steve.BreakWalls(3.56));

            Console.ReadKey();
        }
    }
}
