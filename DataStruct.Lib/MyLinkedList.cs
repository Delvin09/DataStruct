using DataStruct.Abstractions;
using System.Collections;

namespace DataStruct.Lib
{
    public class MyDoubleLinkedList<T> : MyLinkedList<T>
    {
        protected class DoubleLinkedListNode : LinkedListNode
        {
            public LinkedListNode? Prev { get; set; }

            public DoubleLinkedListNode(T? data, LinkedListNode? next, LinkedListNode? prev)
                : base(data, next)
            {
                Prev = prev;
            }
        }

        protected override LinkedListNode CreateNode(T? data, LinkedListNode? next = null, LinkedListNode? prev = null)
        {
            return new DoubleLinkedListNode(data, next, prev);
        }

        protected override void ChangeNodeLinks(LinkedListNode node, NodeToChange next = default, NodeToChange prev = default)
        {
            base.ChangeNodeLinks(node, next, prev);

            var current = (DoubleLinkedListNode)node;
            if (!prev.DoNotChange) current.Prev = prev.Node;

            if (next.Node != null) ((DoubleLinkedListNode)next.Node).Prev = node;
        }
    }

    public class MyLinkedList<T> : IMyCollection<T>, IEnumerable<T>
    {
        protected readonly struct NodeToChange
        {
            public readonly bool DoNotChange = true;
            public readonly LinkedListNode? Node = null;

            public NodeToChange(LinkedListNode? node)
            {
                Node = node;
                DoNotChange = false;
            }
        }

        protected class LinkedListNode
        {
            public T? Data { get; }

            public LinkedListNode? Next { get; set; }

            public LinkedListNode(T? data, LinkedListNode? next)
            {
                Data = data;
                Next = next;
            }
        }

        protected LinkedListNode? FirstNode { get; private set; }

        protected LinkedListNode? LastNode { get; private set; }

        public T? First => FirstNode == null ? default : FirstNode.Data;

        public T? Last => LastNode == null ? default : LastNode.Data;

        public int Count { get; private set; }

        protected virtual LinkedListNode CreateNode(T? data, LinkedListNode? next = null, LinkedListNode? prev = null)
        {
            return new LinkedListNode(data, next);
        }

        protected virtual void ChangeNodeLinks(LinkedListNode node, NodeToChange next = default, NodeToChange prev = default)
        {
            if (!next.DoNotChange)
                node.Next = next.Node;

            if (prev.Node != null)
            {
                prev.Node.Next = node;
            }
        }

        public void Insert(T? data, int index)
        {
            if (index < 0 || index >= Count) throw new IndexOutOfRangeException();

            if (index == 0)
            {
                AddFirst(data);
            }
            else
            {
                LinkedListNode? current = FirstNode;
                LinkedListNode? previos = null;
                for (int i = 0; i < index && current != null; i++, current = current.Next)
                {
                    previos = current;
                }

                if (previos != null)
                {
                    var newNode = CreateNode(data, current, previos);
                    previos.Next = newNode;

                    Count++;
                }
            }
        }

        public void AddFirst(T? data)
        {
            if (FirstNode == null)
            {
                FirstNode = LastNode = CreateNode(data, null, null);
            }
            else
            {
                var newNode = CreateNode(data, FirstNode, null);
                ChangeNodeLinks(FirstNode, prev: new NodeToChange(newNode));

                FirstNode = newNode;
            }

            Count++;
        }

        public void Add(T? data)
        {
            if (FirstNode == null)
            {
                FirstNode = LastNode = CreateNode(data, null, null);
            }
            else
            {
                var newNode = CreateNode(data, null, LastNode);
                if (LastNode != null) ChangeNodeLinks(LastNode, next: new NodeToChange(newNode));

                LastNode = newNode;
            }

            Count++;
        }

        public void Remove(T? data)
        {
            if (Count <= 0) return;

            LinkedListNode? current = FirstNode;
            LinkedListNode? previos = null;
            for (; current != null; current = current.Next)
            {
                if ((data == null && current.Data == null) || (current.Data != null && current.Data.Equals(data)))
                {
                    break;
                }

                previos = current;
            }

            if (current != null)
            {
                if (previos != null)
                    ChangeNodeLinks(previos, new NodeToChange(current.Next));

                if (current.Next != null)
                    ChangeNodeLinks(current.Next, prev: new NodeToChange(previos));

                if (current == FirstNode)
                {
                    FirstNode = current.Next;
                }

                if (current == LastNode)
                {
                    LastNode = previos;
                }
            }

            Count--;
        }

        public void Clear()
        {
            FirstNode = LastNode = null;
            Count = 0;
        }

        public T?[] ToArray()
        {
            var result = new T?[Count];
            var node = FirstNode;
            for (int i = 0; node != null && i < Count; i++)
            {
                result[i] = node.Data;
                node = node.Next;
            }

            return result;
        }

        public bool Contains(T? data)
        {
            LinkedListNode? current = FirstNode;
            LinkedListNode? previos = null;
            for (; current != null; current = current.Next)
            {
                if ((data == null && current.Data == null) || (current.Data != null && current.Data.Equals(data)))
                {
                    return true;
                }

                previos = current;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new LinkedListIterator(FirstNode);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class LinkedListIterator : IEnumerator<T>
        {
            private readonly LinkedListNode? _firstNode;
            private LinkedListNode _node;

            public LinkedListIterator(LinkedListNode node)
            {
                _firstNode = _node = node;
            }

            public T Current => _node.Data;

            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                var next = _node?.Next;
                _node = next;
                return next != null;
            }

            public void Reset()
            {
                _node = _firstNode;
            }

            public void Dispose()
            {
            }
        }
    }
}
