using System;

namespace ConsoleTest
{
    class Node<T>
    {
        public T Value { get; private set; }
        public Node<T> Next { get; set; }

        public Node(T Value) => this.Value = Value;
        public Node(T Value, Node<T> Next) : this(Value) => this.Next = Next;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Node<int> last = new Node<int>(6);
            Node<int> middle = new Node<int>(4, last);
            Node<int> first = new Node<int>(2, middle);

            var iterator = first;
            while (iterator != null)
            {
                Console.WriteLine(iterator.Value.ToString());
                iterator = iterator.Next;
            }
        }
    }
}
