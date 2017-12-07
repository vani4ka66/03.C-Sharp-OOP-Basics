using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kermen
{
    public abstract class Household
    {
        private int numberOfRooms;
        private decimal roomElectricity;
        private readonly decimal income;
        private decimal balance;

        protected Household(decimal income, int numberOfRooms, decimal roomElectricity)
        {
            this.balance = 0;
            this.income = income;
            this.numberOfRooms = numberOfRooms;
            this.roomElectricity = roomElectricity;
        }

        public virtual int Population
        {
            get { return 1; }
        }

        public virtual decimal Consumption
        {
            get { return this.roomElectricity * this.numberOfRooms; }
        }

        public void GetIncome()
        {
            this.balance += this.income;
        }

        public bool CanPayBills()
        {
            return this.balance >= this.Consumption;
        }

        public void PayBills()
        {
            this.balance -= this.Consumption;
        }

    }
}
