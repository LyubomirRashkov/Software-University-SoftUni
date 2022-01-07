using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HeroesOfCodeAndLogicVII
{
    public class Hero
    {
        public string Name { get; set; }

        public int HP { get; set; }

        public int MP { get; set; }

        public override string ToString()
        {
            return $"{Name}\n  HP: {HP}\n  MP: {MP}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int numberOfHeroes = int.Parse(Console.ReadLine());

            List<Hero> heroes = new List<Hero>(numberOfHeroes);

            for (int i = 0; i < numberOfHeroes; i++)
            {
                string[] heroInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string heroName = heroInfo[0];
                int heroHP = int.Parse(heroInfo[1]);
                int heroMP = int.Parse(heroInfo[2]);

                Hero hero = new Hero
                {
                    Name = heroName,
                    HP = heroHP,
                    MP = heroMP
                };

                heroes.Add(hero);
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                string[] commandParts = command
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                string currentCommand = commandParts[0];
                string requiredHero = commandParts[1];

                Hero currentHero = GetHeroByIndex(heroes, requiredHero);

                if (currentCommand == "CastSpell")
                {
                    int MPNeeded = int.Parse(commandParts[2]);
                    string spellName = commandParts[3];

                    if (currentHero.MP >= MPNeeded)
                    {
                        currentHero.MP -= MPNeeded;

                        Console.WriteLine($"{currentHero.Name} has successfully cast {spellName} and now has {currentHero.MP} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{currentHero.Name} does not have enough MP to cast {spellName}!");
                    }
                }
                else if (currentCommand == "TakeDamage")
                {
                    int damage = int.Parse(commandParts[2]);
                    string attacker = commandParts[3];

                    currentHero.HP -= damage;

                    if (currentHero.HP > 0)
                    {
                        Console.WriteLine($"{currentHero.Name} was hit for {damage} HP by {attacker} and now has {currentHero.HP} HP left!");
                    }
                    else
                    {
                        heroes.Remove(currentHero);

                        Console.WriteLine($"{currentHero.Name} has been killed by {attacker}!");
                    }
                }
                else if (currentCommand == "Recharge")
                {
                    int amount = int.Parse(commandParts[2]);

                    int temp = currentHero.MP;

                    currentHero.MP += amount;

                    if (currentHero.MP > 200)
                    {
                        currentHero.MP = 200;
                    }

                    Console.WriteLine($"{currentHero.Name} recharged for {currentHero.MP - temp} MP!");
                }
                else if (currentCommand == "Heal")
                {
                    int amount = int.Parse(commandParts[2]);

                    int temp = currentHero.HP;

                    currentHero.HP += amount;

                    if (currentHero.HP > 100)
                    {
                        currentHero.HP = 100;
                    }

                    Console.WriteLine($"{currentHero.Name} healed for {currentHero.HP - temp} HP!");
                }
            }

            List<Hero> sortedHeroes = heroes
                .OrderByDescending(h => h.HP)
                .ThenBy(h => h.Name)
                .ToList();

            foreach (Hero hero in sortedHeroes)
            {
                Console.WriteLine(hero);
            }
        }

        private static Hero GetHeroByIndex(List<Hero> heroes, string requiredHero)
        {
            for (int i = 0; i < heroes.Count; i++)
            {
                if (heroes[i].Name == requiredHero)
                {
                    return heroes[i];
                }
            }

            return heroes[-1];
        }
    }
}
