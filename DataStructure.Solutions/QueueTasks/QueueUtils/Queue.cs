using System;

namespace DataStructure.Solutions.QueueTasks.QueueUtils
{
    public class Queue<T>
    {
        private QueueItem<T> head;
        private QueueItem<T> tail;

        public void Enqueue(T value)
        {
            if (head == null)
                tail = head = new QueueItem<T> { Value = value, Next = null };
            else
            {
                var item = new QueueItem<T> { Value = value, Next = null };
                tail.Next = item;
                tail = item;
            }
        }

        public T Dequeue()
        {
            if (head == null)
                throw new InvalidOperationException("Queue is empty.");

            var result = head.Value;
            head = head.Next;
            if (head == null)
                tail = null;
            return result;
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue is empty.");

            return head.Value;
        }

        public bool IsEmpty()
        {
            return head == null;
        }
    }
}
