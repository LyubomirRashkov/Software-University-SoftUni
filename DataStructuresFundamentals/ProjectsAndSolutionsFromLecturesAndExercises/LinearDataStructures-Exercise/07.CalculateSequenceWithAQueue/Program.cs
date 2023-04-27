const int ITERATIONS_COUNT = 50;

int number = int.Parse(Console.ReadLine());

Queue<int> queue = new Queue<int>();
queue.Enqueue(number);

List<int> output = new List<int>();

for (int i = 0; i < ITERATIONS_COUNT; i++)
{
	int num = queue.Dequeue();

	queue.Enqueue(num + 1);
	queue.Enqueue(2 * num + 1);
	queue.Enqueue(num + 2);

	output.Add(num);
}

Console.WriteLine(string.Join(", ", output));