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
        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.products = new List<Product>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }

        public List<Product> Products => products;

        public decimal Money
        {
            get { return this.money; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }

        public void AddProduct(Product product)
        {
            if (this.Money < product.Cost)
            {
                throw new InvalidOperationException($"{this.Name} can't afford {product.Name}");
            }
            this.products.Add(product);
            this.Money -= product.Cost;
        }
    }



    public class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }

        public decimal Cost
        {
            get { return this.cost; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.cost = value;
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            var allPersons = new Dictionary<string, Person>();
            string[] inputPersons = Console.ReadLine()
                                           .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                                           .ToArray();
            for (int i = 0; i < inputPersons.Length; i++)
            {
                string[] personInfo = inputPersons[i]
                                    .Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries)
                                    .ToArray();

                string personName = personInfo[0];
                decimal personMoney = decimal.Parse(personInfo[1]);
                try
                {
                    Person person = new Person(personName, personMoney);
                    if (!allPersons.ContainsKey(personName))
                    {
                        allPersons[personName] = person;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }
            var allProducts = new Dictionary<string, Product>();
            string[] inputProducts = Console.ReadLine()
                                            .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                                            .ToArray();
            for (int i = 0; i < inputProducts.Length; i++)
            {
                string[] productInfo = inputProducts[i]
                    .Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string productName = productInfo[0];
                decimal productCost = decimal.Parse(productInfo[1]);
                try
                {
                    Product product = new Product(productName, productCost);
                    if (!allProducts.ContainsKey(productName))
                    {
                        allProducts[productName] = product;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }
            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] purchaseInfo = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string requestPerson = purchaseInfo[0];
                string requestProduct = purchaseInfo[1];

                var person = allPersons[requestPerson];
                var product = allProducts[requestProduct];
                try
                {
                    person.AddProduct(product);
                    Console.WriteLine($"{person.Name} bought {product.Name}");
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                input = Console.ReadLine();
            }
            foreach (var person in allPersons.Values)
            {
                Console.WriteLine("{0} - {1}",
                    person.Name,
                    person.Products.Count == 0 ?
                    "Nothing bought" : string.Join(", ", person.Products.Select(p => p.Name)));
            }

        }
    }
}
