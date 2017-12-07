using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kermen
{
    public class YoungCoupleWithChildren: YounCouple
    {

        private const int NumberOfRooms = 2;
        private const decimal RoomElectricity = 30;

        private Child[] children;

        public YoungCoupleWithChildren(decimal salaryOne, decimal salaryTwo, decimal tvCost, decimal fridgeCost, decimal laptopCost, Child[] children) 
            : base(salaryOne + salaryTwo, NumberOfRooms, RoomElectricity, tvCost, fridgeCost)
        {
            this.children = children;
        }

        public override decimal Consumption
        {
            get { return this.children.Sum(x => x.GetTotalConsumption()) + base.Consumption; }
        }

        public override int Population
        {
            get { return base.Population + this.children.Length; }
        }
    }
}
