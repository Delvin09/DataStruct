namespace DataStruct.Lib
{
    public partial class BinTree
    {
        private class Node
        {
            public Node? Left { get; set; }
            public Node? Right { get; set; }

            public int Value { get; init; }

            public Node(int value)
            {
                Value = value;
            }
        }
    }
}
