using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _479_Holod_Except
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("when it ");
            ExTestDrive.Zero("yes");
            Console.Write(" it ");
            ExTestDrive.Zero("no");
            Console.WriteLine(".");
            Console.ReadKey();
        }
    }

    class MyException : Exception { }

    class ExTestDrive
    {
        public static void Zero(string test)
        {
            Console.Write("t");
            try
            {
                DoRisky(test);
                Console.Write("o");
            }
            catch (MyException)
            {
                Console.Write("a");   
            }
            finally
            {
                Console.Write("w");
                Console.Write("s");
            }
        }

        static void DoRisky(String t)
        {   
            Console.Write("h");

            if (t == "yes")
            {
                throw new MyException();                             
            }
            Console.Write("r");
        }
    }
}
