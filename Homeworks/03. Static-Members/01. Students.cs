using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{

    public class Student
    {
        public string Name { get; set; }
        public static int Instances { get; set; }

        public Student(string name)
        {
            this.Name = name;
            Instances++;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "End")
            {
                Student student = new Student(input);

                input = Console.ReadLine();
            }
            Console.WriteLine(Student.Instances);

        }
    }
}
