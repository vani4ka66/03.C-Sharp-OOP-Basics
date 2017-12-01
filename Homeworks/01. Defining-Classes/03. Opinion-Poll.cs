using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{
    public class Person
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public string Name
        {
            get { return this.name; }
        }

        public int Age
        {
            get { return this.age; }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                var personInfo = Console.ReadLine().Split();
                Person person = new Person(personInfo[0], int.Parse(personInfo[1]));
                people.Add(person);
            }
            people.Where(x => x.Age > 30)
                .OrderBy(x => x.Name)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.Name} - {x.Age}"));
        }

    }
}

