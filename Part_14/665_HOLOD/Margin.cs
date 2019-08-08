using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _665_HOLOD_Upside
{
    public static class Margin
    {
        public static void SendIt(this string s)
        {
            Console.Write(s);
        }
        public static string ToPrice(this int n)
        {
            if (n == 1)
                return "a bucks ";
//  может поменять с другим блоком else
            else
                return "gets";
        }

        public static string Green(this bool b)
        {
            if (b == true)
                return "be";
//  может поменять с другим блоком else
            else
                return " more bucks";
        }
    }
}
