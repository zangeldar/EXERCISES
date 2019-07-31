using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _512_DelegateCuisine
{
    class Suzanne
    {
        public GetSecretIngridient MySecretIngridientMethod
        {
            get
            {
                return new GetSecretIngridient(SuzannesSecretIngridient);
            }
        }
        private string SuzannesSecretIngridient(int amount)
        {
            return amount.ToString() + " ounces of cloves";
        }
    }
}
