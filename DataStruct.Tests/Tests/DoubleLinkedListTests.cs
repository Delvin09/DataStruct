using DataStruct.Lib;
using MagicTests.Abstractions;
using MagicTests.Abstractions.Attributes;

namespace DataStruct.Tests.Tests
{
    [TestGroup]
    class DoubleLinkedListTests
    {
        [Test]
        public void Add_ShouldAddElementToEnd()
        {
            var list = new MyDoubleLinkedList<int>();
            list.Add(1);
            list.Add(2);

            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(1, list.First);
            Assert.AreEqual(2, list.Last);
        }

        [Test]
        public void AddFirst_ShouldAddElementToStart()
        {
            var list = new MyDoubleLinkedList<int>();
            list.Add(2);
            list.AddFirst(1);

            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(1, list.First);
            Assert.AreEqual(2, list.Last);
        }

        [Test]
        public void Remove_ShouldRemoveElement()
        {
            var list = new MyDoubleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            list.Remove(2);

            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(1, list.First);
            Assert.AreEqual(3, list.Last);
        }

        [Test]
        public void Remove_ShouldHandleNonExistentElement()
        {
            var list = new MyDoubleLinkedList<int>();
            list.Add(1);
            list.Add(2);

            list.Remove(3);

            Assert.AreEqual(2, list.Count);
        }

        [Test]
        public void Insert_ShouldAddElementAtIndex()
        {
            var list = new MyDoubleLinkedList<int>();
            list.Add(1);
            list.Add(3);

            list.Insert(2, 1);

            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(1, list.First);
            Assert.AreEqual(3, list.Last);
            Assert.AreEqual(2, list.ToArray()[1]);
        }

        [Test]
        public void Insert_ShouldThrowException_WhenIndexOutOfBounds()
        {
            var list = new MyDoubleLinkedList<int>();
            list.Add(1);

            Assert.Throws<IndexOutOfRangeException>(() => list.Insert(2, 2));
        }

        [Test]
        public void Clear_ShouldRemoveAllElements()
        {
            var list = new MyDoubleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            list.Clear();

            Assert.AreEqual(0, list.Count);
            Assert.Null(list.First);
            Assert.Null(list.Last);
        }

        [Test]
        public void Contains_ShouldReturnTrueIfElementExists()
        {
            var list = new MyDoubleLinkedList<int>();
            list.Add(1);
            list.Add(2);

            Assert.True(list.Contains(2));
            Assert.False(list.Contains(3));
        }

        [Test]
        public void Enumerator_ShouldIterateOverElements()
        {
            var list = new MyDoubleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            int sum = 0;
            foreach (var item in list)
            {
                sum += item;
            }

            Assert.AreEqual(6, sum);
        }

        [Test]
        public void ToArray_ShouldReturnAllElements()
        {
            var list = new MyDoubleLinkedList<int>();
            list.Add(1);
            list.Add(2);

            var array = list.ToArray();

            Assert.AreSequenceEqual([1, 2], array);
        }
    }
}
