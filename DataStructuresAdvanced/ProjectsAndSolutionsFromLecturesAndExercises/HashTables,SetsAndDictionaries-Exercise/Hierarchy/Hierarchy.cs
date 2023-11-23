namespace Hierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Collections;
	using System.Linq;

	public class Hierarchy<T> : IHierarchy<T>
    {
        private class Node
        {
            public Node(T value)
            {
                this.Value = value;

                this.Children = new List<Node>();
            }

            public T Value { get; private set; }

            public Node Parent { get; set; }

            public List<Node> Children { get; set; }
        }

        private readonly Node root;

        private readonly Dictionary<T, Node> nodesByValue;

        public Hierarchy(T value)
        {
            this.root = new Node(value);

            this.nodesByValue = new Dictionary<T, Node>()
            {
                { value, this.root },
            };
        }

        public int Count => this.nodesByValue.Count;

        public void Add(T element, T child)
        {
            this.ValidateElementExists(element);

            if (this.nodesByValue.ContainsKey(child))
            {
                throw new ArgumentException();
            }

            Node parentNode = this.nodesByValue[element];

            Node childNode = new Node(child);

            childNode.Parent = parentNode;

            parentNode.Children.Add(childNode);

            this.nodesByValue.Add(child, childNode);
        }

        public void Remove(T element)
        {
            this.ValidateElementExists(element);

            Node nodeToRemove = this.nodesByValue[element];

            Node parentNode = nodeToRemove.Parent;

            if (parentNode is null)
            {
                throw new InvalidOperationException();
            }

            parentNode.Children.Remove(nodeToRemove);

            parentNode.Children.AddRange(nodeToRemove.Children);

            foreach (var child in nodeToRemove.Children)
            {
                child.Parent = parentNode;
            }

            this.nodesByValue.Remove(element);
        }

		public bool Contains(T element) => this.nodesByValue.ContainsKey(element);

        public T GetParent(T element)
        {
            this.ValidateElementExists(element);

            Node parentNode = this.nodesByValue[element].Parent;

            if (parentNode is null)
            {
                return default;
            }

            return parentNode.Value;
        }

        public IEnumerable<T> GetChildren(T element)
        {
            this.ValidateElementExists(element);

            return this.nodesByValue[element].Children.Select(n => n.Value);
        }

        public IEnumerable<T> GetCommonElements(Hierarchy<T> other) 
            => this.nodesByValue.Keys.Intersect(other.nodesByValue.Keys);

        public IEnumerator<T> GetEnumerator()
        {
            Queue<Node> queue = new Queue<Node>();

            queue.Enqueue(this.root);

            while (queue.Count > 0)
            {
                Node currentNode = queue.Dequeue();

                foreach (var child in currentNode.Children)
                {
                    queue.Enqueue(child);
                }

                yield return currentNode.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

		private void ValidateElementExists(T element)
		{
			if (!this.nodesByValue.ContainsKey(element))
			{
				throw new ArgumentException();
			}
		}
    }
}