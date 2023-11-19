namespace HashTable
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
	using System.Linq;

	public class HashTable<TKey, TValue> : IEnumerable<KeyValue<TKey, TValue>>
    {
        private const int DefaultCapacity = 16;
        private const float LoadFactor = 0.75f;

        private LinkedList<KeyValue<TKey, TValue>>[] slots;

        public int Count { get; private set; }

        public int Capacity => this.slots.Length;

        public HashTable()
            : this (DefaultCapacity)
        {
        }

        public HashTable(int capacity)
        {
            this.slots = new LinkedList<KeyValue<TKey, TValue>>[capacity];
        }

        public void Add(TKey key, TValue value)
        {
            this.GrowIfNeeded();

            int index = this.GetTargetIndex(key);

            if (this.slots[index] is null)
            {
                this.slots[index] = new LinkedList<KeyValue<TKey, TValue>>();
            }

            foreach (var kvp in this.slots[index])
            {
                if (kvp.Key.Equals(key))
                {
                    throw new ArgumentException();
                }
            }

            KeyValue<TKey, TValue> newKVP = new KeyValue<TKey, TValue>(key, value);

            this.slots[index].AddLast(newKVP);

            this.Count++;
        }

		public bool AddOrReplace(TKey key, TValue value)
        {
            try
            {
                this.Add(key, value);
            }
            catch (ArgumentException)
            {
                int index = this.GetTargetIndex(key);

                KeyValue<TKey, TValue> kvp = this.slots[index].First(kv => kv.Key.Equals(key));

                kvp.Value = value;

                return true;
            }

            return false;
        }

        public TValue Get(TKey key)
        {
            KeyValue<TKey, TValue> kvp = this.Find(key);

			return kvp != null ? kvp.Value : throw new KeyNotFoundException();
		}

		public TValue this[TKey key]
        {
            get
            {
                return this.Get(key);
            }
            set
            {
                this.AddOrReplace(key, value);
            }
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
			KeyValue<TKey, TValue> kvp = this.Find(key);

            if(kvp != null)
            {
                value = kvp.Value;

                return true;
            }

            value = default;

            return false;
        }

        public KeyValue<TKey, TValue> Find(TKey key)
        {
            int index = this.GetTargetIndex(key);

            if (this.slots[index] != null)
            {
                foreach (var kvp in this.slots[index])
                {
                    if (kvp.Key.Equals(key))
                    {
                        return kvp;
                    }
                }
            }

            return null;
        }

        public bool ContainsKey(TKey key)
        {
            return this.Find(key) != null;
        }

        public bool Remove(TKey key)
        {
            int index = this.GetTargetIndex(key);

            if (this.slots[index] != null)
            {
				LinkedListNode<KeyValue<TKey, TValue>> linkedListNode = this.slots[index].First;

                while (linkedListNode != null)
                {
                    if (linkedListNode.Value.Key.Equals(key))
                    {
                        this.slots[index].Remove(linkedListNode);

                        this.Count--;

                        return true;
                    }

                    linkedListNode = linkedListNode.Next;
                }
            }

            return false;
        }

        public void Clear()
        {
            this.slots = new LinkedList<KeyValue<TKey, TValue>>[DefaultCapacity];

            this.Count = 0;
        }

        public IEnumerable<TKey> Keys => this.Select(kvp => kvp.Key);

        public IEnumerable<TValue> Values => this.Select(kvp => kvp.Value);

        public IEnumerator<KeyValue<TKey, TValue>> GetEnumerator()
        {
            foreach (var slot in this.slots)
            {
                if (slot != null)
                {
                    foreach (var kvp in slot)
                    {
                        yield return kvp;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

		private int GetTargetIndex(TKey key) => Math.Abs(key.GetHashCode()) % this.Capacity;

		private void GrowIfNeeded()
		{
            if ((float)((this.Count + 1) / this.Capacity) >= LoadFactor)
            {
                HashTable<TKey, TValue> newTable = new HashTable<TKey, TValue>(this.Capacity * 2);

                foreach (var KVP in this)
                {
                    newTable.Add(KVP.Key, KVP.Value);
                }

                this.slots = newTable.slots;

                this.Count = newTable.Count;
            }
		}
    }
}
