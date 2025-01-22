using DataStruct.Lib;
using MagicTests.Abstractions;
using MagicTests.Abstractions.Attributes;

namespace DataStruct.Tests.Tests
{
    [TestGroup]
    class ListTests
    {
        [Test]
        public void AddElementsToListTest()
        {
            // Arrange
            var list = new MyList<int>();

            // Act
            list.Add(1);

            // Assert
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(1, list[0]);
        }

        [Test("Remove elements form list test.")]
        public void RemoveElementsTest()
        {
            // Arrange
            var list = new MyList<int>();
            list.Add(1);

            // Act
            list.Remove(1);

            // Assert
            Assert.AreEqual(0, list.Count);
        }

        [Test]
        public void Add_ShouldIncreaseCount()
        {
            var list = new MyList<int>();
            list.Add(1);
            list.Add(2);

            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(2, list[1]);
        }

        [Test]
        public void Indexer_ShouldThrowException_WhenIndexOutOfBounds()
        {
            var list = new MyList<int>();
            int a;

            Assert.Throws<IndexOutOfRangeException>(() => a = list[0]);

            list.Add(1);
            Assert.Throws<IndexOutOfRangeException>(() => a = list[1]);
        }

        [Test]
        public void Insert_ShouldAddElementAtSpecifiedIndex()
        {
            var list = new MyList<int>();
            list.Add(1);
            list.Add(3);

            list.Insert(1, 2);

            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(2, list[1]);
            Assert.AreEqual(3, list[2]);
        }

        [Test]
        public void Insert_ShouldThrowException_WhenIndexOutOfBounds()
        {
            var list = new MyList<int>();

            Assert.Throws<IndexOutOfRangeException>(() => list.Insert(0, 1));

            list.Add(1);
            Assert.Throws<IndexOutOfRangeException>(() => list.Insert(2, 2));
        }

        [Test]
        public void Remove_ShouldRemoveItemIfExists()
        {
            var list = new MyList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            list.Remove(2);

            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(3, list[1]);
        }

        [Test]
        public void RemoveAt_ShouldThrowException_WhenIndexOutOfBounds()
        {
            var list = new MyList<int>();
            list.Add(1);

            Assert.Throws<IndexOutOfRangeException>(() => list.RemoveAt(1));
        }

        [Test]
        public void RemoveAt_ShouldRemoveItemAtSpecifiedIndex()
        {
            var list = new MyList<int>();
            list.Add(1);
            list.Add(2);

            list.RemoveAt(0);

            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(2, list[0]);
        }

        [Test]
        public void Contains_ShouldReturnTrueIfItemExists()
        {
            var list = new MyList<int>();
            list.Add(1);
            list.Add(2);

            Assert.True(list.Contains(1));
            Assert.False(list.Contains(3));
        }

        [Test]
        public void ToArray_ShouldReturnArrayRepresentationOfList()
        {
            var list = new MyList<int>();
            list.Add(1);
            list.Add(2);

            var array = list.ToArray();

            Assert.AreSequenceEqual([1, 2], array);
        }

        [Test]
        public void Clear_ShouldEmptyTheList()
        {
            var list = new MyList<int>();
            list.Add(1);
            list.Add(2);

            list.Clear();

            int a;
            Assert.AreEqual(0, list.Count);
            Assert.Throws<IndexOutOfRangeException>(() => a = list[0]);
        }

        [Test]
        public void Enumerator_ShouldIterateOverList()
        {
            var list = new MyList<int>();
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
    }
}
