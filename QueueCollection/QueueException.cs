using System;

namespace QueueCollection
{
    public class QueueException : NullReferenceException
    {
        public QueueException(string message) : base(message)
        {
        }
    }
}