namespace DataStruct.Lib
{
    //public class MyLinkedList
    //{
    //    public class LinkedListNode
    //    {
    //        public object? Data { get; }

    //        public LinkedListNode? Next { get; set; }

    //        public LinkedListNode(object? data, LinkedListNode? next)
    //        {
    //            Data = data;
    //            Next = next;
    //        }
    //    }

    //    public LinkedListNode First { get; set; }

    //    public int Count { get; set; }

    //    public void Insert(object? data, int index)
    //    {
    //        if (index < 0 || index >= Count) throw new IndexOutOfRangeException();

    //        if (index == 0)
    //        {
    //            AddFirst(data);
    //        }
    //        else
    //        {
    //            LinkedListNode? current = First;
    //            LinkedListNode? previos = null;
    //            for (int i = 0; i < index && current != null; i++, current = current.Next)
    //            {
    //                previos = current;
    //            }

    //            if (previos != null)
    //            {
    //                var newNode = new Node(data, current, previos);
    //                previos.Next = newNode;

    //                Count++;
    //            }
    //        }
    //    }

    //    private void AddFirst(object? data)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
