namespace Demo
{
    using System;
	using System.Collections.Generic;
	using System.Linq;
	using Tree;

    class Program
    {
        static void Main(string[] args)
        {
            int sumOfPaths = 27;
            int sumOfSubtrees = 43;

            string[] input = new string[] { "7 19", "7 21", "7 14", "19 1", "19 12", "19 31", "14 23", "14 6" };

            IntegerTreeFactory factory = new IntegerTreeFactory();

            IntegerTree tree = factory.CreateTreeFromStrings(input);

            PrintResults(tree, sumOfPaths, sumOfSubtrees);
        }

		private static void PrintResults(IntegerTree tree, int targetSumOfPaths, int targetSumOfSubtrees)
		{
			Console.WriteLine("The tree as string is:");
			Console.WriteLine(tree.AsString());

			Console.WriteLine();

			Console.WriteLine($"Values of the leaf nodes are: {string.Join(' ', tree.GetLeafKeys())}");

			Console.WriteLine();

			Console.WriteLine($"Values of the internal nodes are: {string.Join(' ', tree.GetInternalKeys())}");

			Console.WriteLine();

			Console.WriteLine($"Value of the deepest leftmost node is: {tree.GetDeepestKey()}");

			Console.WriteLine();

			Console.WriteLine($"The longest leftmost path is: {string.Join(' ', tree.GetLongestPath())}");

			Console.WriteLine();

			Console.WriteLine($"Paths with sum equal to {targetSumOfPaths} are:");
			Console.WriteLine(string.Join(Environment.NewLine, tree.GetPathsWithGivenSum(targetSumOfPaths).Select(c => string.Join(' ', c))));

			Console.WriteLine();

			Console.WriteLine($"Subtrees with sum equal to {targetSumOfSubtrees} are:");

			IEnumerable<Tree<int>> trees = tree.GetSubtreesWithGivenSum(targetSumOfSubtrees);

			foreach (var item in trees)
			{
				Console.WriteLine(item.AsString());
			}
		}
	}
}
