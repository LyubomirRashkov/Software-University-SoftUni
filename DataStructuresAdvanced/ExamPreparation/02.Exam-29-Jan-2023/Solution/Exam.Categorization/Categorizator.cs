using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.Categorization
{
	public class Categorizator : ICategorizator
	{
		private readonly Dictionary<string, Category> categoriesById;

		public Categorizator()
		{
			this.categoriesById = new Dictionary<string, Category>();
		}

		public void AddCategory(Category category)
		{
			if (this.categoriesById.ContainsKey(category.Id))
			{
				throw new ArgumentException();
			}

			this.categoriesById.Add(category.Id, category);
		}

		public void AssignParent(string childCategoryId, string parentCategoryId)
		{
			this.ValidateCategoryExists(childCategoryId);

			this.ValidateCategoryExists(parentCategoryId);

			Category child = this.categoriesById[childCategoryId];

			Category parent = this.categoriesById[parentCategoryId];

			if (parent.Children.Contains(child))
			{
				throw new ArgumentException();
			}

			child.Parent = parent;

			parent.Children.Add(child);

			parent.Depth = Math.Max(parent.Depth, child.Depth + 1);
		}

		public void RemoveCategory(string categoryId)
		{
			this.ValidateCategoryExists(categoryId);

			Category category = this.categoriesById[categoryId];

			Category parent = category.Parent;

			this.RemoveFromDictionary(categoryId);

			if (parent != null)
			{
				parent.Children.Remove(category);

				Category childWithMaxDepth = parent.Children.OrderByDescending(c => c.Depth).FirstOrDefault();

				parent.Depth = childWithMaxDepth != null ? childWithMaxDepth.Depth + 1 : 0;
			}
		}

		public bool Contains(Category category) => this.categoriesById.ContainsKey(category.Id);

		public int Size() => this.categoriesById.Count;

		public IEnumerable<Category> GetChildren(string categoryId)
		{
			this.ValidateCategoryExists(categoryId);

			List<Category> descendants = new List<Category>();

			Queue<Category> queue = new Queue<Category>();

			queue.Enqueue(this.categoriesById[categoryId]);

			while (queue.Count > 0)
			{
				Category current = queue.Dequeue();

				foreach (var child in current.Children)
				{
					queue.Enqueue(child);

					descendants.Add(child);
				}
			}

			return descendants;
		}

		public IEnumerable<Category> GetHierarchy(string categoryId)
		{
			this.ValidateCategoryExists(categoryId);

			Stack<Category> ancestors = new Stack<Category>();

			Category category = this.categoriesById[categoryId];

			while (category.Parent != null)
			{
				ancestors.Push(category);

				category = category.Parent;
			}

			ancestors.Push(category);

			return ancestors;
		}

		public IEnumerable<Category> GetTop3CategoriesOrderedByDepthOfChildrenThenByName()
			=> this.categoriesById.Values
			   .OrderByDescending(c => c.Depth)
			   .ThenBy(c => c.Name)
			   .Take(3);

		private void ValidateCategoryExists(string categoryId)
		{
			if (!this.categoriesById.ContainsKey(categoryId))
			{
				throw new ArgumentException();
			}
		}

		private void RemoveFromDictionary(string categoryId)
		{
			foreach (var child in this.categoriesById[categoryId].Children)
			{
				this.RemoveFromDictionary(child.Id);
			}

			this.categoriesById.Remove(categoryId);
		}
	}
}

/* 
	// Without using property Depth 

using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.Categorization
{
	public class Categorizator : ICategorizator
	{
		private readonly Dictionary<string, Category> categoriesById;

		public Categorizator()
		{
			this.categoriesById = new Dictionary<string, Category>();
		}

		public void AddCategory(Category category)
		{
			if (this.categoriesById.ContainsKey(category.Id))
			{
				throw new ArgumentException();
			}

			this.categoriesById.Add(category.Id, category);
		}

		public void AssignParent(string childCategoryId, string parentCategoryId)
		{
			this.ValidateCategoryExists(childCategoryId);

			this.ValidateCategoryExists(parentCategoryId);

			Category child = this.categoriesById[childCategoryId];

			Category parent = this.categoriesById[parentCategoryId];

			if (parent.Children.FirstOrDefault(c => c.Id == childCategoryId) != null)
			{
				throw new ArgumentException();
			}

			child.Parent = parent;

			parent.Children.Add(child);
		}

		public void RemoveCategory(string categoryId)
		{
			this.ValidateCategoryExists(categoryId);

			Category category = this.categoriesById[categoryId];

			Category parent = category.Parent;

			this.RemoveFromDictionary(category);

			if (parent != null)
			{
				parent.Children.Remove(category);
			}
		}

		public bool Contains(Category category) => this.categoriesById.ContainsKey(category.Id);

		public int Size() => this.categoriesById.Count;

		public IEnumerable<Category> GetChildren(string categoryId)
		{
			this.ValidateCategoryExists(categoryId);

			List<Category> descendants = new List<Category>();

			Queue<Category> queue = new Queue<Category>();

			queue.Enqueue(this.categoriesById[categoryId]);

			while (queue.Count > 0)
			{
				Category current = queue.Dequeue();

				foreach (var child in current.Children)
				{
					queue.Enqueue(child);

					descendants.Add(child);
				}
			}

			return descendants;
		}

		public IEnumerable<Category> GetHierarchy(string categoryId)
		{
			this.ValidateCategoryExists(categoryId);

			Stack<Category> ancestors = new Stack<Category>();

			Category category = this.categoriesById[categoryId];

			while (category.Parent != null)
			{
				ancestors.Push(category);

				category = category.Parent;
			}

			ancestors.Push(category);

			return ancestors;
		}

		public IEnumerable<Category> GetTop3CategoriesOrderedByDepthOfChildrenThenByName()
			=> this.categoriesById.Values
			   .OrderByDescending(c => CalculateDepth(c))
			   .ThenBy(c => c.Name)
			   .Take(3);

		private void ValidateCategoryExists(string categoryId)
		{
			if (!this.categoriesById.ContainsKey(categoryId))
			{
				throw new ArgumentException();
			}
		}

		private void RemoveFromDictionary(Category category)
		{
			foreach (var child in category.Children)
			{
				this.RemoveFromDictionary(child);
			}

			this.categoriesById.Remove(category.Id);
		}

		private int CalculateDepth(Category category)
		{
			int currentDepth = 1;

			int maxDepth = 1;

			this.Dfs(category, currentDepth, ref maxDepth);

			return maxDepth;
		}

		private void Dfs(Category category, int currentDepth, ref int maxDepth)
		{
			currentDepth++;

			if (currentDepth > maxDepth)
			{
				maxDepth = currentDepth;
			}

			foreach (var child in category.Children)
			{
				this.Dfs(child, currentDepth, ref maxDepth);
			}
		}
	}
}
*/
