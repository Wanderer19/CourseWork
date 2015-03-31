using System;

namespace DataStructure.Solutions.StackTasks.StackUtils
{
    public class Stack<T>
    {
        private StackItem<T> head;

        public void Push(T value)
        {
            if (head == null)
                head = new StackItem<T>() { Value = value, Next = null };
            else
            {
                var item = new StackItem<T>() { Value = value, Next = head };
                head = item;
            }
        }

        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty.");
           
            var result = head;
            head = result.Next;
            return result.Value;
        }

        public Stack<T> Clone()
        {
            var stack = new Stack<T> { head = IsEmpty() ? null : head.Clone() };
            return stack;
        }

        public void Clear()
        {
            head = null;
        }

        public bool IsEmpty()
        {
            return head == null;
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            return head.Value;
        }
    }
}
