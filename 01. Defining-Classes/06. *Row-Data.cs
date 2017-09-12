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
        public Cargo cargo;
        public Tire[] tires;

        public Car(string model, int speed, int power, int weight, string type,
            double pressure1, int age1, double pressure2, int age2,
            double pressure3, int age3, double pressure4, int age4)
        {
            this.model = model;
            engine = new Engine(speed, power);
            cargo = new Cargo(weight, type);
            tires = new Tire[4];
            tires[0] = new Tire(pressure1, age1);
            tires[1] = new Tire(pressure2, age2);
            tires[2] = new Tire(pressure3, age3);
            tires[3] = new Tire(pressure4, age4);
        }
        public override string ToString()
        {
            return string.Format("{0}", model);
        }
    }

    public class Engine
    {
        public int engineSpeed;
        public int enginePower;

        public Engine(int engineSpeed, int enginePower)
        {
            this.engineSpeed = engineSpeed;
            this.enginePower = enginePower;
        }
    }

    public class Cargo
    {
        public int cargoWeight;
        public string cargoType;

        public Cargo(int cargoWeight, string cargoType)
        {
            this.cargoWeight = cargoWeight;
            this.cargoType = cargoType;
        }
    }

    public class Tire
    {
        public double pressure;
        public int age;

        public Tire(double p, int a)
        {
            pressure = p;
            age = a;
        }

    }



    class Program
    {
        static void Main(string[] args)
        {
            List<Car> listCars = new List<Car>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Trim().Split();

                Car carss = new Car(info[0], int.Parse(info[1]), int.Parse(info[2]), int.Parse(info[3]), info[4], double.Parse(info[5]), int.Parse(info[6]), double.Parse(info[7]),
                    int.Parse(info[8]), double.Parse(info[9]), int.Parse(info[10]), double.Parse(info[11]), int.Parse(info[12]));

                listCars.Add(carss);
            }
            string command = Console.ReadLine();

            if (command == "fragile")
            {
                listCars.Where(x => x.cargo.cargoType == "fragile" && x.tires.Any(y => y.pressure < 1))
                                    .Select(x => x.model).ToList().ForEach(car => Console.WriteLine(car));
            }
            else if (command == "flamable")
            {
                listCars.Where(x => x.cargo.cargoType == "flamable" && x.engine.enginePower > 250)
                    .Select(x => x.model)
                    .ToList()
                    .ForEach(car => Console.WriteLine(car));
            }

        }
    }
}
