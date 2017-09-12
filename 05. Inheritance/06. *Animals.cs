using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{

    public abstract class Animal
    {
        private string whatKindOfAnimal;
        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender, string whatKindOfAnimal)
        {
            this.whatKindOfAnimal = whatKindOfAnimal;
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException();
                }
                this.name = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException();
                }
                this.age = value;
            }
        }

        public virtual string Gender
        {
            get { return this.gender; }
            set
            {
                if (string.IsNullOrEmpty(value) || value != "Female" && value != "Male")
                {
                    throw new ArgumentNullException();
                }

                this.gender = value;
            }
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            return $"{this.whatKindOfAnimal}\n{this.Name} {this.Age} {this.Gender}\n{ProduceSound()}";
        }

    }

    public class Dog : Animal
    {
        public Dog(string name, int age, string gender, string whatKindOfAnimal)
            : base(name, age, gender, whatKindOfAnimal)
        {
        }

        public override string ProduceSound()
        {
            return "BauBau";
        }

    }

    public class Frog : Animal
    {
        public Frog(string name, int age, string gender, string whatKindOfAnimal)
            : base(name, age, gender, whatKindOfAnimal)
        {
        }

        public override string ProduceSound()
        {
            return "Frogggg";
        }

    }

    public class Cat : Animal
    {
        public Cat(string name, int age, string gender, string whatKindOfAnimal)
            : base(name, age, gender, whatKindOfAnimal)
        {
        }

        public override string ProduceSound()
        {
            return "MiauMiau";
        }

    }

    public class Kitten : Cat
    {
        public Kitten(string name, int age, string whatKindOfAnimal)
            : base(name, age, "Female", whatKindOfAnimal)
        {

        }

        public override string Gender
        {
            set
            {
                if (value != "Female")
                {
                    throw new ArgumentException();
                }
                base.Gender = value;
            }
        }

        public override string ProduceSound()
        {
            return "Miau";
        }
    }

    public class Tomcat : Cat
    {
        public Tomcat(string name, int age, string whatKindOfAnimal)
            : base(name, age, "Male", whatKindOfAnimal)
        {
        }

        public override string ProduceSound()
        {
            return "Give me one million b***h";
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animalList = new List<Animal>();

            try
            {
                while (true)
                {

                    string input = Console.ReadLine();
                    if (input == "Beast!")
                    {
                        break;
                    }
                    string[] inputArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    string name = inputArgs[0];
                    int age = int.Parse(inputArgs[1]);
                    string gender = inputArgs[2];

                    switch (input)
                    {
                        case "Cat":
                            Animal cat = new Cat(name, age, gender, input);
                            animalList.Add(cat);
                            break;
                        case "Dog":
                            Animal dog = new Dog(name, age, gender, input);
                            animalList.Add(dog);
                            break;
                        case "Frog":
                            Animal frog = new Frog(name, age, gender, input);
                            animalList.Add(frog);
                            break;
                        case "Kitten":
                            Animal kitten = new Kitten(name, age, input);
                            animalList.Add(kitten);
                            break;
                        case "Tomcat":
                            Animal tomCat = new Tomcat(name, age, input);
                            animalList.Add(tomCat);
                            break;
                        case "Animal":
                            Console.WriteLine("Not implemented!");
                            break;
                    }

                }
                foreach (var item in animalList)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input!");
            }

        }
    }
}
