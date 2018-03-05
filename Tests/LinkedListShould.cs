using Core;
using System;
using Xunit;

namespace Tests
{
    public class LinkedListFeature
    {
        [Fact]
        public void AddFirst_CheckHead_CheckTail_CheckCount()
        {
            // Arrange
            LinkedList<int> linkedList = new LinkedList<int>();
            LinkedListNode<int> tailExpected = new LinkedListNode<int>(5);
            LinkedListNode<int> middleExpected = new LinkedListNode<int>(4, tailExpected);
            LinkedListNode<int> headExpected = new LinkedListNode<int>(3, middleExpected);

            // Act
            linkedList.AddElementInFirst(new LinkedListNode<int>(5));
            linkedList.AddElementInFirst(new LinkedListNode<int>(4));
            linkedList.AddElementInFirst(new LinkedListNode<int>(3));

            // Assert
            Assert.Equal(tailExpected, linkedList.Tail);
            Assert.Equal(headExpected, linkedList.Head);
            Assert.Equal(middleExpected, linkedList.Head.Next);
            Assert.Equal(3, linkedList.Count);
        }

        [Fact]
        public void AddLast_CheckHead_CheckTail_CheckCount()
        {
            // Arrange
            LinkedList<int> linkedList = new LinkedList<int>();
            LinkedListNode<int> tailExpected = new LinkedListNode<int>(5);
            LinkedListNode<int> middleExpected = new LinkedListNode<int>(4, tailExpected);
            LinkedListNode<int> headExpected = new LinkedListNode<int>(3, middleExpected);

            // Act
            linkedList.AddElementInLast(new LinkedListNode<int>(3));
            linkedList.AddElementInLast(new LinkedListNode<int>(4));
            linkedList.AddElementInLast(new LinkedListNode<int>(5));

            // Assert
            Assert.Equal(tailExpected, linkedList.Tail);
            Assert.Equal(headExpected, linkedList.Head);
            Assert.Equal(middleExpected, linkedList.Head.Next);
            Assert.Equal(3, linkedList.Count);
        }

        [Fact]
        public void ReturnEnumerator_CheckHead_CheckTail_CheckCount()
        {
            // Arrange
            LinkedList<int> linkedList = new LinkedList<int>();
            linkedList.AddElementInFirst(new LinkedListNode<int>(5));
            linkedList.AddElementInFirst(new LinkedListNode<int>(4));
            linkedList.AddElementInFirst(new LinkedListNode<int>(3));
            linkedList.AddElementInFirst(new LinkedListNode<int>(2));
            linkedList.AddElementInFirst(new LinkedListNode<int>(1));

            // Act
            System.Collections.Generic.IEnumerable<int> actual = linkedList;

            // Analysis
            foreach (int x in actual)
                Console.WriteLine(x);

            // Assert
            Assert.Equal(System.Linq.Enumerable.Range(1, 5), actual);
            Assert.Equal(new LinkedListNode<int>(1), linkedList.Head);
            Assert.Equal(new LinkedListNode<int>(5), linkedList.Tail);
            Assert.Equal(5, linkedList.Count);
        }
    }
}