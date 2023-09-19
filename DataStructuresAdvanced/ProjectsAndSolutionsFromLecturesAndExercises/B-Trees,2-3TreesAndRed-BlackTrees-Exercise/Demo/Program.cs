using _01.RedBlackTree;

namespace Demo
{
    class Program
    {
        static void Main()
        {
            var rbt = new RedBlackTree<int>();

			rbt.Insert(12);
			rbt.Insert(6);
			rbt.Insert(7);
			rbt.Insert(3);
			rbt.Insert(1);
			rbt.Insert(9);
			rbt.Insert(16);
			rbt.Insert(15);

			//rbt.DeleteMin();

			//rbt.DeleteMax();

			rbt.Delete(12);
			rbt.Delete(7);
			rbt.Delete(3);
		}
    }
}
