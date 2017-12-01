using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{
    // 57% solved!!!
    public class Number
    {
        public int n;
        public bool isTrue;

        public Number(int n)
        {
            this.n = n;
        }

        public string isPrime(int n)
        {
            int square = (int)Math.Sqrt(n);
            if (n == 1 || n == 0)
            {
                return "true";
            }
            else
            {
                for (int i = 2; i <= square; i++)
                {
                    if (n % i == 0)
                    {
                        return "false";
                    }
                }
            }
            return "true";
        }
        public static int NextNumber(int n)
        {
            while (true)
            {
                n = n + 1;
                bool isPrime = true;

                int square = (int)Math.Sqrt(n);

                for (int i = 2; i <= square; i++)
                {
                    if (n % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    return n;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Number num = new Number(n);
            string isPrimes = num.isPrime(n);
            int m = Number.NextNumber(n);
            Console.WriteLine(m + ", " + isPrimes);

        }
    }
}
