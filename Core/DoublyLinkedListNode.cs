using System;

namespace Core
{
    public class DoublyLinkedListNode<T>
    {
        /// <summary>
        /// The node value
        /// </summary>
        public T Value { get; private set; }

        /// <summary>
        /// The next node in the linked list (null if last node)
        /// </summary>
        public DoublyLinkedListNode<T> Next { get; set; } = null;

        /// <summary>
        /// The next node in the linked list (null if first node)
        /// </summary>
        public DoublyLinkedListNode<T> Previous { get; set; } = null;

        public DoublyLinkedListNode(T Value) => this.Value = Value;
        public DoublyLinkedListNode(T Value, DoublyLinkedListNode<T> Next) : this(Value) => this.Next = Next;
        public DoublyLinkedListNode(T Value, DoublyLinkedListNode<T> Next, DoublyLinkedListNode<T> Previous) : this(Value, Next) => this.Previous = Previous;

        public override bool Equals(object obj) => (obj as DoublyLinkedListNode<T>).Value.Equals(this.Value);
        public override int GetHashCode() => Value.GetHashCode() ^ Next.GetHashCode() ^ Previous.GetHashCode();
    }
}