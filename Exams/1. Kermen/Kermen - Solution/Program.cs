using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kermen.Factories;

namespace Kermen
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Household> kermen = new List<Household>();
            int counter = 0;

            while (input != "Democracy")
            {
                counter++;

                try
                {
                    Household entity = HouseHoldFactory.CreateHouseHold(input);
                    kermen.Add(entity);
                }
                catch (Exception)
                {
                    Console.WriteLine("Cannot create HouseHold");
                }

                if (counter %3 == 0)
                {
                    kermen.ForEach(x => x.GetIncome());
                }

                if (input == "EVN bill")
                {
                    kermen.RemoveAll(x => !x.CanPayBills());
                    kermen.ForEach(x => x.PayBills());

                }
                else if (input == "EVN")
                {
                    Console.WriteLine($"Total consumption: {kermen.Sum(x => x.Consumption)}");
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"Total population: {kermen.Sum(x => x.Population)}");
        }
    }
}
