using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{

    public class Student
    {
        public static HashSet<string> uniqeNames;
        public string name;

        public Student(string name)
        {
            this.name = name;
        }

        static Student()
        {
            uniqeNames = new HashSet<string>();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            while (name != "End")
            {
                Student student = new Student(name);
                Student.uniqeNames.Add(name);
                name = Console.ReadLine();
            }
            Console.WriteLine(Student.uniqeNames.Count);


        }
    }
}
