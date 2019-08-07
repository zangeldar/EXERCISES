using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _658_Robust
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input birthday date:");
            string birthday = Console.ReadLine();
            Console.WriteLine("Input height inches:");
            string height = Console.ReadLine();
            RobustGuy guy = new RobustGuy(birthday, height);
            Console.WriteLine(guy.ToString());
            Console.ReadKey();
        }
    }
}
