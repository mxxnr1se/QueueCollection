using System;
using System.Collections;
using System.Collections.Generic;

namespace QueueCollection
{
    public class Queue<T> : IEnumerable<T>, ICloneable
    {
        private Node<T> _head;
        private Node<T> _tail;

        public Queue()
        {
        }

        private Queue(Node<T> head, Node<T> tail, int count)
        {
            _head = head;
            _tail = tail;
            Count = count;
        }

        private int Count { get; set; }

        public T Peek
        {
            get
            {
                if (IsEmpty)
                    throw new QueueException("An exception occurred: Queue is empty");
                return _head.Value;
            }
        }

        public T Last
        {
            get
            {
                if (IsEmpty)
                    throw new QueueException("An exception occurred: Queue is empty");
                return _tail.Value;
            }
        }

        public bool IsEmpty => Count == 0;

        private T this[int index]
        {
            get
            {
                var temp = _head;
                for (int i = 0; i < index; i++)
                    temp = temp.NextNode;

                return temp.Value;
            }
        }

        public object Clone()
        {
            var temp = _head;
            Node<T> headNode = null;
            Node<T> tailNode = null;

            int c = 0;
            while (temp != null)
            {
                var node = new Node<T>(temp.Value);
                var prevNode = tailNode;
                tailNode = node;
                if (c == 0)
                    headNode = tailNode;
                else
                        // ReSharper disable once PossibleNullReferenceException
                    prevNode.NextNode = tailNode;
                c++;
                temp = temp.NextNode;
            }

            return new Queue<T>(headNode, tailNode, c);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new QueueEnumerator<T>(_head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public event EventHandler<PushToQueueEventArgs<T>> Pushed;
        public event EventHandler<PopFromQueueEventArgs<T>> Popped;

        public void Enqueue(T value)
        {
            var node = new Node<T>(value);
            var prevNode = _tail;
            _tail = node;
            if (Count == 0)
                _head = _tail;
            else
                prevNode.NextNode = _tail;
            Count++;
            Pushed?.Invoke(this, new PushToQueueEventArgs<T>(value, $"{value} pushed"));
        }

        public void Enqueue(params T[] arr)
        {
            foreach (var item in arr)
                Enqueue(item);
        }

        public void Add(params T[] value)
        {
            Enqueue(value);
        }

        public void Dequeue()
        {
            if (IsEmpty)
                throw new QueueException("An exception occurred: Queue is empty");
            var value = _head.Value;
            _head = _head.NextNode;
            Count--;
            Popped?.Invoke(this, new PopFromQueueEventArgs<T>(value, $"{value} popped"));
        }

        public void Clear()
        {
            _head = null;
            _tail = null;
            Count = 0;
        }

        public bool Contains(T data)
        {
            var current = _head;
            while (current != null)
            {
                if (current.Value.Equals(data))
                    return true;
                current = current.NextNode;
            }

            return false;
        }

        public void CopyTo(T[] arr, int index)
        {
            if (index < 0 || index > arr.Length - Count)
                throw new QueueException(
                        "Offset and length were out of bounds for the array or count is greater than the number of elements from index to the end of the source collection.");

            int c = 0;
            for (int i = index; i < index + Count; i++)
            {
                arr[i] = this[c];
                c++;
            }

            Console.WriteLine("Queue was copied to array");
        }
    }
}