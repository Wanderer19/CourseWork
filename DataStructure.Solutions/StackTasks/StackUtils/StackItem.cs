namespace DataStructure.Solutions.StackTasks.StackUtils
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
}
