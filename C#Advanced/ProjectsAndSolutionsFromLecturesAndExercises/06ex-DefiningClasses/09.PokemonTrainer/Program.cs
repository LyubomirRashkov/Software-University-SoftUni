using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonTrainer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainersByName = new Dictionary<string, Trainer>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Tournament")
                {
                    break;
                }

                string[] infoParts = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string trainerName = infoParts[0];
                string pokemonName = infoParts[1];
                string pokemonElement = infoParts[2];
                int pokemonHealth = int.Parse(infoParts[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (!trainersByName.ContainsKey(trainerName))
                {
                    Trainer trainer = new Trainer(trainerName, pokemon);

                    trainersByName.Add(trainerName, trainer);
                }
                else
                {
                    trainersByName[trainerName].Pokemons.Add(pokemon);
                }
            }

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                string targetElement = line;

                foreach (var kvp in trainersByName)
                {
                    bool hasAPokemonWithTheTargetElement = false;

                    foreach (Pokemon pokemon in kvp.Value.Pokemons)
                    {
                        if (pokemon.Element == targetElement)
                        {
                            hasAPokemonWithTheTargetElement = true;
                            break;
                        }
                    }

                    if (hasAPokemonWithTheTargetElement)
                    {
                        kvp.Value.NumberOfBadges++;
                    }
                    else
                    {
                        foreach (Pokemon pokemon in kvp.Value.Pokemons)
                        {
                            pokemon.Health -= 10;
                        }

                        kvp.Value.Pokemons.RemoveAll(p => p.Health <= 0);
                    }
                }
            }

            Dictionary<string, Trainer> sortedTrainers = trainersByName
                .OrderByDescending(t => t.Value.NumberOfBadges)
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var kvp in sortedTrainers)
            {
                Console.WriteLine($"{kvp.Key} {kvp.Value.NumberOfBadges} {kvp.Value.Pokemons.Count}");
            }
        }
    }
}
