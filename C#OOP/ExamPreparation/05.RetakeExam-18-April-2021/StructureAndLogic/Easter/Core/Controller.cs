using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Repositories;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Core
{
    public class Controller : IController
    {
        private const int RequiredEnergy = 50;

        private BunnyRepository bunnies;
        private EggRepository eggs;
        private Workshop workshop;
        private int countOfColoredEggs;

        public Controller()
        {
            this.bunnies = new BunnyRepository();
            this.eggs = new EggRepository();
            this.workshop = new Workshop();
            this.countOfColoredEggs = 0;
        }

        public string AddBunny(string bunnyType, string bunnyName)
        {
            if (bunnyType != nameof(HappyBunny) && bunnyType != nameof(SleepyBunny))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }

            IBunny bunny = this.CreateBunny(bunnyType, bunnyName);

            this.bunnies.Add(bunny);

            return String.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IBunny bunny = this.bunnies.FindByName(bunnyName);

            if (bunny == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }

            IDye dye = new Dye(power);
            bunny.AddDye(dye);

            return String.Format(OutputMessages.DyeAdded, power, bunnyName);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);
            this.eggs.Add(egg);

            return String.Format(OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {
            IEgg egg = this.eggs.FindByName(eggName);

            List<IBunny> sortedBunnies = this.bunnies.Models
                                                            .Where(b => b.Energy >= RequiredEnergy)
                                                            .OrderByDescending(b => b.Energy)
                                                            .ToList();

            if (!sortedBunnies.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }

            for (int i = 0; i < sortedBunnies.Count; i++)
            {
                this.workshop.Color(egg, sortedBunnies[i]);

                if (sortedBunnies[i].Energy == 0)
                {
                    this.bunnies.Remove(sortedBunnies[i]);
                    sortedBunnies.RemoveAt(i);
                    i--;
                }

                if (egg.IsDone())
                {
                    countOfColoredEggs++;

                    return String.Format(OutputMessages.EggIsDone, eggName);
                }
            }

            return String.Format(OutputMessages.EggIsNotDone, eggName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{countOfColoredEggs} eggs are done!");
            sb.AppendLine("Bunnies info:");

            foreach (IBunny bunny in this.bunnies.Models)
            {
                sb.AppendLine(bunny.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        private IBunny CreateBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny = null;

            if (bunnyType == nameof(HappyBunny))
            {
                bunny = new HappyBunny(bunnyName);
            }
            else
            {
                bunny = new SleepyBunny(bunnyName);
            }

            return bunny;
        }
    }
}
