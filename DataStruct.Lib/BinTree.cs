using DataStruct.Abstractions;
using System;

namespace DataStruct.Lib
{
    public partial class BinTree<T> : IMyCollection<T>
        where T : IComparable<T>
    {
        private Node? _root;
        //private readonly IComparer<T> _comparer;

        public int Count { get; private set; }

        //public BinTree(IComparer<T> comparer)
        //{
        //    this._comparer = comparer;
        //}

        public void Add(T? item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            if (_root == null)
            {
                _root = CreateNode(item);
            }
            else
            {
                Add(_root, item);
            }
        }

        private void Add(Node current, T item)
        {
            if (item.CompareTo(current.Value) < 0)
            {
                if (current.Left == null)
                {
                    current.Left = CreateNode(item);
                }
                else
                {
                    Add(current.Left, item);
                }
            }
            else if (item.CompareTo(current.Value) > 0)
            {
                if (current.Right == null)
                {
                    current.Right = CreateNode(item);
                }
                else
                {
                    Add(current.Right, item);
                }
            }
        }

        private Node CreateNode(T item, Node? left = null, Node? right = null)
        {
            Count++;
            return new Node(item)
            {
                Left = left,
                Right = right,
            };
        }

        public bool Contains(T? item)
        {
            return _root != null && item != null && Contains(_root, item);
        }

        private bool Contains(Node current, T item)
        {
            return item.CompareTo(current.Value) switch
            {
                < 0 => current.Left != null && Contains(current.Left, item),
                > 0 => current.Right != null && Contains(current.Right, item),
                _ => true
            };
        }

        public T[] ToArray()
        {
            if (_root == null) return Array.Empty<T>();

            var array = new T[Count];
            ToArray(array, 0, _root);
            return array;
        }

        private int ToArray(T[] array, int arrayIndex, Node current)
        {
            if (current.Left != null)
            {
                arrayIndex = ToArray(array, arrayIndex, current.Left);
            }

            array[arrayIndex++] = current.Value;

            if (current.Right != null)
            {
                arrayIndex = ToArray(array, arrayIndex, current.Right);
            }

            return arrayIndex;
        }

        public void Clear()
        {
            _root = null;
            Count = 0;
        }
    }
}
