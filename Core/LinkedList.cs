using System;
using System.Collections;
using System.Collections.Generic;

namespace Core
{
    public class LinkedList<T> : IEnumerable<T>
    {
        public LinkedListNode<T> Head { get; private set; } = null;
        public LinkedListNode<T> Tail { get; private set; } = null;
        public int Count { get; private set; } = 0;

        #region Add
        public void AddElementInFirst(LinkedListNode<T> item)
        {
            if (IsEmpty())
                Head = Tail = item;
            else
            {
                item.Next = Head;
                Head = item;
            }

            Count++;
        }
        public void AddFirst(T item) => AddElementInFirst(new LinkedListNode<T>(item));

        public void AddElementInLast(LinkedListNode<T> item)
        {
            if (IsEmpty())
                Head = Tail = item;
            else
            {
                Tail.Next = item;
                Tail = item;
            }

            Count++;
        }
        public void AddLast(T item) => AddElementInLast(new LinkedListNode<T>(item));
        #endregion

        #region Remove
        public void RemoveFirstNode()
        {
            if (!IsEmpty())
            {
                if (Head.Equals(Tail))
                    Head = Tail = null;
                else
                    Head = Head.Next;
                Count--;
            }
        }

        public void RemoveLastNode()
        {
            if (IsEmpty())
                return;
            else
            {
                if (Head.Equals(Tail))
                    Head = Tail = null;
                else
                {
                    var iterator = Head;
                    while (iterator.Next != Tail)
                    {
                        iterator = iterator.Next;
                    }
                    Tail = iterator;
                    iterator.Next = null;
                }
                Count--;
            }
        }
        #endregion

        public IEnumerator<T> GetEnumerator()
        {
            var iterator = Head;
            while (iterator != null)
            {
                yield return iterator.Value;
                iterator = iterator.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        bool IsEmpty() => (Head == null || Tail == null);
    }
}