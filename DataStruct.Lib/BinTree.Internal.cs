namespace DataStruct.Lib
{
    public partial class BinTree<T>
    {
        private class Node
        {
            public Node? Left { get; set; }
            public Node? Right { get; set; }

            public T Value { get; init; }

            public Node(T value)
            {
                Value = value;
            }
        }
    }
}
