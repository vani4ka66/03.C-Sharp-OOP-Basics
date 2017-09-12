using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{
    public class Car
    {
        public double speed;
        public double fuel;
        public double fuelEconomy;
        public double travelledDistance;
        public double travelledTime;

        public Car(double speed, double fuel, double fuelEconomy)
        {
            this.speed = speed;
            this.fuel = fuel;
            this.fuelEconomy = fuelEconomy;
        }

        public void Travelled(double distance)
        {
            double possibleDistance = this.fuel / this.fuelEconomy * 100;

            if (distance <= possibleDistance)
            {
                this.fuel -= this.fuelEconomy * (distance / 100);
                this.travelledDistance += distance;
                this.travelledTime += distance / this.speed * 60;

            }
            else
            {
                this.travelledDistance += possibleDistance;
                this.fuel = 0;
                this.travelledTime += possibleDistance / this.speed * 60;
            }
        }

        public void Refuel(double refuelLiters)
        {
            this.fuel += refuelLiters;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            double speed = double.Parse(input[0]);
            double fuel = double.Parse(input[1]);
            double fuelEconomy = double.Parse(input[2]);

            Car car = new Car(speed, fuel, fuelEconomy);

            string[] command = Console.ReadLine().Split();
            while (command[0] != "END")
            {
                switch (command[0])
                {
                    case "Travel":
                        double distance = double.Parse(command[1]);
                        car.Travelled(distance);
                        break;
                    case "Refuel":
                        double refuelLiters = double.Parse(command[1]);
                        car.Refuel(refuelLiters);
                        break;
                    case "Distance":
                        Console.WriteLine($"Total distance: {car.travelledDistance:F1} kilometers");
                        break;
                    case "Time":
                        Console.WriteLine("Total time: {0} hours and {1} minutes",
                            car.travelledTime / 60, car.travelledTime % 60);
                        break;
                    case "Fuel":
                        Console.WriteLine($"Fuel left: {car.fuel:F1} liters");
                        break;
                }
                command = Console.ReadLine().Split();
            }

        }
    }
}
