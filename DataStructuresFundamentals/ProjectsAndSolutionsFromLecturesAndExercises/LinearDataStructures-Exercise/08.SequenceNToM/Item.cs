namespace _08.SequenceNToM
{
	public class Item
	{
        public int Value { get; set; }

        public Item? Previous { get; set; }

        public Item(int value, Item? previous = null)
        {
            this.Value = value;
            this.Previous = previous;
        }
    }
}
