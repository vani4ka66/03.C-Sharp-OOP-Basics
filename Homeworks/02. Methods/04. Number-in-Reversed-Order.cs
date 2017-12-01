using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{

    public class DecimalNumber
    {
        public string number;

        public DecimalNumber(string lastDigit)
        {
            this.number = lastDigit;
        }

        public static string Reverse(string lastDigit)
        {
            string result = "";
            for (int i = lastDigit.Length - 1; i >= 0; i--)
            {
                result += lastDigit[i];
            }
            return result;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            string n = Console.ReadLine();
            string m = DecimalNumber.Reverse(n);
            Console.WriteLine(m);

        }
    }
}
