using AVLTree;

namespace Demo
{
    class Program
    {
        static void Main()
        {
            var tree = new AVL<int>();


			//// Testvame dqsnata rotaciq:
			//tree.Insert(50);
			//tree.Insert(30);
			//tree.Insert(10);

			//// Testvame lqvata rotaciq:
			//tree.Insert(10);
			//tree.Insert(30);
			//tree.Insert(50);

			//// Testvame dvojna lqva rotaciq:
			//tree.Insert(10);
			//tree.Insert(50);
			//tree.Insert(30);

			//// Testvame dvojna dqsna rotaciq:
			//tree.Insert(50);
			//tree.Insert(10);
			//tree.Insert(30);

			//// Testvame iztrivaneto na element:
			//tree.Delete(30);

			tree.Insert(41);
			tree.Insert(20);
			tree.Insert(65);
			tree.Insert(11);
			tree.Insert(50);
			tree.Insert(29);
			tree.Insert(91);
			tree.Insert(32);
			tree.Insert(72);
			tree.Insert(99);

			tree.Delete(50); // Testvame lqva rotaciq
			tree.Delete(99); // Testvame dvojna dqsna rotaciq
			tree.Delete(65);
			tree.Delete(72); // Testvame dvojna dqsna rotaciq
		}
    }
}
