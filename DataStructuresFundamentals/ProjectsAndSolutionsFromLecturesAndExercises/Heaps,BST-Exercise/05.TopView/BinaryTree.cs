namespace _05.TopView
{
    using System;
    using System.Collections.Generic;
	using System.Linq;

	public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(T value, BinaryTree<T> left, BinaryTree<T> right)
        {
            this.Value = value;
            this.LeftChild = left;
            this.RightChild = right;
        }

        public T Value { get; private set; }

        public BinaryTree<T> LeftChild { get; private set; }

        public BinaryTree<T> RightChild { get; private set; }

        public List<T> TopView()
        {
            var valuesWithLevelsByDistance = new Dictionary<int, (T value, int level)>();

            int horizontalDistance = 0;

            int level = 0;

            this.GetTopView(this, horizontalDistance, level, valuesWithLevelsByDistance);

            List<T> topViewValues = valuesWithLevelsByDistance
                .OrderBy(kvp => kvp.Key)
                .Select(kvp => kvp.Value)
                .Select(v => v.value)
                .ToList();

            return topViewValues;
        }

		private void GetTopView(
            BinaryTree<T> node, 
            int horizontalDistance, 
            int level, 
            Dictionary<int, (T value, int level)> valuesWithLevelsByDistance)
		{
            if (!valuesWithLevelsByDistance.ContainsKey(horizontalDistance))
            {
                valuesWithLevelsByDistance.Add(horizontalDistance, (node.Value, level));
            }

            if (node.LeftChild != null)
            {
                this.GetTopView(node.LeftChild, horizontalDistance - 1, level + 1, valuesWithLevelsByDistance);
            }

            if (node.RightChild != null)
            {
                this.GetTopView(node.RightChild, horizontalDistance + 1, level + 1, valuesWithLevelsByDistance);
            }
		}
	}
}
