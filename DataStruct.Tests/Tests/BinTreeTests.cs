using DataStruct.Lib;
using MagicTests.Abstractions;
using MagicTests.Abstractions.Attributes;

namespace DataStruct.Tests.Tests
{
    [TestGroup]
    class BinTreeTests
    {
        [Test]
        public void Add_ShouldIncreaseCount()
        {
            var tree = new BinTree<int>();
            tree.Add(10);
            tree.Add(5);
            tree.Add(15);

            Assert.AreEqual(3, tree.Count);
        }

        [Test]
        public void Add_ShouldMaintainBinarySearchTreeProperty()
        {
            var tree = new BinTree<int>();
            tree.Add(10);
            tree.Add(5);
            tree.Add(15);
            tree.Add(3);
            tree.Add(7);

            var array = tree.ToArray();
            Assert.AreEqual(new[] { 3, 5, 7, 10, 15 }, array);
        }

        [Test]
        public void Contains_ShouldReturnTrueIfItemExists()
        {
            var tree = new BinTree<int>();
            tree.Add(10);
            tree.Add(5);
            tree.Add(15);

            Assert.True(tree.Contains(10));
            Assert.True(tree.Contains(5));
            Assert.True(tree.Contains(15));
            Assert.False(tree.Contains(7));
        }

        [Test]
        public void Contains_ShouldReturnFalseForEmptyTree()
        {
            var tree = new BinTree<int>();
            Assert.False(tree.Contains(10));
        }

        [Test]
        public void ToArray_ShouldReturnSortedArray()
        {
            var tree = new BinTree<int>();
            tree.Add(10);
            tree.Add(5);
            tree.Add(15);
            tree.Add(3);
            tree.Add(7);

            var array = tree.ToArray();
            Assert.AreEqual(new[] { 3, 5, 7, 10, 15 }, array);
        }

        [Test]
        public void ToArray_ShouldReturnEmptyArrayForEmptyTree()
        {
            var tree = new BinTree<int>();
            var array = tree.ToArray();
            Assert.Empty(array);
        }

        [Test]
        public void Clear_ShouldResetTree()
        {
            var tree = new BinTree<int>();
            tree.Add(10);
            tree.Add(5);
            tree.Add(15);

            tree.Clear();

            Assert.AreEqual(0, tree.Count);
            Assert.Empty(tree.ToArray());
            Assert.False(tree.Contains(10));
        }

        [Test]
        public void Add_ShouldThrowException_WhenAddingNull()
        {
            var tree = new BinTree<string>();
            Assert.Throws<ArgumentNullException>(() => tree.Add(null));
        }
    }
}
