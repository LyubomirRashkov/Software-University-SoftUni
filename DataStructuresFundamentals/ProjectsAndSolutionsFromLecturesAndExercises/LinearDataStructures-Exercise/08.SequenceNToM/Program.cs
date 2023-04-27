using _08.SequenceNToM;

int[] numbers = Console.ReadLine()
	.Split(' ', StringSplitOptions.RemoveEmptyEntries)
	.Select(int.Parse)
	.ToArray();

int n = numbers[0];
int m = numbers[1];

if (n > m)
{
	Console.WriteLine("No possible solution!");
}
else if (n == m)
{
	Console.WriteLine("Two numbers are equal!");
}
else
{
	Stack<int> targetNumbers = new Stack<int>();

	Queue<Item> queue = new Queue<Item>();

	Item item = new Item(n);

	queue.Enqueue(item);

	while (true)
	{
		Item? currentItem = queue.Dequeue();

		if (currentItem.Value == m)
		{
			while (currentItem != null)
			{
				targetNumbers.Push(currentItem.Value);

				currentItem = currentItem.Previous;
			}

			break;
		}

		Item itemOne = new Item((currentItem.Value + 1), currentItem);
		Item itemTwo = new Item((currentItem.Value + 2), currentItem);

		queue.Enqueue(itemOne);
		queue.Enqueue(itemTwo);

		if ((currentItem.Value * 2) <= m)
		{
			Item itemThree = new Item((currentItem.Value * 2), currentItem);

			queue.Enqueue(itemThree);
		}
	}

	Console.WriteLine(string.Join(" -> ", targetNumbers));
}
