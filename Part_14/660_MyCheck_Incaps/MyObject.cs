using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _660_MyCheck_Incaps
{
    class MyObject
    {
        private string name;
        private int id;

        public MyObject(string name, int id)
        {
            this.name = name;
            this.id = id;
        }

        public string Name { get { return name; } }
        public int Id { get { return id; } }

        public void Clear()
        {
            name = "<blank>";
            id = 0;
        }
    }
}
