using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace August2017
{

    public class Pizza
    {
        public static SortedDictionary<int, List<string>> pizzasByGroups = new SortedDictionary<int, List<string>>();

        public string name;
        public int group;

        public Pizza(int group, string name)
        {
            this.group = group;
            this.name = name;
        }

        public static SortedDictionary<int, List<string>> GetPizzas(params int[] groups)
        {
            if (groups.Length == 0)
            {
                return Pizza.pizzasByGroups;
            }
            SortedDictionary<int, List<string>> selectGroups = new SortedDictionary<int, List<string>>();

            foreach (var item in groups)
            {
                List<string> pizzas = Pizza.pizzasByGroups[item];
                selectGroups.Add(item, pizzas);
            }
            return selectGroups;
        }

        public static void PrintPizzas()
        {
            foreach (var item in pizzasByGroups)
            {
                Console.WriteLine(item.Key + " - " + string.Join(", ", item.Value));
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MethodInfo[] methods = typeof(Pizza).GetMethods();
            bool containsMethod = methods.Any(m => m.ReturnType.Name.Equals("SortedDictionary`2"));
            if (!containsMethod)
            {
                throw new Exception();
            }

            string[] rawPizzas = Console.ReadLine().Split();
            string pattern = @"(\d+)(\w+)";
            List<Pizza> pizzas = new List<Pizza>();
            Regex matcher = new Regex(pattern);

            for (int i = 0; i < rawPizzas.Length; i++)
            {
                Match match = matcher.Match(rawPizzas[i]);
                Pizza pizza = new Pizza(int.Parse(match.Groups[1].Value), match.Groups[2].Value);

                if (!Pizza.pizzasByGroups.ContainsKey(int.Parse(match.Groups[1].Value)))
                {
                    Pizza.pizzasByGroups.Add(int.Parse(match.Groups[1].Value), new List<string>());
                }
                Pizza.pizzasByGroups[int.Parse(match.Groups[1].Value)].Add(match.Groups[2].Value);
            }
            //Pizza.PrintPizzas();
            var selectPizzas = Pizza.GetPizzas();
            foreach (var item in selectPizzas)
            {
                Console.WriteLine("{0} - {1}", item.Key, string.Join(", ", item.Value));
            }

        }
    }
}
