using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{

    public class Rectangle
    {
        public string id;
        public double width;
        public double height;
        public double x;
        public double y;

        public Rectangle(string id, double width, double height, double x, double y)
        {
            this.id = id;
            this.width = width;
            this.height = height;
            this.x = x;
            this.y = y;
        }
        public bool Intersect(Rectangle firstRectangle)
        {
            bool intersects = this.x + width >= firstRectangle.x && this.y + height >= firstRectangle.y;
            return intersects;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double[] inputArgs = input.Split().Select(double.Parse).ToArray();

            double numberOfRectangles = inputArgs[0];
            double numbersOfChecks = inputArgs[1];

            List<Rectangle> rectangles = new List<Rectangle>();

            for (int i = 0; i < numberOfRectangles; i++)
            {
                string[] info = Console.ReadLine().Split();
                string id = info[0];
                double width = double.Parse(info[1]);
                double height = double.Parse(info[2]);
                double x = double.Parse(info[3]);
                double y = double.Parse(info[4]);

                Rectangle rectangle = new Rectangle(id, width, height, x, y);
                rectangles.Add(rectangle);
            }

            for (int i = 0; i < numbersOfChecks; i++)
            {
                string[] commandsID = Console.ReadLine().Split();
                var firstRectangle = rectangles.First(x => x.id == commandsID[0]);
                var secondRectangle = rectangles.First(x => x.id == commandsID[1]);

                //Decide which is closer to coordinates 0,0 and became first

                if (firstRectangle.x <= secondRectangle.x && firstRectangle.y <= secondRectangle.y)
                {
                    Console.WriteLine(firstRectangle.Intersect(secondRectangle).ToString().ToLower());
                }
                else
                {
                    Console.WriteLine(secondRectangle.Intersect(firstRectangle).ToString().ToLower());
                }
            }

        }
    }
}
