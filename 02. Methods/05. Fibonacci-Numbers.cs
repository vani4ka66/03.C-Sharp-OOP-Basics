using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{
    public class Fibonacci
    {
        private List<long> list;

        public Fibonacci(int end)
        {
            list = new List<long>();

            list.Add(0L);
            list.Add(1L);
            list.Add(1L);

            for (int i = 3; i < end; i++)
            {
                list.Add(list[i - 2] + list[i - 1]);
            }
        }

        public List<long> GetNumbersInRange(int start, int end)
        {
            List<long> result = new List<long>();

            for (int i = start; i < end; i++)
            {
                result.Add(list[i]);
            }
            return result;
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            int startNumber = int.Parse(Console.ReadLine());
            int endNumber = int.Parse(Console.ReadLine());

            Fibonacci fib = new Fibonacci(endNumber);
            Console.WriteLine(string.Join(", ", fib.GetNumbersInRange(startNumber, endNumber)));

        }
    }
}
