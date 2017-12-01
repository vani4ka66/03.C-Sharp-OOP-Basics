using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{

    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumptionPerKm;
        private double tankCapacity;

        protected Vehicle(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
        {
            this.Fuel = fuelQuantity;
            this.ConsumptionPerKm = fuelConsumptionPerKm;
            this.TankCapacity = tankCapacity;
        }

        public double Fuel
        {
            get { return this.fuelQuantity; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Fuel must be a positive number");
                }
                this.fuelQuantity = value;
            }
        }

        public double TankCapacity
        {
            get { return tankCapacity; }
            set { this.tankCapacity = value; }
        }

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
        public Car(double fuel, double consumptionPerKm, double tankCapacity)
            : base(fuel, consumptionPerKm, tankCapacity)
        {

        }

        public override double ConsumptionPerKm
        {
            get { return base.ConsumptionPerKm; }
            set { base.ConsumptionPerKm = value + 0.9; }
        }

        public override void Refuel(double liters)
        {
            if ((base.Fuel + liters) > base.TankCapacity)
            {
                Console.WriteLine("Cannot fit fuel in tank");
            }
            else
            {
                base.Fuel += liters;

            }
        }

        public void AirConditioner()
        {
            base.ConsumptionPerKm += 1.4;
        }
    }

    public class Truck : Vehicle
    {
        public Truck(double fuel, double consumptionPerKm, double tank)
            : base(fuel, consumptionPerKm, tank)
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

    public class Bus : Vehicle
    {
        public Bus(double fuel, double consumptionPerKm, double tankCapacity)
           : base(fuel, consumptionPerKm, tankCapacity)
        {
        }

        public override void Refuel(double litres)
        {
            if ((base.Fuel + litres) > base.TankCapacity)
            {
                Console.WriteLine("Cannot fit fuel in tank");
            }
            else
            {
                base.Fuel += litres;
            }
        }

        public void TurnOnAirConditioner()
        {
            base.ConsumptionPerKm += 1.4;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            double carFuel = double.Parse(input[1]);
            double carConsumption = double.Parse(input[2]);
            double carTank = double.Parse(input[3]);

            Car car = new Car(carFuel, carConsumption, carTank);

            string[] input2 = Console.ReadLine().Split();
            double truckFuel = double.Parse(input2[1]);
            double truckConsumption = double.Parse(input2[2]);
            double truckTank = double.Parse(input2[3]);

            Truck truck = new Truck(truckFuel, truckConsumption, truckTank);

            string[] busInfo = Console.ReadLine()
                                    .Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
            double busFuel = double.Parse(busInfo[1]);
            double busConsumption = double.Parse(busInfo[2]);
            double busTank = double.Parse(busInfo[3]);
            Bus bus = new Bus(busFuel, busConsumption, busTank);

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
                        else if (typeOfVehicle == "truck")
                        {
                            truck.Driven(distance);
                        }
                        else if (typeOfVehicle == "bus")
                        {
                            bus.TurnOnAirConditioner();
                            bus.Driven(distance);
                        }

                        break;
                    case "refuel":
                        if (typeOfVehicle == "car")
                        {
                            car.Refuel(distance);
                        }
                        else if (typeOfVehicle == "truck")
                        {
                            truck.Refuel(distance);
                        }
                        else if (typeOfVehicle == "bus")
                        {
                            bus.Refuel(distance);
                        }
                        break;
                    case "driveempty":
                        bus.Driven(distance);
                        break;
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);

        }
    }
}
