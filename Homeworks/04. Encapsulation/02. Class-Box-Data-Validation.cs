using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{
    public class Box
    {
        private double lenght;
        private double width;
        private double height;

        public Box(double lenght, double width, double height)
        {
            this.Length = lenght;
            this.Width = width;
            this.Height = height;
        }

        public double GetSurfaceArea()
        {
            double result = 2 * this.lenght * this.width + 2 * this.lenght * this.height + 2 * this.width * this.height;
            return result;
        }
        public double GetLateralArea()
        {
            double result = 2 * this.lenght * this.height + 2 * this.width * this.height;
            return result;
        }
        public double GetVolume()
        {
            double result = this.lenght * this.width * this.height;
            return result;
        }

        public double Length
        {
            get { return this.lenght; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }
                this.lenght = value;
            }
        }
        public double Width
        {
            get { return this.width; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
                this.width = value;
            }
        }
        public double Height
        {
            get { return this.height; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
                this.height = value;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Type boxType = typeof(Box);
            FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine(fields.Count());

            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            try
            {
                Box box = new Box(length, width, height);
                Console.WriteLine("Surface Area - {0:F2}", box.GetSurfaceArea());
                Console.WriteLine("Lateral Surface Area - {0:F2}", box.GetLateralArea());
                Console.WriteLine("Volume - {0:F2}", box.GetVolume());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

        }
    }
}
