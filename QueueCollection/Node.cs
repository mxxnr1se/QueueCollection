namespace QueueCollection
{
    public class Node<T>
    {
        public Node(T data)
        {
            Value = data;
        }

        public T Value { get; set; }
        public Node<T> NextNode { get; set; }
    }
}