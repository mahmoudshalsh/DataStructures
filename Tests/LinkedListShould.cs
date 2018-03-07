using Core;
using System;
using Xunit;

namespace Tests
{
    public class LinkedListShould
    {
        LinkedList<int> linkedList;
        LinkedListNode<int> tailExpected, middleExpected, headExpected;

        public LinkedListShould()
        {
            linkedList = new LinkedList<int>();
            tailExpected = new LinkedListNode<int>(5);
            middleExpected = new LinkedListNode<int>(4, tailExpected);
            headExpected = new LinkedListNode<int>(3, middleExpected);
        }

        [Fact]
        public void AddFirst_CheckHead_CheckTail_CheckCount()
        {
            // Act
            linkedList.AddNodeInFirst(new LinkedListNode<int>(5));
            linkedList.AddNodeInFirst(new LinkedListNode<int>(4));
            linkedList.AddNodeInFirst(new LinkedListNode<int>(3));

            // Assert
            Assert.Equal(tailExpected, linkedList.Tail);
            Assert.Equal(headExpected, linkedList.Head);
            Assert.Equal(middleExpected, linkedList.Head.Next);
            Assert.Equal(3, linkedList.Count);
        }

        [Fact]
        public void AddLast_CheckHead_CheckTail_CheckCount()
        {
            // Act
            linkedList.AddNodeInLast(new LinkedListNode<int>(3));
            linkedList.AddNodeInLast(new LinkedListNode<int>(4));
            linkedList.AddNodeInLast(new LinkedListNode<int>(5));

            // Assert
            Assert.Equal(tailExpected, linkedList.Tail);
            Assert.Equal(headExpected, linkedList.Head);
            Assert.Equal(middleExpected, linkedList.Head.Next);
            Assert.Equal(3, linkedList.Count);
        }

        [Fact]
        public void RemoveFirst_CheckHead_CheckTail_CheckCount()
        {
            // Arrange
            linkedList.AddNodeInFirst(new LinkedListNode<int>(5));
            linkedList.AddNodeInFirst(new LinkedListNode<int>(4));
            linkedList.AddNodeInFirst(new LinkedListNode<int>(3));

            // Act & Assert
            linkedList.RemoveFirstNode();
            Assert.Equal(middleExpected, linkedList.Head);
            Assert.Equal(tailExpected, linkedList.Tail);
            Assert.Equal(2, linkedList.Count);

            linkedList.RemoveFirstNode();
            Assert.Equal(tailExpected, linkedList.Head);
            Assert.Equal(tailExpected, linkedList.Tail);
            Assert.Equal(1, linkedList.Count);

            linkedList.RemoveFirstNode();
            Assert.Equal(null, linkedList.Head);
            Assert.Equal(null, linkedList.Tail);
            Assert.Equal(0, linkedList.Count);
        }

        [Fact]
        public void RemoveLast_CheckHead_CheckTail_CheckCount()
        {
            // Arrange
            linkedList.AddNodeInFirst(new LinkedListNode<int>(5));
            linkedList.AddNodeInFirst(new LinkedListNode<int>(4));
            linkedList.AddNodeInFirst(new LinkedListNode<int>(3));

            // Act & Assert
            linkedList.RemoveLastNode();
            Assert.Equal(headExpected, linkedList.Head);
            Assert.Equal(middleExpected, linkedList.Tail);
            Assert.Equal(2, linkedList.Count);

            linkedList.RemoveLastNode();
            Assert.Equal(headExpected, linkedList.Head);
            Assert.Equal(headExpected, linkedList.Tail);
            Assert.Equal(1, linkedList.Count);

            linkedList.RemoveLastNode();
            Assert.Equal(null, linkedList.Head);
            Assert.Equal(null, linkedList.Tail);
            Assert.Equal(0, linkedList.Count);
        }

        [Fact]
        public void ReturnEnumerator_CheckHead_CheckTail_CheckCount()
        {
            // Arrange
            linkedList.AddNodeInFirst(new LinkedListNode<int>(5));
            linkedList.AddNodeInFirst(new LinkedListNode<int>(4));
            linkedList.AddNodeInFirst(new LinkedListNode<int>(3));
            linkedList.AddNodeInFirst(new LinkedListNode<int>(2));
            linkedList.AddNodeInFirst(new LinkedListNode<int>(1));

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

        [Fact]
        public void Add_CheckHead_CheckTail_CheckCount()
        {
            // Act
            linkedList.Add(3);
            linkedList.Add(4);
            linkedList.Add(5);

            // Assert
            Assert.Equal(tailExpected, linkedList.Tail);
            Assert.Equal(headExpected, linkedList.Head);
            Assert.Equal(middleExpected, linkedList.Head.Next);
            Assert.Equal(3, linkedList.Count);
        }

        [Fact]
        public void Clear_CheckHead_CheckTail_CheckCount()
        {
            // Arrange
            linkedList.Add(3);
            linkedList.Add(4);
            linkedList.Add(5);

            // Act
            linkedList.Clear();

            // Assert
            Assert.Equal(null, linkedList.Tail);
            Assert.Equal(null, linkedList.Head);
            Assert.Equal(0, linkedList.Count);
        }

        [Fact]
        public void Contains_CheckHead_CheckTail_CheckCount()
        {
            // Arrange
            linkedList.Add(3);
            linkedList.Add(4);
            linkedList.Add(5);

            // Act
            var actual1 = linkedList.Contains(4);
            var actual2 = linkedList.Contains(1);

            // Assert
            Assert.Equal(true, actual1);
            Assert.Equal(false, actual2);
        }

        [Fact]
        public void CopyTo_CheckHead_CheckTail_CheckCount()
        {
            // Arrange
            linkedList.Add(3);
            linkedList.Add(4);
            linkedList.Add(5);
            int[] actual = new int[2];
            int[] expected = new int[2] { 4, 5 };

            // Act
            linkedList.CopyTo(actual, 1);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Remove_CheckHead_CheckTail_CheckCount()
        {
            // Arrange
            linkedList.Add(3);
            linkedList.Add(4);
            linkedList.Add(5);

            // Act
            linkedList.Remove(4);

            // Assert
            Assert.Equal(headExpected, linkedList.Head);
            Assert.Equal(tailExpected, linkedList.Head.Next);
            Assert.Equal(tailExpected, linkedList.Tail);
            Assert.Equal(2, linkedList.Count);
        }
    }
}