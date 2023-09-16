using _01.Two_Three;
using System;

namespace Demo
{
	public class Program
	{
		public static void Main()
		{
			//var tree = new TwoThreeTree<string>();

			//tree.Insert("A");
			//tree.Insert("E");
			//tree.Insert("D");
			//tree.Insert("B");
			//tree.Insert("F");
			//tree.Insert("G");
			//tree.Insert("C");

			//var tree = new TwoThreeTree<string>();

			//tree.Insert("C");
			//tree.Insert("E");
			//tree.Insert("D");
			//tree.Insert("B");
			//tree.Insert("F");
			//tree.Insert("G");
			//tree.Insert("A");


			TwoThreeTree<IntDemo> biggerTree = new TwoThreeTree<IntDemo>();

			biggerTree.Insert(new IntDemo(50));
			biggerTree.Insert(new IntDemo(100));
			biggerTree.Insert(new IntDemo(57));
			biggerTree.Insert(new IntDemo(75));
			biggerTree.Insert(new IntDemo(23));
			biggerTree.Insert(new IntDemo(150));
			biggerTree.Insert(new IntDemo(130));
			biggerTree.Insert(new IntDemo(19));
			biggerTree.Insert(new IntDemo(90));
			biggerTree.Insert(new IntDemo(2));
			biggerTree.Insert(new IntDemo(8));
			biggerTree.Insert(new IntDemo(68));
			biggerTree.Insert(new IntDemo(34));
			biggerTree.Insert(new IntDemo(49));
			biggerTree.Insert(new IntDemo(88));
			biggerTree.Insert(new IntDemo(99));
			biggerTree.Insert(new IntDemo(55));
			biggerTree.Insert(new IntDemo(17));

			//var intTree = new TwoThreeTree<int>(); // Tova dyrvo shte se napylni navsqkyde s nuli, t.k. default-nata stojnost na int e nula i navsqkyde kydeto prisvoqvame stojnost default shte se schupi logikata ni

			//intTree.Insert(5);
			//intTree.Insert(10);
			//intTree.Insert(15);
		}

		private class IntDemo : IComparable<IntDemo>
		{
			public IntDemo(int value)
			{
				this.Value = value;
			}

			public int Value { get; set; }

			public int CompareTo(IntDemo other)
			{
				return this.Value.CompareTo(other.Value);
			}

			public override string ToString()
			{
				return this.Value.ToString();
			}
		}

	}

}
