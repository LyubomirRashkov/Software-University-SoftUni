namespace SetCover
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<int> universe = Console.ReadLine()
                                  .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                  .Select(int.Parse)
                                  .ToList();

            List<int[]> sets = new List<int[]>();

            int numberOfSets = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfSets; i++)
            {
                int[] set = Console.ReadLine()
                             .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                             .Select(int.Parse)
                             .ToArray();

                sets.Add(set);
            }

            List<int[]> selectedSets = ChooseSets(sets, universe);

            Console.WriteLine($"Sets to take ({selectedSets.Count}):");

            foreach (int[] set in selectedSets)
            {
                Console.WriteLine($"{{ {string.Join(", ", set)} }}");
            }
        }

        public static List<int[]> ChooseSets(IList<int[]> sets, IList<int> universe)
        {
            List<int[]> selectedSets = new List<int[]>();

            while (universe.Count > 0)
            {
                int[] currentSet = sets.OrderByDescending(set => set.Count(el => universe.Contains(el))).FirstOrDefault();

                selectedSets.Add(currentSet);

                sets.Remove(currentSet);

                foreach (int element in currentSet)
                {
                    universe.Remove(element);
                }
            }

            return selectedSets;
        }
    }
}
