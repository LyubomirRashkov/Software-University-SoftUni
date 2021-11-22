using System;

namespace _02._Maiden_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            double partyPrice = double.Parse(Console.ReadLine());
            int loveMessages = int.Parse(Console.ReadLine());
            int roses = int.Parse(Console.ReadLine());
            int keychains = int.Parse(Console.ReadLine());
            int cartoons = int.Parse(Console.ReadLine());
            int lucks = int.Parse(Console.ReadLine());

            double sum = (loveMessages * 0.6) + (roses * 7.2) + (keychains * 3.6) + (cartoons * 18.2) + (lucks * 22);

            int numberOfProducts = loveMessages + roses + keychains + cartoons + lucks;

            if (numberOfProducts >= 25)
            {
                sum *= 0.65;
            }

            double clearSum = 0.9 * sum;

            if (clearSum >= partyPrice)
            {
                Console.WriteLine($"Yes! {(clearSum - partyPrice):f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {(partyPrice - clearSum):f2} lv needed.");
            }
        }
    }
}
