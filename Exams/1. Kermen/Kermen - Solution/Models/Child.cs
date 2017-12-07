using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kermen
{
    public class Child
    {
        decimal[] consumptions;

        public Child(decimal[] consumptions)
        {
            this.consumptions = consumptions;
        }

        public decimal GetTotalConsumption()
        {
            return this.consumptions.Sum();
        }
    }
}
