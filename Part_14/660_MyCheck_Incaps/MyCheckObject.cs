using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _660_MyCheck_Incaps
{
    class MyCheckObject
    {
        private string checkName;
        private MyObject myObject;
        public MyObject MyObject { get { return myObject; } }

        public MyCheckObject(string checkName, string nameOf, int idOf)
        {
            this.checkName = checkName;
            myObject = new MyObject(nameOf, idOf);
        }

        public void TellMeAboutYourInside()
        {
            if (myObject == null)
                Console.WriteLine("Ooops, I don't have any inside");
            else
                Console.WriteLine("I have inside object with ID: {0} and it tell: {1}", myObject.Id, myObject.Name);
        }
    }
}
