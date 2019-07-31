using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _512_DelegateCuisine
{
    class Amy
    {
        public GetSecretIngridient AmysSecretIngridientMethod
        {
            get
            {
                return new GetSecretIngridient(AmysSecretIngridient);
            }
        }

        private string AmysSecretIngridient(int amount)
        {
            if (amount < 10)
                return amount.ToString() + " cans of sardines -- you need more!";
            else
                return amount.ToString() + " cans of sardines";
        }
    }
}
