using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{

    public class Siamese : Cats
    {
        public decimal earSize;

        public Siamese(decimal earSize)
        {
            this.earSize = earSize;
        }
        public override string ToString()
        {
            return $"{this.breed} {this.name} {this.earSize}";
        }
    }

    public class Cymric : Cats
    {
        public decimal furLength;

        public Cymric(decimal furLength)
        {
            this.furLength = furLength;
        }
        public override string ToString()
        {
            return $"{this.breed} {this.name} {this.furLength}";
        }
    }

    public class StreetExtraordinaire : Cats
    {
        public decimal decibelsOfMeows;

        public StreetExtraordinaire(decimal decibels)
        {
            this.decibelsOfMeows = decibels;
        }
        public override string ToString()
        {
            return $"{this.breed} {this.name} {this.decibelsOfMeows}";
        }
    }
    public class Cats
    {
        public string breed;
        public string name;
    }

    class Program
    {
        static void Main(string[] args)
        {
            HashSet<Cats> cat = new HashSet<Cats>();

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] inputArgs = input.Split();
                string breed = inputArgs[0];
                string name = inputArgs[1];

                switch (breed)
                {
                    case "Siamese":
                        Cats siam = new Siamese(decimal.Parse(inputArgs[2]));
                        siam.name = name;
                        siam.breed = breed;
                        cat.Add(siam);

                        break;
                    case "Cymric":
                        Cats cym = new Cymric(decimal.Parse(inputArgs[2]));
                        cym.name = name;
                        cym.breed = breed;
                        cat.Add(cym);

                        break;
                    case "StreetExtraordinaire":
                        Cats street = new StreetExtraordinaire(decimal.Parse(inputArgs[2]));
                        street.name = name;
                        street.breed = breed;
                        cat.Add(street);

                        break;
                }
                input = Console.ReadLine();
            }
            string commandName = Console.ReadLine();
            var result = cat.First(x => x.name == commandName);
            Console.WriteLine(result.ToString());


        }
    }
}
