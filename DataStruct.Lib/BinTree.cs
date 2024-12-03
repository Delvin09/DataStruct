
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace DataStruct.Lib
{
    public partial class BinTree
    {
        private Node? _root;

        public int Count { get; private set; }

        public void Add(int item)
        {
            if (_root == null)
            {
                _root = CreateNode(item);
            }
            else
            {
                Add(_root, item);
            }
        }

        private void Add(Node current, int item)
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

        private Node CreateNode(int item, Node? left = null, Node? right = null)
        {
            Count++;
            return new Node(item)
            {
                Left = left,
                Right = right,
            };
        }

        public bool Contains(int item)
        {
            return _root != null && Contains(_root, item);
        }

        private bool Contains(Node current, IComparable item)
        {
            return item.CompareTo(current.Value) switch
            {
                < 0 => current.Left != null && Contains(current.Left, item),
                > 0 => current.Right != null && Contains(current.Right, item),
                _ => true
            };
        }

        //public int[] ToArray()
        //{
        //    if (_root == null) return Array.Empty<IComparable>();

        //    var array = new IComparable[Count];
        //    ToArray(array, 0, _root);
        //    return array;
        //}

        //private int ToArray(IComparable[] array, int arrayIndex, Node current)
        //{
        //    if (current.Left != null)
        //    {
        //        arrayIndex = ToArray(array, arrayIndex, current.Left);
        //    }

        //    array[arrayIndex++] = current.Value;

        //    if (current.Right != null)
        //    {
        //        arrayIndex = ToArray(array, arrayIndex, current.Right);
        //    }

        //    return arrayIndex;
        //}
    }
}
