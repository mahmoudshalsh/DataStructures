using System;
using System.Collections;
using System.Collections.Generic;

namespace Core
{
    public class DoublyLinkedList<T> : ICollection<T>
    {
        public DoublyLinkedListNode<T> Head { get; private set; } = null;
        public DoublyLinkedListNode<T> Tail { get; private set; } = null;
        public int Count { get; private set; } = 0;
        public bool IsReadOnly { get; private set; } = false;



        #region Add

        public void AddNodeInFirst(DoublyLinkedListNode<T> item)
        {
            if (IsEmpty())
                Head = Tail = item;
            else
            {
                item.Next = Head;
                Head.Previous = item;
                Head = item;
            }

            Count++;
        }
        public void AddNodeInFirst(T item) => AddNodeInFirst(new DoublyLinkedListNode<T>(item));

        public void AddNodeInLast(DoublyLinkedListNode<T> item)
        {
            if (IsEmpty())
                Head = Tail = item;
            else
            {
                Tail.Next = item;
                item.Previous = Tail;
                Tail = item;
            }

            Count++;
        }
        public void AddNodeInLast(T item) => AddNodeInLast(new DoublyLinkedListNode<T>(item));

        #endregion

        #region Remove

        public void RemoveFirstNode()
        {
            if (!IsEmpty())
            {
                if (Head.Equals(Tail))
                    Head = Tail = null;
                else
                {
                    Head = Head.Next;
                    Head.Previous = null;
                }
                Count--;
            }
        }
        public void RemoveLastNode()
        {
            if (!IsEmpty())
            {
                if (Head.Equals(Tail))
                    Head = Tail = null;
                else
                {
                    Tail = Tail.Previous;
                    Tail.Next = null;
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
                    if (interval.Value.Equals(item))
                    {
                        interval.Previous.Next = interval.Next;
                        interval.Next.Previous = interval.Previous;
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