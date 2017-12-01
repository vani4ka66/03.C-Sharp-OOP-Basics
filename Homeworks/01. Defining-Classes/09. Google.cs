using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{
    public class Persons
    {
        public string name;
        public Company company;
        public Car car;
        public List<Pokemon> pokemons;
        public List<Parents> parents;
        public List<Children> children;

        public Persons()
        {
            this.pokemons = new List<Pokemon>();
            this.parents = new List<Parents>();
            this.children = new List<Children>();
        }
        public Persons(Company company) : this()
        {
            this.company = company;
        }
        public Persons(Car car) : this()
        {
            this.car = car;
        }
    }
    public class Company
    {
        public string companyName;
        public string department;
        public double salary;

        public Company(string companyName, string department, double salary)
        {
            this.companyName = companyName;
            this.department = department;
            this.salary = salary;
        }
    }

    public class Car
    {
        public string carModel;
        public int carSpeed;

        public Car(string carModel, int carSpeed)
        {
            this.carModel = carModel;
            this.carSpeed = carSpeed;
        }
    }

    public class Pokemon
    {
        public string pokemonName;
        public string pokemonType;

        public Pokemon(string pokemonName, string pokemonType)
        {
            this.pokemonName = pokemonName;
            this.pokemonType = pokemonType;
        }
    }

    public class Parents
    {
        public string parentName;
        public string parentBirthDay;

        public Parents(string parentName, string parentBirthDay)
        {
            this.parentName = parentName;
            this.parentBirthDay = parentBirthDay;
        }
    }

    public class Children
    {
        public string childrenName;
        public string childrenBirthDay;

        public Children(string childrenName, string childrenBirthDay)
        {
            this.childrenName = childrenName;
            this.childrenBirthDay = childrenBirthDay;
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
                string personName = inputArgs[0];
                string dataType = inputArgs[1];

                switch (dataType)
                {
                    case "company":
                        Company currentCompany = new Company(inputArgs[2], inputArgs[3], double.Parse(inputArgs[4]));
                        if (!map.ContainsKey(personName))
                        {
                            map.Add(personName, new Persons(currentCompany));
                        }
                        map[personName].company = currentCompany;
                        break;
                    case "pokemon":
                        Pokemon currentPokemon = new Pokemon(inputArgs[2], inputArgs[3]);
                        if (!map.ContainsKey(personName))
                        {
                            map.Add(personName, new Persons());
                        }
                        map[personName].pokemons.Add(currentPokemon);
                        break;
                    case "parents":
                        Parents currentParent = new Parents(inputArgs[2], inputArgs[3]);
                        if (!map.ContainsKey(personName))
                        {
                            map.Add(personName, new Persons());
                        }
                        map[personName].parents.Add(currentParent);
                        break;
                    case "children":
                        Children currentChildren = new Children(inputArgs[2], inputArgs[3]);
                        if (!map.ContainsKey(personName))
                        {
                            map.Add(personName, new Persons());
                        }
                        map[personName].children.Add(currentChildren);

                        break;
                    case "car":
                        Car currentCar = new Car(inputArgs[2], int.Parse(inputArgs[3]));
                        if (!map.ContainsKey(personName))
                        {
                            map.Add(personName, new Persons(currentCar));
                        }
                        map[personName].car = currentCar;
                        break;
                }
                input = Console.ReadLine();
            }

            string command = Console.ReadLine();
            Persons currentPerson = map[command];
            Console.WriteLine(command);
            Console.Write("Company:");
            Console.WriteLine(currentPerson.company != null ? string.Format("\n{0} {1} {2:F2}",
                currentPerson.company.companyName, currentPerson.company.department, currentPerson.company.salary) : "");
            Console.Write("Car:");
            Console.WriteLine(currentPerson.car != null ? string.Format("\n{0} {1}",
                currentPerson.car.carModel, currentPerson.car.carSpeed) : "");
            Console.WriteLine("Pokemon:");
            currentPerson.pokemons.ForEach(x => Console.WriteLine($"{ x.pokemonName} { x.pokemonType} "));
            Console.WriteLine("Parents:");
            currentPerson.parents.ForEach(x => Console.WriteLine($"{x.parentName} {x.parentBirthDay}"));
            Console.WriteLine("Children:");
            currentPerson.children.ForEach(x => Console.WriteLine($"{x.childrenName} {x.childrenBirthDay}"));
        }

    }
}

