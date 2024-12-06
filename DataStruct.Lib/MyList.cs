using DataStruct.Abstractions;

namespace DataStruct.Lib
{
    public class MyList<TItem> : IMyList<TItem>
    {
        private TItem?[] _items = new TItem[6];

        public int Count { get; private set; }

        public TItem? this[int index]
        {
            get
            {
                if (index >= 0 && index >= Count) throw new IndexOutOfRangeException();
                return _items[index];
            }
            set
            {
                if (index >= 0 && index >= Count) throw new IndexOutOfRangeException();
                _items[index] = value;
            }
        }

        public void Add(TItem? item)
        {
            Increase();

            _items[Count] = item;
            Count++;
        }

        public void Insert(int index, TItem? item)
        {
            if (index >= Count || index < 0) throw new IndexOutOfRangeException();

            Increase();

            for (int i = Count - 1; i >= index; i--)
            {
                _items[i + 1] = _items[i];
            }

            _items[index] = item;

            Count++;
        }

        public bool Contains(TItem item)
        {
            return IndexOf(item) >= 0;
        }

        public int IndexOf(TItem? item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (item == null && _items[i] == null) return i;
                else if (item!.Equals(_items[i])) return i;
            }
            return -1;
        }

        public void Remove(TItem? item)
        {
            var index = IndexOf(item);
            if (index >= 0) RemoveAt(index);
        }

        public void RemoveAt(int index)
        {
            if (index >= Count || index < 0) throw new IndexOutOfRangeException();

            for (int i = index; i < Count; i++)
            {
                _items[i] = _items[i + 1];
            }

            _items[Count] = default;
            Count--;
        }

        public TItem?[] ToArray()
        {
            var newArray = new TItem?[Count];

            return newArray;
        }

        private void Increase()
        {
            if (_items.Length >= Count)
            {
                Array.Resize(ref _items, Count * 2);
            }
        }

        public void Clear()
        {
            for (int i = 0; i < Count; i++) _items[i] = default;
            Count = 0;
        }
    }
}
