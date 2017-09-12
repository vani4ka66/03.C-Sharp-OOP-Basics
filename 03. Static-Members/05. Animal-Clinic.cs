using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{
    public class Animal
    {
        private string name;
        private string breed;

        public Animal(string n, string b)
        {
            this.Name = n;
            this.Breed = b;
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string Breed
        {
            get
            {
                return breed;
            }
            set
            {
                breed = value;
            }
        }
    }

    public class AnimalClinic
    {
        private static string patientId;
        private static int healedAnimalCount;
        private static int rehabAnimalCount;

        public AnimalClinic(string name, int healedCount, int RehabCount)
        {

        }

        public static string PatientId
        {
            get
            {
                return patientId;
            }
            set
            {
                patientId = value;
            }
        }
        public static int HealedAnimalCount
        {
            get
            {
                return healedAnimalCount;
            }
            set
            {
                healedAnimalCount = value;
            }
        }
        public static int RehabAnimalCount
        {
            get
            {
                return rehabAnimalCount;
            }
            set
            {
                rehabAnimalCount = value;
            }
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> healedAnimals = new List<Animal>();
            List<Animal> rehabAnimals = new List<Animal>();
            List<Animal> allAnimals = new List<Animal>();

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] inputArgs = input.Split();
                string name = inputArgs[0];
                string breed = inputArgs[1];
                string command = inputArgs[2];

                Animal animal = new Animal(name, breed);

                if (command == "heal")
                {
                    healedAnimals.Add(animal);
                    allAnimals.Add(animal);
                    AnimalClinic.HealedAnimalCount++;
                    AnimalClinic.PatientId = animal.Name + " " + animal.Breed;
                }
                else
                {
                    rehabAnimals.Add(animal);
                    allAnimals.Add(animal);
                    AnimalClinic.RehabAnimalCount++;
                    AnimalClinic.PatientId = animal.Name + " " + animal.Breed;
                }

                input = Console.ReadLine();
            }
            input = Console.ReadLine();

            int number = 1;
            bool isHealed = false;
            foreach (var pair in allAnimals)
            {
                Console.Write("Patient {0}: [", number++);
                Console.Write(pair.Name + " (" + pair.Breed + ")] has been ");
                if (healedAnimals.Count != 0)
                {
                    if (healedAnimals[0].Name.Contains(pair.Name))
                    {
                        Console.WriteLine("healed!");
                        isHealed = true;
                    }
                    else
                    {
                        Console.WriteLine("rehabilitated!");
                        isHealed = false;
                    }
                }
                else
                {
                    if (healedAnimals.Count == 0)
                    {
                        Console.WriteLine("rehabilitated!");
                        isHealed = false;
                    }
                    else
                    {
                        Console.WriteLine("healed!");
                        isHealed = true;
                    }
                }

            }

            Console.WriteLine("Total healed animals: {0}", AnimalClinic.HealedAnimalCount);
            Console.WriteLine("Total rehabilitated animals: {0}", AnimalClinic.RehabAnimalCount);
            if (isHealed)
            {
                foreach (var item in healedAnimals)
                {
                    Console.WriteLine(item.Name + " " + item.Breed);
                }
            }
            else
            {
                foreach (var item in rehabAnimals)
                {
                    Console.WriteLine(item.Name + " " + item.Breed);
                }
            }

        }
    }
}
