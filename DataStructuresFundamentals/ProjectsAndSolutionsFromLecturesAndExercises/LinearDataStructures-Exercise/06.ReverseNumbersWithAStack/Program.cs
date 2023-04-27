int[] inputArray = Console.ReadLine()
	.Split(' ', StringSplitOptions.RemoveEmptyEntries)
	.Select(int.Parse)
	.ToArray();

Stack<int> numbers = new Stack<int>(inputArray);

Console.WriteLine(string.Join(' ', numbers));