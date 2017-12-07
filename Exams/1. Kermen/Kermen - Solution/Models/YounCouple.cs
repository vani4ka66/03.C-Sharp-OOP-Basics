using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kermen
{
    public class YounCouple : Couple
    {
        private const int NumberOfRooms = 2;
        private const decimal RoomElectricity = 20;

        private decimal laptopCost;


        public YounCouple(decimal salaryOne, decimal salaryTwo, decimal tvCost, decimal fridgeCost, decimal laptopCost)
            : base(NumberOfRooms, RoomElectricity, salaryOne + salaryTwo, tvCost, fridgeCost)
        {
            this.laptopCost = laptopCost;
        }

        protected YounCouple(int numberOfRooms, decimal roomElectricity, decimal income, decimal tvCost, decimal fridgeCost, decimal laptopCost) 
            : base(numberOfRooms, roomElectricity, income, tvCost, fridgeCost)
        {
            this.laptopCost = laptopCost;
        }

        public override decimal Consumption
        {
            get { return base.Consumption + this.laptopCost * 2; }
        }
    }
}
