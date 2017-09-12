using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{

    public class BeerCounter
    {
        private static int beerInStock;
        private static int beerDrankCount;

        public static int BeerInStock
        {
            get
            {
                return beerInStock;
            }
            set
            {
                beerInStock = value;
            }
        }
        public static int BeerDrankCount
        {
            get
            {
                return beerDrankCount;
            }
            set
            {
                beerDrankCount = value;
            }
        }


        public static void BuyBeer(int bottlesCount)
        {
            BeerInStock += bottlesCount; ;
        }

        public static void DrinkBeer(int bottlesCount)
        {
            beerDrankCount += bottlesCount;
            BeerInStock -= bottlesCount;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] inputArgs = input.Split();
                int beerBought = int.Parse(inputArgs[0]);
                int beerDrank = int.Parse(inputArgs[1]);

                BeerCounter.BuyBeer(beerBought);
                BeerCounter.DrinkBeer(beerDrank);

                input = Console.ReadLine();
            }

            Console.WriteLine("{0} {1}", BeerCounter.BeerInStock, BeerCounter.BeerDrankCount);


        }
    }
}
