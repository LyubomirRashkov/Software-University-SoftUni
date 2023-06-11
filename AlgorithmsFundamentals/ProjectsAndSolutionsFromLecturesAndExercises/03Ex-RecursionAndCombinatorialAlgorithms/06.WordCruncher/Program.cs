using System;
using System.Collections.Generic;

namespace _06.WordCruncher
{
	public class Program
	{
		private static string targetWord;
		private static Dictionary<int, List<string>> collectionOfWordsByIndex;
		private static Dictionary<string, int> wordsCount;
		private static LinkedList<string> usedWords;

		public static void Main(string[] args)
		{
			string[] words = Console.ReadLine()
				.Split(", ", StringSplitOptions.RemoveEmptyEntries);

			targetWord = Console.ReadLine();

			collectionOfWordsByIndex = new Dictionary<int, List<string>>();

			wordsCount = new Dictionary<string, int>();

			foreach (var word in words)
			{
				int index = targetWord.IndexOf(word);

				if (index == -1)
				{
					continue;
				}

				if (wordsCount.ContainsKey(word))
				{
					wordsCount[word]++;

					continue;
				}

				wordsCount[word] = 1;

				while (index != -1)
				{
					if (!collectionOfWordsByIndex.ContainsKey(index))
					{
						collectionOfWordsByIndex[index] = new List<string>();
					}

					collectionOfWordsByIndex[index].Add(word);

					index = targetWord.IndexOf(word, index + word.Length);
				}
			}

			usedWords = new LinkedList<string>();

			GenerateSolutions(0);
		}

		private static void GenerateSolutions(int index)
		{
			if (index == targetWord.Length)
			{
				Console.WriteLine(string.Join(' ', usedWords));

				return;
			}

			if (!collectionOfWordsByIndex.ContainsKey(index))
			{
				return;
			}

			foreach (var word in collectionOfWordsByIndex[index])
			{
				if (wordsCount[word] == 0)
				{
					continue;
				}

				usedWords.AddLast(word);

				wordsCount[word]--;

				GenerateSolutions(index + word.Length);

				usedWords.RemoveLast();

				wordsCount[word]++;
			}
		}
	}
}
