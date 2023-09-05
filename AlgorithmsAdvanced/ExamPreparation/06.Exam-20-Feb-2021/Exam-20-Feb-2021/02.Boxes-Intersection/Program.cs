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

			int[] boxesWidths = boxes.Select(b => b.Width).ToArray();

			Stack<Box> LISOfBoxesWidths = GetSelectedBoxes(boxes, boxesWidths);

			int[] boxesDepths = boxes.Select(b => b.Depth).ToArray();

			Stack<Box> LISOfBoxesDepths = GetSelectedBoxes(boxes, boxesDepths);

			int[] boxesHeights = boxes.Select(b => b.Height).ToArray();

			Stack<Box> LISOfBoxesHeights = GetSelectedBoxes(boxes, boxesHeights);

			List<Box> selectedBoxes = LISOfBoxesWidths.Intersect(LISOfBoxesDepths.Intersect(LISOfBoxesHeights)).ToList();

			Console.WriteLine(string.Join(Environment.NewLine, selectedBoxes));
		}

		private static Stack<Box> GetSelectedBoxes(List<Box> boxes, int[] boxesProperties)
		{
			int[] lengths = new int[boxes.Count];

			int[] previousOnes = new int[boxes.Count];

			int indexOfLastAddedBox = 0;

			FillArrays(boxes, boxesProperties, lengths, previousOnes, ref indexOfLastAddedBox);

			Stack<Box> chosenBoxes = GetChosenBoxes(boxes, previousOnes, indexOfLastAddedBox);

			return chosenBoxes;
		}

		private static Stack<Box> GetChosenBoxes(List<Box> boxes, int[] previousOnes, int indexOfLastAddedBox)
		{
			Stack<Box> chosenBoxes = new Stack<Box>();

			while (indexOfLastAddedBox != -1)
			{
				chosenBoxes.Push(boxes[indexOfLastAddedBox]);

				indexOfLastAddedBox = previousOnes[indexOfLastAddedBox];
			}

			return chosenBoxes;
		}

		private static void FillArrays(
			List<Box> boxes,
			int[] boxesProperties,
			int[] lengths,
			int[] previousOnes,
			ref int indexOfLastAddedBox)
		{
			int bestLength = 0;

			for (int i = 0; i < boxes.Count; i++)
			{
				int currentLength = 1;

				int currentParrent = -1;

				for (int j = 0; j < i; j++)
				{
					if (boxesProperties[i] > boxesProperties[j] && lengths[j] + 1 > currentLength)
					{
						currentLength = lengths[j] + 1;

						currentParrent = j;
					}
				}

				lengths[i] = currentLength;

				previousOnes[i] = currentParrent;

				if (currentLength > bestLength)
				{
					bestLength = currentLength;

					indexOfLastAddedBox = i;
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
