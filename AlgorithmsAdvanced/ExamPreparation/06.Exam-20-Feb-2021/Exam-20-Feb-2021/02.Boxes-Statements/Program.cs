using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Boxes
{
	public class Box
	{
		public int Width { get; set; }

		public int Depth { get; set; }

		public int Height { get; set; }

		public override string ToString()
		{
			return $"{this.Width} {this.Depth} {this.Height}";
		}
	}

	public class Program
	{
		public static void Main(string[] args)
		{
			int boxesCount = int.Parse(Console.ReadLine());

			List<Box> boxes = ReadInputBoxes(boxesCount);

			int[] lengths = new int[boxesCount];

			int[] previousOnes = new int[boxesCount];

			int indexOfLastAddedNumber = 0;

			FillArrays(boxes, lengths, previousOnes, ref indexOfLastAddedNumber);

			Stack<Box> selectedBoxes = GetSelectedBoxes(boxes, previousOnes, indexOfLastAddedNumber);

			Console.WriteLine(string.Join(Environment.NewLine, selectedBoxes));
		}

		private static Stack<Box> GetSelectedBoxes(List<Box> boxes, int[] previousOnes, int indexOfLastAddedNumber)
		{
			Stack<Box> selectedBoxes = new Stack<Box>();

			while (indexOfLastAddedNumber != -1)
			{
				selectedBoxes.Push(boxes[indexOfLastAddedNumber]);

				indexOfLastAddedNumber = previousOnes[indexOfLastAddedNumber];
			}

			return selectedBoxes;
		}

		private static void FillArrays(List<Box> boxes, int[] lengths, int[] previousOnes, ref int indexOfLastAddedNumber)
		{
			int bestLength = 0;

			for (int i = 0; i < boxes.Count; i++)
			{
				int currentLength = 1;

				int currentParent = -1;

				for (int j = 0; j < i; j++)
				{
					if (boxes[i].Width > boxes[j].Width
						&& boxes[i].Depth > boxes[j].Depth
						&& boxes[i].Height > boxes[j].Height
						&& lengths[j] + 1 > currentLength)
					{
						currentLength = lengths[j] + 1;

						currentParent = j;
					}
				}

				lengths[i] = currentLength;

				previousOnes[i] = currentParent;

				if (currentLength > bestLength)
				{
					bestLength = currentLength;

					indexOfLastAddedNumber = i;
				}
			}
		}

		private static List<Box> ReadInputBoxes(int boxesCount)
		{
			List<Box> boxes = new List<Box>();

			for (int i = 0; i < boxesCount; i++)
			{
				int[] boxData = Console.ReadLine()
					.Split(' ', StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse)
					.ToArray();

				boxes.Add(new Box()
				{
					Width = boxData[0],
					Depth = boxData[1],
					Height = boxData[2],
				});
			}

			return boxes;
		}
	}
}
