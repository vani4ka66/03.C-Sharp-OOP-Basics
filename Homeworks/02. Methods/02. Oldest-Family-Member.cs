using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{

    public class Person
    {
        public string name;
        public int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
    }
    public class Family
    {
        public List<Person> persons;

        public Family()
        {
            this.persons = new List<Person>();
        }

        public void AddMember(Person member)
        {
            this.persons.Add(member);
        }

        public Person GetOldestMember()
        {
            return this.persons.OrderByDescending(x => x.age).First();
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
            MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
            if (oldestMemberMethod == null || addMemberMethod == null)
            {
                throw new Exception();
            }

            int numberOfPersons = int.Parse(Console.ReadLine());
            Family family = new Family();
            for (int i = 0; i < numberOfPersons; i++)
            {
                string[] personInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Person person = new Person(personInfo[0], int.Parse(personInfo[1]));
                family.AddMember(person);
            }
            var oldestPerson = family.GetOldestMember();
            Console.WriteLine($"{oldestPerson.name} {oldestPerson.age}");



        }
    }
}
