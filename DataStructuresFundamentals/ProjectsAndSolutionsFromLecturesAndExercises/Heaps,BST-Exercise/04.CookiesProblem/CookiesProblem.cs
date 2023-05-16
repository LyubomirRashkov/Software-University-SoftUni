using _03.MinHeap;
using System;

namespace _04.CookiesProblem
{
	public class CookiesProblem
	{
		public int Solve(int minSweetness, int[] cookies)
		{
			MinHeap<int> minHeap = new MinHeap<int>();

			foreach (var cookie in cookies)
			{
				minHeap.Add(cookie);
			}

			int counter = 0;

			while (minHeap.Count > 1)
			{
				int leastSweetCookie = minHeap.ExtractMin();

				if (leastSweetCookie > minSweetness)
				{
					break;
				}

				int secondCookie = minHeap.ExtractMin();

				int newCookie = leastSweetCookie + (2 * secondCookie);

				minHeap.Add(newCookie);

				counter++;
			}

			int newLeastSweetCookie = minHeap.ExtractMin();

			return (newLeastSweetCookie > minSweetness) ? counter : -1;
		}
	}
}
