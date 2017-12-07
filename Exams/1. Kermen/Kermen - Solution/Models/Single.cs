using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kermen
{
    public abstract class Single : Household
    {
        public Single(decimal income, int numberOfRooms, decimal roomElectricity) 
            : base(income, numberOfRooms, roomElectricity)
        {
        }
    }
}
