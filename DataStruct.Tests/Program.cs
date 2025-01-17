using DataStruct.Lib;
using DataStruct.Tests;
using MagicTests.Abstractions;
using MagicTests.Abstractions.Attributes;
using System.Diagnostics;
using System.Reflection;

namespace DataStruct.Tests
{
    interface ITestRenderer
    {
        void ShowTestGroupTitle(string title);
    }

    //class ConsoleTestRenderer : ITestRenderer
    //{
    //    public void Handle(object? sender, OnTestEndEventArgs args)
    //    {
    //        ShowTestResult(args.TestName, args.IsSuccess);
    //    }

    //    private void ShowTestResult(string testName, bool isSuccess)
    //    {
    //        Console.Write($"{testName}:\t\t");

    //        Console.BackgroundColor = isSuccess ? ConsoleColor.Green : ConsoleColor.Red;
    //        Console.ForegroundColor = ConsoleColor.Black;
    //        var result = isSuccess ? "SUCCESS" : "FAILD";
    //        Console.WriteLine(result);

    //        Console.ResetColor();
    //    }

    //    public void ShowTestGroupTitle(string title)
    //    {
    //        Console.BackgroundColor = ConsoleColor.Magenta;
    //        Console.ForegroundColor = ConsoleColor.Cyan;
    //        Console.WriteLine($"-{title}");

    //        Console.ResetColor();
    //    }
    //}

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
            Assert.AreEqual(2, list[0]);
        }

        [Test("Remove elements form list test.")]
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
    }

    [TestGroup]
    class LinkedListTests
    {
        [Test]
        public bool AddElementsToLinkedListTest()
        {
            // Arrange
            var list = new MyLinkedList<int>();

            // Act
            list.Add(1);

            // Assert
            return list.Count == 1 && list.First == 1;
        }

        [Test]
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
    }


    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
