namespace _01._BrowserHistory
{
    using System;
    using System.Collections.Generic;
	using System.Text;
	using _01._BrowserHistory.Interfaces;

	public class BrowserHistory : IHistory
	{
		private Link first;

		private Link last;

		private int size;

		public int Size => this.size;

		public void Open(ILink link)
		{
			Link newLink = link as Link;

			if (this.first is null)
			{
				this.first = newLink;

				this.last = newLink;
			}
			else
			{
				newLink.Previous = this.last;

				this.last.Next = newLink;

				this.last = newLink;
			}

			this.size++;
		}

		public ILink GetByUrl(string url)
		{
			Link current = this.first;

			while (current != null)
			{
				if (current.Url == url)
				{
					return current;
				}

				current = current.Next;
			}

			return null;
		}

		public bool Contains(ILink link)
		{
			Link current = this.first;

			while (current != null)
			{
				if (current.Equals(link))
				{
					return true;
				}

				current = current.Next;
			}

			return false;
		}

		public ILink LastVisited()
		{
			this.ValidateCollection();

			return this.last;
		}

		public ILink DeleteLast()
		{
			this.ValidateCollection();

			Link link = this.last;

			if (this.Size == 1)
			{
				this.first = null;
				this.last = null;
			}
			else
			{
				this.last = this.last.Previous;

				this.last.Next = null;
			}

			this.size--;

			return link;
		}

		public ILink DeleteFirst()
		{
			this.ValidateCollection();

			Link link = this.first;

			if (this.Size == 1)
			{
				this.first = null;
				this.last = null;
			}
			else
			{
				this.first = this.first.Next;

				this.first.Previous = null;
			}

			this.size--;

			return link;
		}

		public int RemoveLinks(string url)
		{
			url = url.ToLower();

			int counter = 0;

			Link current = this.first;

			while (current != null)
			{
				if (current.Url.ToLower().Contains(url))
				{
					counter++;

					if (current.Equals(this.first))
					{
						this.DeleteFirst();
					}
					else if (current.Equals(this.last))
					{
						this.DeleteLast();
					}
					else
					{
						current.Previous.Next = current.Next;

						current.Next.Previous = current.Previous;

						this.size--;
					}
				}

				current = current.Next;
			}

			if (counter == 0)
			{
				throw new InvalidOperationException();
			}

			return counter;
		}

		public void Clear()
		{
			this.first = null;
			this.last = null;

			this.size = 0;
		}

		public ILink[] ToArray()
		{
			Link[] links = new Link[this.Size];

			Link current = this.last;

			int counter = 0;

			while (current != null)
			{
				links[counter] = current;

				counter++;

				current = current.Previous;
			}

			return links;
		}

		public List<ILink> ToList()
		{
			List<ILink> links = new List<ILink>(this.Size);

			Link current = this.last;

			while (current != null)
			{
				links.Add(current);

				current = current.Previous;
			}

			return links;
		}

		public string ViewHistory()
		{
			if (this.Size == 0)
			{
				return "Browser history is empty!";
			}

			StringBuilder sb = new StringBuilder();

			Link current = this.last;

			while (current != null)
			{
				sb.AppendLine(current.ToString());

				current = current.Previous;
			}

			return sb.ToString();
		}

		private void ValidateCollection()
		{
			if (this.Size == 0)
			{
				throw new InvalidOperationException();
			}
		}
	}
}
