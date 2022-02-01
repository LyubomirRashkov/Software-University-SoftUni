using System;
using System.Collections.Generic;
using System.Text;

namespace _09.PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string name, Pokemon pokemon)
        {
            Pokemons = new List<Pokemon>();

            Name = name;
            NumberOfBadges = 0;
            Pokemons.Add(pokemon);
        }

        public string Name { get; set; }

        public int NumberOfBadges { get; set; }

        public List<Pokemon> Pokemons { get; set; }
    }
}
