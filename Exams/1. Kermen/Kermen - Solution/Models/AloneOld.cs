using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kermen
{
    public class AloneOld : Single
    {
        private const int NumberOfRooms = 1;
        private const decimal RoomElectricity = 15;

        public AloneOld(decimal pension) 
            : base(pension, NumberOfRooms, RoomElectricity)
        {
        }
    }
}
