using System;
using System.Collections.Generic;

namespace _03.Raiding
{
    public class StartUp
    {
        public static void Main()
        {
            int targetCountOfHeroes = int.Parse(Console.ReadLine());

            List<BaseHero> heroes = new List<BaseHero>();

            while (heroes.Count < targetCountOfHeroes)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                BaseHero hero = CreateHero(heroName, heroType);

                if (hero == null)
                {
                    Console.WriteLine("Invalid hero!");
                    continue;
                }

                heroes.Add(hero);
            }

            int bossHealthPoints = int.Parse(Console.ReadLine());   

            foreach (BaseHero hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());

                bossHealthPoints -= hero.Power;
            }

            if (bossHealthPoints <= 0)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }

        private static BaseHero CreateHero(string heroName, string heroType)
        {
            BaseHero hero = null;

            if (heroType == nameof(Druid))
            {
                hero = new Druid(heroName);
            }
            else if (heroType == nameof(Paladin))
            {
                hero = new Paladin(heroName);
            }
            else if (heroType == nameof(Rogue))
            {
                hero = new Rogue(heroName);
            }
            else if (heroType == nameof(Warrior))
            {
                hero = new Warrior(heroName);
            }

            return hero;
        }
    }
}
