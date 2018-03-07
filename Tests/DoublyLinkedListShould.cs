using Core;
using System;
using Xunit;

namespace Tests
{
    public class DoublyLinkedListShould
    {
        DoublyLinkedList<int> linkedList;
        DoublyLinkedListNode<int> tailExpected, middleExpected, headExpected;

        public DoublyLinkedListShould()
        {
            linkedList = new DoublyLinkedList<int>();
            tailExpected = new DoublyLinkedListNode<int>(5, null, middleExpected);
            middleExpected = new DoublyLinkedListNode<int>(4, tailExpected, headExpected);
            headExpected = new DoublyLinkedListNode<int>(3, middleExpected);
        }

        [Fact]
        public void AddFirst_CheckHead_CheckTail_CheckCount()
        {
            // Act
            linkedList.AddNodeInFirst(5);
            linkedList.AddNodeInFirst(4);
            linkedList.AddNodeInFirst(3);

            // Assert
            Assert.Equal(tailExpected, linkedList.Tail);
            Assert.Equal(headExpected, linkedList.Head);
            Assert.Equal(middleExpected, linkedList.Head.Next);
            Assert.Equal(middleExpected, linkedList.Tail.Previous);
            Assert.Equal(3, linkedList.Count);
        }

        [Fact]
        public void AddLast_CheckHead_CheckTail_CheckCount()
        {
            // Act
            linkedList.AddNodeInLast(3);
            linkedList.AddNodeInLast(4);
            linkedList.AddNodeInLast(5);

            // Assert
            Assert.Equal(tailExpected, linkedList.Tail);
            Assert.Equal(headExpected, linkedList.Head);
            Assert.Equal(middleExpected, linkedList.Head.Next);
            Assert.Equal(middleExpected, linkedList.Tail.Previous);
            Assert.Equal(3, linkedList.Count);
        }

        [Fact]
        public void RemoveFirst_CheckHead_CheckTail_CheckCount()
        {
            // Arrange
            linkedList.AddNodeInFirst(5);
            linkedList.AddNodeInFirst(4);
            linkedList.AddNodeInFirst(3);

            // Act & Assert
            linkedList.RemoveFirstNode();
            Assert.Equal(middleExpected, linkedList.Head);
            Assert.Equal(null, linkedList.Head.Previous);
            Assert.Equal(tailExpected, linkedList.Tail);
            Assert.Equal(2, linkedList.Count);

            linkedList.RemoveFirstNode();
            Assert.Equal(tailExpected, linkedList.Head);
            Assert.Equal(null, linkedList.Head.Previous);
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
            linkedList.AddNodeInFirst(5);
            linkedList.AddNodeInFirst(4);
            linkedList.AddNodeInFirst(3);

            // Act & Assert
            linkedList.RemoveLastNode();
            Assert.Equal(headExpected, linkedList.Head);
            Assert.Equal(middleExpected, linkedList.Tail);
            Assert.Equal(null, linkedList.Tail.Next);
            Assert.Equal(2, linkedList.Count);

            linkedList.RemoveLastNode();
            Assert.Equal(headExpected, linkedList.Head);
            Assert.Equal(headExpected, linkedList.Tail);
            Assert.Equal(null, linkedList.Tail.Next);
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
            linkedList.AddNodeInFirst(5);
            linkedList.AddNodeInFirst(4);
            linkedList.AddNodeInFirst(3);
            linkedList.AddNodeInFirst(2);
            linkedList.AddNodeInFirst(1);

            // Act
            System.Collections.Generic.IEnumerable<int> actual = linkedList;

            // Analysis
            foreach (int x in actual)
                Console.WriteLine(x);

            // Assert
            Assert.Equal(System.Linq.Enumerable.Range(1, 5), actual);
            Assert.Equal(new DoublyLinkedListNode<int>(1), linkedList.Head);
            Assert.Equal(new DoublyLinkedListNode<int>(5), linkedList.Tail);
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
            Assert.Equal(middleExpected, linkedList.Tail.Previous);
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
        public void Contains()
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
        public void CopyTo()
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
            Assert.Equal(headExpected, linkedList.Tail.Previous);
            Assert.Equal(tailExpected, linkedList.Head.Next);
            Assert.Equal(tailExpected, linkedList.Tail);
            Assert.Equal(2, linkedList.Count);
        }
    }
}