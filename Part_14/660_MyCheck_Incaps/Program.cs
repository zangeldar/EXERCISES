using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _660_MyCheck_Incaps
{
    class Program
    {
        static void Main(string[] args)
        {
            MyCheckObject myCheckObj = new MyCheckObject("I am checkObject", "I am Object", 13);
            myCheckObj.TellMeAboutYourInside();
            Console.WriteLine("Now we try to reach read-only var..");
            Console.ReadKey();
            MyObject tmpObj = myCheckObj.MyObject;
            tmpObj.Clear();
            //tmpObj = new MyObject("other name", 31337);
            Console.WriteLine(".. done");
            Console.ReadKey();
            myCheckObj.TellMeAboutYourInside();
            Console.ReadKey();
        }
    }
}
