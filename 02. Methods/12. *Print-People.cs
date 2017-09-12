using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{

    public class Persons : IComparable<Persons>
    {
        public string name;
        public int age;
        public string occupation;

        public Persons(string name, int age, string occupation)
        {
            this.name = name;
            this.age = age;
            this.occupation = occupation;
        }
        public int CompareTo(Persons other)
        {
            return this.age.CompareTo(other.age);
        }
        public override string ToString()
        {
            return $"{name} - age: {age}, occupation: {occupation}";
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Persons> personsList = new List<Persons>();
            while (input != "END")
            {
                string[] info = input.Split();
                string personName = info[0];
                int personAge = int.Parse(info[1]);
                string personOccupation = info[2];

                Persons person = new Persons(personName, personAge, personOccupation);
                personsList.Add(person);
                input = Console.ReadLine();
            }
            personsList.Sort();

            foreach (var item in personsList)
            {
                Console.WriteLine(item.ToString());
            }

        }
    }
}
