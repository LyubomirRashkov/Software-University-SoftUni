using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System.Linq;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public Workshop()
        {
        }

        public void Color(IEgg egg, IBunny bunny)
        {
            while (bunny.Energy > 0 && !egg.IsDone())
            {
                IDye dye = bunny.Dyes.FirstOrDefault(d => !d.IsFinished());

                if (dye == null)
                {
                    break;
                }

                bunny.Work();
                dye.Use();
                egg.GetColored();
            }
        }
    }
}
