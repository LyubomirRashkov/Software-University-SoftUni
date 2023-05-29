namespace _02.DOM
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	using System.Xml.Linq;
	using _02.DOM.Interfaces;
	using _02.DOM.Models;

	public class DocumentObjectModel : IDocument
	{
		public DocumentObjectModel(IHtmlElement root)
		{
			this.Root = root;
		}

		public DocumentObjectModel()
		{
			this.Root = new HtmlElement(ElementType.Document,
							new HtmlElement(ElementType.Html,
								new HtmlElement(ElementType.Head),
								new HtmlElement(ElementType.Body)));
		}

		public IHtmlElement Root { get; private set; }

		public bool Contains(IHtmlElement htmlElement)
		{
			IHtmlElement element = this.FindElementWithBfs(htmlElement);

			return element != null;
		}

		public IHtmlElement GetElementByType(ElementType type)
		{
			Queue<IHtmlElement> queue = new Queue<IHtmlElement>();

			queue.Enqueue(this.Root);

			while (queue.Count > 0)
			{
				IHtmlElement current = queue.Dequeue();

				if (current.Type == type)
				{
					return current;
				}

				foreach (var child in current.Children)
				{
					queue.Enqueue(child);
				}
			}

			return null;
		}

		public List<IHtmlElement> GetElementsByType(ElementType type)
		{
			List<IHtmlElement> elements = new List<IHtmlElement>();

			this.GetElementByTypeWithDfs(type, this.Root, elements);

			return elements;
		}

		public void InsertFirst(IHtmlElement parent, IHtmlElement child)
		{
			IHtmlElement parentElement = this.FindElementWithBfs(parent) ?? throw new InvalidOperationException();

			parentElement.Children.Insert(0, child);

			child.Parent = parentElement;
		}

		public void InsertLast(IHtmlElement parent, IHtmlElement child)
		{
			IHtmlElement parentElement = this.FindElementWithBfs(parent) ?? throw new InvalidOperationException();

			parentElement.Children.Add(child);

			child.Parent = parentElement;
		}

		public void Remove(IHtmlElement htmlElement)
		{
			IHtmlElement element = this.FindElementWithBfs(htmlElement) ?? throw new InvalidOperationException();

			IHtmlElement parent = element.Parent ?? throw new InvalidOperationException();

			parent.Children.Remove(element);
		}

		public void RemoveAll(ElementType elementType)
		{
			Queue<IHtmlElement> queue = new Queue<IHtmlElement>();

			queue.Enqueue(this.Root);

			while (queue.Count > 0)
			{
				IHtmlElement current = queue.Dequeue();

				if (current.Type == elementType)
				{
					IHtmlElement parent = current.Parent ?? throw new InvalidOperationException();

					parent.Children.Remove(current);
				}
				else
				{
					foreach (var child in current.Children)
					{
						queue.Enqueue(child);
					}
				}
			}
		}

		public bool AddAttribute(string attrKey, string attrValue, IHtmlElement htmlElement)
		{
			IHtmlElement element = this.FindElementWithBfs(htmlElement) ?? throw new InvalidOperationException();

			if (element.Attributes.ContainsKey(attrKey))
			{
				return false;
			}

			element.Attributes.Add(attrKey, attrValue);

			return true;
		}

		public bool RemoveAttribute(string attrKey, IHtmlElement htmlElement)
		{
			IHtmlElement element = this.FindElementWithBfs(htmlElement) ?? throw new InvalidOperationException();

			return element.Attributes.Remove(attrKey);
		}

		public IHtmlElement GetElementById(string idValue)
		{
			Queue<IHtmlElement> queue = new Queue<IHtmlElement>();

			queue.Enqueue(this.Root);

			while (queue.Count > 0)
			{
				IHtmlElement current = queue.Dequeue();

				if (current.Attributes.ContainsKey("id") && current.Attributes["id"] == idValue)
				{
					return current;
				}

				foreach (var child in current.Children)
				{
					queue.Enqueue(child);
				}
			}

			return null;
		}

		public override string ToString()
		{
			int indentation = 0;

			StringBuilder sb = new StringBuilder();

			this.ToStringWithDfs(this.Root, indentation, sb);

			return sb.ToString();
		}

		private IHtmlElement FindElementWithBfs(IHtmlElement htmlElement)
		{
			Queue<IHtmlElement> queue = new Queue<IHtmlElement>();

			queue.Enqueue(this.Root);

			while (queue.Count > 0)
			{
				IHtmlElement current = queue.Dequeue();

				if (current == htmlElement)
				{
					return current;
				}

				foreach (var child in current.Children)
				{
					queue.Enqueue(child);
				}
			}

			return null;
		}

		private void GetElementByTypeWithDfs(ElementType type, IHtmlElement node, List<IHtmlElement> result)
		{
			if (node is null)
			{
				return;
			}

			foreach (var child in node.Children)
			{
				this.GetElementByTypeWithDfs(type, child, result);
			}

			if (node.Type == type)
			{
				result.Add(node);
			}
		}

		private void ToStringWithDfs(IHtmlElement node, int indentation, StringBuilder sb)
		{
			if (node is null)
			{
				return;
			}

			sb.Append(' ', indentation).AppendLine(node.Type.ToString());

			foreach (var child in node.Children)
			{
				this.ToStringWithDfs(child, indentation + 2, sb);
			}
		}
	}
}
