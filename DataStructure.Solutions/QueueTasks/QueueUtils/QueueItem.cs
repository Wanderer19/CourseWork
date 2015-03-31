namespace DataStructure.Solutions.QueueTasks.QueueUtils
{
    public class QueueItem<T>
    {
        public T Value { get; set; }
        public QueueItem<T> Next { get; set; }
    }
}
