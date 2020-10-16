using System;
using System.Collections;
using System.Collections.Generic;

namespace QueueCollection
{
    internal class QueueEnumerator<T> : IEnumerator<T>
    {
        private Node<T> _currentNode;
        private Node<T> _head;

        public QueueEnumerator(Node<T> head)
        {
            _head = head;
        }

        public T Current => _currentNode.Value;

        public bool MoveNext()
        {
            if (_head != null)
            {
                _currentNode = _head;
                _head = _head.NextNode;
                return true;
            }

            return false;
        }

        object IEnumerator.Current => Current;

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }
    }
}