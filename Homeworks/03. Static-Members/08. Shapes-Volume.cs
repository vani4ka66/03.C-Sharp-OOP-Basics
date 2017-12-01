using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{

    public class VolumeCalculator
    {
        public static void CubeVolume(double a)
        {
            double result = Math.Pow(a, 3);
            Console.WriteLine("{0:F3}", result);
        }
        public static void CylinderVolume(double a, double b)
        {
            double result = b * Math.PI * Math.Pow(a, 2);
            Console.WriteLine("{0:F3}", result);
        }
        public static void TriangularPrismVolume(double b, double h, double l)
        {
            double result = ((b * h) / 2) * l;
            Console.WriteLine("{0:F3}", result);
        }
    }
    public class TriangularPrism
    {
        public double baseSide;
        public double height;
        public double length;

        public TriangularPrism(double b, double h, double l)
        {
            this.baseSide = b;
            this.height = h;
            this.length = l;
        }

    }

    public class Cube
    {
        public double length;

        public Cube(double a)
        {
            this.length = a;
        }
    }

    public class Cylinder
    {
        public double radius;
        public double height;

        public Cylinder(double radius, double height)
        {
            this.radius = radius;
            this.height = height;
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
                string figure = inputArgs[0];

                switch (figure)
                {
                    case "Cube":
                        VolumeCalculator.CubeVolume(double.Parse(inputArgs[1]));
                        break;
                    case "TrianglePrism":
                        VolumeCalculator.TriangularPrismVolume(double.Parse(inputArgs[1]), double.Parse(inputArgs[2]), double.Parse(inputArgs[3]));
                        break;
                    case "Cylinder":
                        VolumeCalculator.CylinderVolume(double.Parse(inputArgs[1]), double.Parse(inputArgs[2]));
                        break;
                }

                input = Console.ReadLine();

            }

        }
    }
}
