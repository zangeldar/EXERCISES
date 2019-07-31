using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cards;
using System.Runtime.Serialization.Formatters.Binary;

namespace _439_Compare
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] firstFile = File.ReadAllBytes("three-c.dat");
            byte[] secondFile = File.ReadAllBytes("six-h.dat");
            for (int i = 0; i < firstFile.Length; i++)
            {
                if (firstFile[i] != secondFile[i])
                    Console.WriteLine("Byte #{0}: {1} versus {2}",
                        i, firstFile[i], secondFile[i]);
            }
            Console.ReadKey();
            
            firstFile[233] = (byte)Suits.Spades;
            firstFile[273] = (byte)Values.King;
            File.Delete("king-s.dat");
            File.WriteAllBytes("king-s.dat", firstFile);

            using (Stream input = File.OpenRead("king-s.dat"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                Card cardFromFile = (Card)bf.Deserialize(input);
                Console.WriteLine("Card form file: {0}", cardFromFile.Name);
            }
            Console.ReadKey();                        
        }
    }
}
