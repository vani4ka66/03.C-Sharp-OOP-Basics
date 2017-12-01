using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{

    public class Trainer
    {
        public string nameTrainer;
        public int numberOfBadges;
        public List<Pokemon> pokemons;

        public Trainer(string nameTrainer, int numberOfBadges, List<Pokemon> pokemons)
        {
            this.nameTrainer = nameTrainer;
            this.numberOfBadges = numberOfBadges;
            this.numberOfBadges = numberOfBadges;
            this.pokemons = pokemons;
        }

    }

    public class Pokemon
    {
        public string namePokemon;
        public string element;
        public int health;

        public Pokemon(string namePokemon, string element, int health)
        {
            this.namePokemon = namePokemon;
            this.element = element;
            this.health = health;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            List<Trainer> allTrainers = new List<Trainer>();
            Dictionary<string, List<Pokemon>> map = new Dictionary<string, List<Pokemon>>();

            string input = Console.ReadLine();

            while (input != "Tournament")
            {
                // TrainerName > < PokemonName > < PokemonElement > < PokemonHealth 
                string[] inputArgs = input.Split();
                string nameTrainer = inputArgs[0];
                string namePokemon = inputArgs[1];
                string element = inputArgs[2];
                int health = int.Parse(inputArgs[3]);

                Pokemon pok = new Pokemon(namePokemon, element, health);

                if (!map.ContainsKey(nameTrainer))
                {
                    map.Add(nameTrainer, new List<Pokemon>());
                }
                map[nameTrainer].Add(pok);

                input = Console.ReadLine();
            }
            Console.WriteLine();
            foreach (var pair in map)
            {
                Trainer train = new Trainer(pair.Key, 0, pair.Value);
                allTrainers.Add(train);
            }

            input = Console.ReadLine();
            while (input != "End")
            {
                allTrainers = allTrainers.Select(x =>
                {
                    if (x.pokemons.Any(y => y.element == input))
                    {
                        x.numberOfBadges++;
                    }
                    else
                    {
                        x.pokemons.ForEach(y => y.health -= 10);
                        x.pokemons.RemoveAll(y => y.health <= 0);
                    }
                    return x;
                }).ToList();

                input = Console.ReadLine();
            }
            allTrainers.OrderByDescending(x => x.numberOfBadges)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.nameTrainer} {x.numberOfBadges} {x.pokemons.Count}"));
        }

    }
}

