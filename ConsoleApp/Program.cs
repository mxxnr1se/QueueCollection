using System;
using QueueCollection;

//using System.Collections.Generic;

namespace ConsoleApp
{
    internal static class Program
    {
        private static void Main()
        {
            var stringQueue1 = new Queue<string>();
            stringQueue1.Pushed += (sender, args) => Console.WriteLine(args.Message);
            stringQueue1.Popped += (sender, args) => Console.WriteLine(args.Message);

            stringQueue1.Enqueue("String 0");
            stringQueue1.Enqueue("String 1");
            stringQueue1.Enqueue("String 2", "String 3");

            stringQueue1.Dequeue();
            stringQueue1.Dequeue();

            var stringQueue2 = (Queue<string>) stringQueue1.Clone();
            Console.WriteLine("\nStringQueue1");
            PrintQueue(stringQueue1);
            Console.WriteLine("StringQueue2");
            PrintQueue(stringQueue2);

            Console.WriteLine($"StringQueue2 peek: {stringQueue2.Peek}");

            stringQueue2.Clear();

            Console.WriteLine($"StringQueue2 is empty: {stringQueue2.IsEmpty.ToString()}");

            var intQueue = new Queue<int> {0, 1, 2, 3};

            PrintQueue(intQueue);

            int[] intArray = {5, 4, 3, 2, 1, 0};

            intQueue.CopyTo(intArray, 1);

            Console.WriteLine("\nIntQueue");
            foreach (int item in intQueue)
                Console.WriteLine($"{item.ToString()}");

            Console.WriteLine($"\nInq Queue contains 4 : {intQueue.Contains(4).ToString()}\n");
        }

        private static void PrintQueue(Queue<int> q)
        {
            foreach (int item in q)
                Console.WriteLine(item);
            Console.WriteLine();
        }

        private static void PrintQueue(Queue<string> q)
        {
            foreach (string item in q)
                Console.WriteLine(item);
            Console.WriteLine();
        }
    }
}