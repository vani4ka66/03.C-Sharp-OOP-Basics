using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{

    public class MathUtil
    {
        public MathUtil()
        {

        }

        public static void Sum(double a, double b)
        {
            Console.WriteLine("{0:F2}", a + b);
        }
        public static void Subtract(double a, double b)
        {
            Console.WriteLine("{0:F2}", a - b);
        }
        public static void Multiply(double a, double b)
        {
            Console.WriteLine("{0:F2}", a * b);
        }
        public static void Divide(double a, double b)
        {
            Console.WriteLine("{0:F2}", a / b);
        }
        public static void Percentage(double a, double b)
        {
            double c = (a * b) / 100;
            Console.WriteLine("{0:F2}", c);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] line = input.Split();
                string command = line[0];
                double a = double.Parse(line[1]);
                double b = double.Parse(line[2]);

                switch (command)
                {
                    case "Sum":
                        MathUtil.Sum(a, b);
                        break;
                    case "Subtract":
                        MathUtil.Subtract(a, b);
                        break;
                    case "Multiply":
                        MathUtil.Multiply(a, b);
                        break;
                    case "Divide":
                        MathUtil.Divide(a, b);
                        break;
                    case "Percentage":
                        MathUtil.Percentage(a, b);
                        break;
                }
                input = Console.ReadLine();

            }

        }
    }
}
