namespace PracticalWork.Algorithms
{
    public class StackItem<T>
    {
        public T Value { get; set; }
        public StackItem<T> Next { get; set; }

        public StackItem<T> Clone()
        {
            return new StackItem<T>() { Value = Value, Next = Next };
        }
    }

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
            var result = head;
            head = result.Next;
            return result.Value;
        }

        public Stack<T> Clone()
        {
            var stack = new Stack<T> {head = IsEmpty() ? null : head.Clone()};
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
            return IsEmpty() ? default(T) : head.Value;
        }
    }
}
