namespace PracticalWork.Algorithms.QueueUtils
{
    public class QueueItem<T>
    {
        public T Value { get; set; }
        public QueueItem<T> Next { get; set; }
    }
}
