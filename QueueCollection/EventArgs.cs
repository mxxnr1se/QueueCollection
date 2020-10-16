using System;

namespace QueueCollection
{
    public sealed class PushToQueueEventArgs<T> : EventArgs
    {
        public PushToQueueEventArgs(T value, string message)
        {
            Message = message;
            PushedItem = value;
        }

        public T PushedItem { get; }
        public string Message { get; }
    }

    public sealed class PopFromQueueEventArgs<T> : EventArgs
    {
        public PopFromQueueEventArgs(T value, string message)
        {
            Message = message;
            PoppedItem = value;
        }

        public T PoppedItem { get; }
        public string Message { get; }
    }
}