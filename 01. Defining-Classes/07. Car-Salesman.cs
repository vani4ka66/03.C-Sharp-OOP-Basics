using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{

    public class Car
    {
        public string model;
        public Engine engine;
        public object weight { get; set; }
        public string color { get; set; }

        public Car(string carModel, string engineModel)
        {
            this.model = carModel;
            this.engine = new Engine(engineModel);
            this.weight = "n/a";
            this.color = "n/a";
        }
        public override string ToString()
        {
            return string.Format("{0}", model);
        }
    }
    public class Engine
    {
        public string model;
        public int power { get; set; }
        public object displacement { get; set; }
        public string efficiency { get; set; }

        public Engine(string model)
        {
            this.model = model;
            this.power = power;
            this.displacement = "n/a";
            this.efficiency = "n/a";
        }
        public override string ToString()
        {
            return string.Format("{0}", power);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Engine = model - power - displacement - efficiency
            //Car = model, engine, weight, color
            List<Car> carsList = new List<Car>();
            List<Engine> engineList = new List<Engine>();


            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string engineModel = input[0];
                int power = int.Parse(input[1]);

                Engine engins = new Engine(engineModel);
                engins.power = power;

                if (input.Length == 4)
                {
                    engins.displacement = int.Parse(input[2]);
                    engins.efficiency = input[3];
                }
                else if (input.Length == 2)
                {
                    engins.displacement = "n/a";
                    engins.efficiency = input[3];
                }
                else if (input.Length == 3)
                {
                    int displacement;
                    bool isInt = int.TryParse(input[2], out displacement);
                    if (isInt)
                    {
                        engins.efficiency = "n/a";
                        engins.displacement = displacement;
                    }
                    else
                    {
                        engins.efficiency = input[2];
                        engins.displacement = "n/a";
                    }
                }
                engineList.Add(engins);

            }
            int m = int.Parse(Console.ReadLine());
            for (int i = 0; i < m; i++)
            {
                string[] input = Console.ReadLine().Trim().Split();
                Car cars = new Car(input[0], input[1]);
                if (input.Length == 4)
                {
                    cars.weight = int.Parse(input[2]);
                    cars.color = input[3];
                }
                else if (input.Length == 2)
                {
                    cars.weight = "n/a";
                    cars.color = "n/a";
                }
                else if (input.Length == 3)
                {
                    int weight;
                    bool isParsed = int.TryParse(input[2], out weight);

                    if (isParsed)
                    {
                        cars.weight = weight;
                        cars.color = "n/a";
                    }
                    else
                    {
                        cars.color = input[2];
                        cars.weight = "n/a";
                    }
                }
                carsList.Add(cars);
            }

            foreach (var item in carsList)
            {
                Console.WriteLine(item.model + ":");
                foreach (var pair in engineList)
                {
                    if (pair.model.Equals(item.engine.model))
                    {
                        Console.WriteLine("  " + pair.model + ':');
                        Console.WriteLine("    Power: {0}", pair.power);
                        Console.WriteLine("    Displacement: {0}", pair.displacement);
                        Console.WriteLine("    Efficiency: {0}", pair.efficiency);
                    }
                }
                Console.WriteLine("  Weight: {0}", item.weight);
                Console.WriteLine("  Color: {0}", item.color);
            }

        }
    }
}
