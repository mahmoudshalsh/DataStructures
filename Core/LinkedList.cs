using System;
using System.Collections;
using System.Collections.Generic;

namespace Core
{
    public class LinkedList<T> : ICollection<T>
    {
        public LinkedListNode<T> Head { get; private set; } = null;
        public LinkedListNode<T> Tail { get; private set; } = null;
        public int Count { get; private set; } = 0;
        public bool IsReadOnly { get; private set; } = false;

        #region Add

        public void AddNodeInFirst(LinkedListNode<T> item)
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
        public void AddNodeInFirst(T item) => AddNodeInFirst(new LinkedListNode<T>(item));

        public void AddNodeInLast(LinkedListNode<T> item)
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
        public void AddNodeInLast(T item) => AddNodeInLast(new LinkedListNode<T>(item));

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
                        iterator = iterator.Next;
                    Tail = iterator;
                    iterator.Next = null;
                }
                Count--;
            }
        }

        #endregion

        #region ICollection

        public IEnumerator<T> GetEnumerator()
        {
            var iterator = Head;
            while (iterator != null)
            {
                yield return iterator.Value;
                iterator = iterator.Next;
            }
        }

        public void Add(T item) => AddNodeInLast(item);

        public void Clear()
        {
            Head = Tail = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            var interval = Head;
            while (interval != null)
            {
                if (item.Equals(interval.Value))
                    return true;
                interval = interval.Next;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            var interval = Head;
            int listIndex = 0;
            int arrIndex = 0;
            while (interval != null && arrIndex < array.Length && listIndex < Count)
            {
                if (arrayIndex == listIndex)
                {
                    while (interval != null)
                    {
                        array[arrIndex] = interval.Value;
                        interval = interval.Next;
                        arrIndex++;
                        listIndex++;
                    }
                }
                interval = interval != null ? interval.Next : null;
                listIndex++;
            }
        }

        public bool Remove(T item)
        {
            var result = false;
            if (Contains(item))
            {
                var interval = Head;
                while (interval != null)
                {
                    if (interval.Next != null && item.Equals(interval.Next.Value))
                    {
                        interval.Next = interval.Next.Next;
                        result = true;
                        Count--;
                    }
                    interval = interval.Next;
                }
            }
            return result;
        }

        #endregion

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        bool IsEmpty() => (Head == null || Tail == null);
    }
}