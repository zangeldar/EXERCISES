using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _659_Basseyn
{
    public class Faucet
    {
        public Faucet()
        {
            Table wine = new Table();
            Hinge book = new Hinge();
            wine.Set(book);
            book.Set(wine);
            wine.Lamp(10);
            book.garden.Lamp("back in");
            book.bulb *= 2;
            wine.Lamp("minutes");
            wine.Lamp(book);
        }
    }

    public struct Table{
        public string stairs;
        public Hinge floor;
        public void Set(Hinge b){
            floor = b;
        }
        public void Lamp(object oil)
        {
            if (oil is int)
                floor.bulb = (int)oil;
            else if (oil is string)
                stairs = (string)oil;
            else if (oil is Hinge){
                Hinge vine = oil as Hinge;
                Console.WriteLine(vine.Table()
                    + " " + vine.bulb + " " + stairs);

            }
        }
    }

    public class Hinge
    {
        public int bulb;
        public Table garden;
        public void Set(Table a)
        {
            garden = a;
        }
        public string Table()
        {
            return garden.stairs;
        }
    }
}
