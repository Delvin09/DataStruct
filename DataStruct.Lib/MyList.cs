namespace DataStruct.Lib
{
    public class MyList
    {
        private object[] _items = new object[10];

        public int Count { get; private set; }

        public object this[int i]
        {
            get
            {
                return _items[i];
            }
            set
            {
                _items[i] = value;
            }
        }

        public void Add(object item)
        {
            if (_items.Length >= Count)
            {
                // Increase()
            }

            _items[Count] = item;
            Count++;
        }

        public bool Contains(object item) { }

        public int IndexOf(object item) { }

        public void Insert(int index, object item) { }

        public void RemoveAt(int index) { }

        public void Remove(object item) { }

        public object[] ToArray() { }

        private void Increase()
        {
        }
    }
}
