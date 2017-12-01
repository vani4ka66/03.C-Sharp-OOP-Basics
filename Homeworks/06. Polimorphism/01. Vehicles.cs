using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{
    //62% solved!!!
    
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumptionPerKm;

        protected Vehicle(double fuelQuantity, double fuelConsumptionPerKm)
        {
            this.Fuel = fuelQuantity;
            this.ConsumptionPerKm = fuelConsumptionPerKm;
        }

        public double Fuel { get; set; }

        public virtual double ConsumptionPerKm { get; set; }

        public virtual void Driven(double distance)
        {
            double possibleDistance = this.Fuel / this.ConsumptionPerKm;

            if (distance <= possibleDistance)
            {
                this.Fuel -= distance * this.ConsumptionPerKm;
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }

        public abstract void Refuel(double liters);


        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.Fuel:F2}";
        }

    }

    public class Car : Vehicle
    {
        public Car(double fuel, double consumptionPerKm)
            : base(fuel, consumptionPerKm)
        {

        }

        public override double ConsumptionPerKm
        {
            get { return base.ConsumptionPerKm; }
            set { base.ConsumptionPerKm = value + 0.9; }
        }

        public override void Refuel(double liters)
        {
            base.Fuel += liters;
        }
    }

    public class Truck : Vehicle
    {
        public Truck(double fuel, double consumptionPerKm)
            : base(fuel, consumptionPerKm)
        {

        }

        public override double ConsumptionPerKm
        {
            get { return this.Fuel; }
            set { base.ConsumptionPerKm = value + 1.6; }
        }

        public override void Refuel(double liters)
        {
            base.Fuel += liters * 0.95;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            double carFuel = double.Parse(input[1]);
            double carConsumption = double.Parse(input[2]);

            Car car = new Car(carFuel, carConsumption);

            string[] input2 = Console.ReadLine().Split();
            double truckFuel = double.Parse(input2[1]);
            double truckConsumption = double.Parse(input2[2]);

            Truck truck = new Truck(truckFuel, truckConsumption);

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input3 = Console.ReadLine().Split();
                string command = input3[0].ToLower();
                string typeOfVehicle = input3[1].ToLower();
                double distance = double.Parse(input3[2]);

                switch (command.ToLower())
                {
                    case "drive":
                        if (typeOfVehicle == "car")
                        {
                            car.Driven(distance);
                        }
                        else
                        {
                            truck.Driven(distance);
                        }
                        break;
                    case "refuel":
                        if (typeOfVehicle == "car")
                        {
                            car.Refuel(distance);
                        }
                        else
                        {
                            truck.Refuel(distance);
                        }
                        break;

                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);

        }
    }
}
