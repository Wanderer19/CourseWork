using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork.Algorithms
{
    public class QueueItem<T>
    {
        public T Value { get; set; }
        public QueueItem<T> Next { get; set; }
    }

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
                throw new InvalidOperationException();
            
            var result = head.Value;
            head = head.Next;
            if (head == null)
                tail = null;
            return result;
        }
    }
}
