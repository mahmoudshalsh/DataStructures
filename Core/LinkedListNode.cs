using System;

namespace Core
{
    public class LinkedListNode<T>
    {
        /// <summary>
        /// The node value
        /// </summary>
        public T Value { get; private set; }

        /// <summary>
        /// The next node in the linked list (null if last node)
        /// </summary>
        public LinkedListNode<T> Next { get; set; }

        public LinkedListNode(T Value) => this.Value = Value;
        public LinkedListNode(T Value, LinkedListNode<T> Next) : this(Value) => this.Next = Next;

        public override bool Equals(object obj) => (obj as LinkedListNode<T>).Value.Equals(this.Value);
        public override int GetHashCode() => Value.GetHashCode() ^ Next.GetHashCode();
    }
}