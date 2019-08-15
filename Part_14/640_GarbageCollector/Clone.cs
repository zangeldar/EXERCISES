using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _640_GarbageCollector
{
    [Serializable]
    class Clone : IDisposable
    {
        public int Id { get; private set; }
        public Clone(int Id)
        {
            this.Id = Id;
        }
        public void Dispose()
        {
            string dirname = @Program.GetPathToExe() + @"\";
            string filename = dirname + "Clone.dat";
            if (!Directory.Exists(dirname))
            {
                Directory.CreateDirectory(dirname);
            }
            BinaryFormatter bf = new BinaryFormatter();
            using (Stream output = File.OpenWrite(filename))
            {
                bf.Serialize(output, this);
            }
            

            MessageBox.Show("I've been disposed!",
                "Clone #" + Id + " says...");
        }

        ~Clone()
        {
            int i = 0;
            try
            {
                int a = 12 / i;
            }
            catch (Exception ex)
            {
                MessageBox.Show("I just caught an exception",
                    "Clone #" + Id + " says...");
            }

            MessageBox.Show("Aaargh! You got me!",
                "Clone #" + Id + " says...");
        }
    }
}
