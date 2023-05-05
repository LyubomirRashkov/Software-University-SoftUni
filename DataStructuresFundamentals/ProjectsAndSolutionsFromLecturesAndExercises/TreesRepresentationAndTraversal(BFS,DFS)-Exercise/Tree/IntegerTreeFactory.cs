namespace Tree
{
	using System.Collections.Generic;
	using System.Linq;

	public class IntegerTreeFactory
    {
        private readonly Dictionary<int, IntegerTree> nodesByKey;

        public IntegerTreeFactory()
        {
            this.nodesByKey = new Dictionary<int, IntegerTree>();
        }

        public IntegerTree CreateTreeFromStrings(string[] input)
        {
            foreach (var str in input)
            {
                int[] numbers = str
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                int parent = numbers[0];
                int child = numbers[1];

                this.AddEdge(parent, child);
            }

            return this.GetRoot();
        }

        public void AddEdge(int parent, int child)
        {
            IntegerTree parentNode = this.CreateNodeByKey(parent);
            IntegerTree childNode = this.CreateNodeByKey(child);

            parentNode.AddChild(childNode);
            childNode.AddParent(parentNode);
        }

        public IntegerTree CreateNodeByKey(int key)
        {
            if (!this.nodesByKey.ContainsKey(key))
            {
                this.nodesByKey.Add(key, new IntegerTree(key));
            }

            return this.nodesByKey[key];
        }

        public IntegerTree GetRoot()
        {
            foreach (var kvp in this.nodesByKey)
            {
                IntegerTree tree = kvp.Value;

                if (tree.Parent is null)
                {
                    return tree;
                }
            }

            return null;
        }
    }
}
