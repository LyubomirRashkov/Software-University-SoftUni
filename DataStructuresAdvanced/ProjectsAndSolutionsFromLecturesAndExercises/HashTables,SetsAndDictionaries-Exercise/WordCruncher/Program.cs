using System;
using System.Collections.Generic;
using System.Linq;

namespace WordCruncher
{
	/*
	// Solution with transforming the target word:
	class Program
	{
		static void Main()
		{
			string[] wordParts = Console.ReadLine()
	            .Split(", ", StringSplitOptions.RemoveEmptyEntries);

			string targetWord = Console.ReadLine();

			Engine engine = new Engine(wordParts, targetWord);

			IEnumerable<string> variations = engine.GetWordPartsVariations();

			if (variations.Count() > 0)
			{
				foreach (var variation in variations)
				{
					Console.WriteLine(variation);
				}
			}
		}
	}

	class Engine
	{
		private class Node
		{
			public Node(string wordPart, List<Node> nextWordParts)
			{
				this.WordPart = wordPart;
				this.NextWordParts = nextWordParts;
			}

			public string WordPart { get; set; }

			public List<Node> NextWordParts { get; set; }
		}

		private List<Node> wordPartsGroups;

		public Engine(string[] wordParts, string targetWord)
		{
			this.wordPartsGroups = this.GenerateWordPartsGroups(wordParts, targetWord);
		}

		public IEnumerable<string> GetWordPartsVariations()
		{
			List<List<string>> allVariations = new List<List<string>>();

			this.GenerateVariations(this.wordPartsGroups, new List<string>(), allVariations);

			return new HashSet<string>(allVariations.Select(v => string.Join(" ", v)));
		}

		private List<Node> GenerateWordPartsGroups(string[] wordParts, string targetWord)
		{
			if (wordParts.Length == 0 || string.IsNullOrWhiteSpace(targetWord))
			{
				return null;
			}

			List<Node> resultValues = new List<Node>();

			for (int i = 0; i < wordParts.Length; i++)
			{
				string wordPart = wordParts[i];

				if (targetWord.StartsWith(wordPart))
				{
					List<Node> nextWordParts = this.GenerateWordPartsGroups(
						wordParts.Where((_, index) => index != i).ToArray(),
						targetWord.Substring(wordPart.Length)
						);

					resultValues.Add(new Node(wordPart, nextWordParts));
				}
			}

			return resultValues;
		}

		private void GenerateVariations(
			List<Node> wordPartsGroups, 
			List<string> currentVariation, 
			List<List<string>> allVariations)
		{
			if (wordPartsGroups is null)
			{
				allVariations.Add(new List<string>(currentVariation));

				return;
			}

			foreach (var node in wordPartsGroups)
			{
				currentVariation.Add(node.WordPart);

				this.GenerateVariations(node.NextWordParts, currentVariation, allVariations);

				currentVariation.RemoveAt(currentVariation.Count - 1);
			}
		}
	}
	*/

	// Solution without transforming the target word (only iterate through it):
	class Program
	{
		private static string targetWord;
		private static Dictionary<int, List<string>> collectionOfWordPartsByIndex;
		private static Dictionary<string, int> wordPartsCount;
		private static LinkedList<string> usedWordParts;

		static void Main()
		{
			string[] wordParts = Console.ReadLine()
				.Split(", ", StringSplitOptions.RemoveEmptyEntries);

			targetWord = Console.ReadLine();

			collectionOfWordPartsByIndex = new Dictionary<int, List<string>>();

			wordPartsCount = new Dictionary<string, int>();

			foreach (var wordPart in wordParts)
			{
				int index = targetWord.IndexOf(wordPart);

				if (index == -1)
				{
					continue;
				}

				if (wordPartsCount.ContainsKey(wordPart))
				{
					wordPartsCount[wordPart]++;

					continue;
				}

				wordPartsCount[wordPart] = 1;

				while (index != -1)
				{
					if (!collectionOfWordPartsByIndex.ContainsKey(index))
					{
						collectionOfWordPartsByIndex[index] = new List<string>();
					}

					collectionOfWordPartsByIndex[index].Add(wordPart);

					index = targetWord.IndexOf(wordPart, index + wordPart.Length);
				}
			}

			usedWordParts = new LinkedList<string>();

			GenerateSolutions(0);
		}

		private static void GenerateSolutions(int index)
		{
			if (index == targetWord.Length)
			{
                Console.WriteLine(string.Join(" ", usedWordParts));

				return;
            }

			if (!collectionOfWordPartsByIndex.ContainsKey(index))
			{
				return;
			}

			foreach (var wordPart in collectionOfWordPartsByIndex[index])
			{
				if (wordPartsCount[wordPart] == 0)
				{
					continue;
				}

				usedWordParts.AddLast(wordPart);

				wordPartsCount[wordPart]--;

				GenerateSolutions(index + wordPart.Length);

				usedWordParts.RemoveLast();

				wordPartsCount[wordPart]++;
			}
		}
	}
}
