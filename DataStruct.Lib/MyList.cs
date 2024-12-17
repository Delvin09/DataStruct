using DataStruct.Abstractions;

namespace DataStruct.Lib
{
    //public class ObservableMyList<T> : IMyList<T>
    //{
    //    private readonly MyList<T> myList;

    //    public ObservableMyList(MyList<T> myList)
    //    {
    //        this.myList = myList;
    //    }

    //    public T? this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    //    public int Count => throw new NotImplementedException();

    //    public void Add(T? id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Clear()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public bool Contains(T? item)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public int IndexOf(T? item)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void RemoveAt(int index)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public T?[] ToArray() => myList.ToArray();


    //    public event EventHandler<ListEventArgs> ListChanged;
    //    public event EventHandler<ListEventArgs> RemoveistChanged;
    //    public event EventHandler<ListEventArgs> ClearistChanged;
    //}

    //public class ListEventArgs : EventArgs
    //{
    //    public
    //}

    public interface IIterator<out T>
    {
        T Current { get; }

        bool MoveNext();
    }

    public interface IIterable<out T>
    {
        IIterator<T> GetIterator();
    }

    public class MyList<T> : IMyList<T>, IIterable<T>
    {
        private T?[] _items = new T[6];

        public int Count { get; private set; }

        public T? this[int index]
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

        public void Add(T? item)
        {
            Increase();

            _items[Count] = item;
            Count++;
        }

        public void Insert(int index, T? item)
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

        public bool Contains(T? item)
        {
            return IndexOf(item) >= 0;
        }

        public int IndexOf(T? item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (item == null && _items[i] == null) return i;
                else if (item!.Equals(_items[i])) return i;
            }
            return -1;
        }

        public void Remove(T? item)
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

        public T?[] ToArray()
        {
            var newArray = new T?[Count];

            return newArray;
        }

        private void Increase()
        {
            if (Count >= _items.Length)
            {
                Array.Resize(ref _items, Count * 2);
            }
        }

        public void Clear()
        {
            for (int i = 0; i < Count; i++) _items[i] = default;
            Count = 0;
        }

        public IIterator<T> GetIterator()
        {
            return new MyListIterator(this);
        }

        private class MyListIterator : IIterator<T>
        {
            private readonly MyList<T> _list;
            private int _index = -1;

            public T Current => _list[_index];

            public MyListIterator(MyList<T> list)
            {
                this._list = list;
            }

            public bool MoveNext()
            {
                _index++;
                return _index < _list.Count;
            }
        }

    }
}
