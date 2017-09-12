using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{

    public class Calculation
    {
        public const double Plank = 6.62606896e-34;
        private const double Pi = 3.14159;

        public Calculation()
        {

        }
        public static void ReducedPlanck()
        {
            double result = Plank / (2 * Pi);
            Console.WriteLine(result);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Calculation.ReducedPlanck();
        }
    }
}
