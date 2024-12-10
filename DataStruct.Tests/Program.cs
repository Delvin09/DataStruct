using DataStruct.Lib;

namespace DataStruct.Tests
{
    public class TestInfo
    {
        public string Name { get; init; }

        public Func<bool> Method { get; init; }
    }

    abstract class TestGroup
    {
        public abstract string Title { get; }

        protected void ShowTestResult(string testName, bool isSuccess)
        {
            Console.Write($"{testName}:\t\t");

            Console.BackgroundColor = isSuccess ? ConsoleColor.Green : ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            var result = isSuccess ? "SUCCESS" : "FAILD";
            Console.WriteLine(result);

            Console.ResetColor();
        }

        public void Start()
        {
            ShowTestGroupTitle();

            foreach (var test in GetTestList())
            {
                var isSuccess = test.Method();
                ShowTestResult(test.Name, isSuccess);
            }

        }

        protected abstract void RunTests();

        protected abstract TestInfo[] GetTestList();

        protected void ShowTestGroupTitle()
        {
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"-{Title}");

            Console.ResetColor();
        }
    }

    class ListTests : TestGroup
    {
        public override string Title => nameof(ListTests);

        public bool AddElementsToListTest()
        {
            // Arrange
            var list = new MyList<int>();

            // Act
            list.Add(1);

            // Assert
            return list.Count == 1 && list[0] == 1;
        }

        public bool RemoveElementsTest()
        {
            // Arrange
            var list = new MyList<int>();
            list.Add(1);

            // Act
            list.Remove(1);

            // Assert
            return list.Count == 0;
        }

        protected override TestInfo[] GetTestList()
        {
            return new TestInfo[]
            {
                new TestInfo { Name = nameof(AddElementsToListTest), Method = AddElementsToListTest },
                new TestInfo { Name = nameof(RemoveElementsTest), Method = RemoveElementsTest }
            };
        }

        protected override void RunTests()
        {
            AddElementsToListTest();
            RemoveElementsTest();
        }
    }

    class LinkedListTests : TestGroup
    {
        public override string Title => nameof(LinkedListTests);

        public bool AddElementsToLinkedListTest()
        {
            // Arrange
            var list = new MyLinkedList<int>();

            // Act
            list.Add(1);

            // Assert
            return list.Count == 1 && list.First == 1;
        }

        public bool RemoveElementsTest()
        {
            // Arrange
            var list = new MyLinkedList<int>();
            list.Add(1);

            // Act
            list.Remove(1);

            // Assert
            return list.Count == 0 && list.First == list.Last && list.Last == default;
        }

        protected override TestInfo[] GetTestList()
        {
            return new TestInfo[]
            {
                new TestInfo { Name = nameof(AddElementsToLinkedListTest), Method = AddElementsToLinkedListTest },
                new TestInfo { Name = nameof(RemoveElementsTest), Method = RemoveElementsTest }
            };
        }

        protected override void RunTests()
        {
            AddElementsToLinkedListTest();
            RemoveElementsTest();
        }
    }

    //class BinTreeTests : TestGroup
    //{
    //    public override string Title => nameof(BinTreeTests);

    //    protected override void RunTests()
    //    {
    //        AddElementsToTreeTest();
    //        ToArrayTest();
    //    }

    //    public void AddElementsToTreeTest()
    //    {

    //    }

    //    public void ToArrayTest()
    //    {

    //    }
    //}

    internal class Program
    {
        static void Main(string[] args)
        {
            TestGroup[] testGroups = new TestGroup[]
            {
                new ListTests(),
                new LinkedListTests(),
                //new BinTreeTests(),
            };

            Action someSimple = null;
            foreach (var testGroup in testGroups)
            {
                testGroup.Start();
            }
        }

        static void Tests()
        {
            Console.WriteLine("List");
            var list = new MyList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Insert(1, 0);
            int countKosharr = list.Count;
            list.RemoveAt(4);
            list.Remove(3);
            var toArr = list.ToArray();

            Console.WriteLine("LinkedList");

            var linkedList = new MyLinkedList<int>();
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);
            linkedList.Add(4);
            linkedList.Insert(1, 0);
            linkedList.Add(2);
            linkedList.AddFirst(2);
            bool conkoshLinkedList = linkedList.Contains(3);
            int count = linkedList.Count;
            object koshLinkedListfirst = linkedList.First;
            object koshLinkedListlast = linkedList.Last;
            var toArrLinkedList = linkedList.ToArray();
            linkedList.Clear();

            Console.WriteLine("DoublylinkeList");

            var doubleLinkedList = new MyDoubleLinkedList<int>();
            doubleLinkedList.Add(1);
            doubleLinkedList.Add(2);
            doubleLinkedList.Add(3);
            doubleLinkedList.Add(4);
            doubleLinkedList.Add(5);
            doubleLinkedList.Insert(1, 0);
            doubleLinkedList.Add(2);
            doubleLinkedList.AddFirst(2);
            bool contkoshDoublyLinkedList = doubleLinkedList.Contains(3);
            object koshDoublyLinkedListfirsy = doubleLinkedList.First;
            object koshDoublyLinkedListLast = doubleLinkedList.Last;
            var toArrkoshDoublyLinkedList = doubleLinkedList.ToArray();
            doubleLinkedList.Clear();

            Console.WriteLine("BinaryTreeNodeKosh");

            var binaryTree = new BinTree<int>();
            binaryTree.Add(1);
            binaryTree.Add(4);
            binaryTree.Add(5);
            binaryTree.Add(6);
            binaryTree.Add(2);
            bool contBinaryTreeNodeKosh = binaryTree.Contains(4);
            var toArrkoshBinaryTreeNodeKosh = binaryTree.ToArray();
            int root = binaryTree.Count;
            binaryTree.Clear();
            Console.WriteLine("");
        }
    }
}
