namespace WebApp.Shared.Extensions
{
    public static class EnumerableExtensions
    {
        public static Queue<T> InitializeQueueWithCapacity<T>(this Queue<T> sourceQueue, int capacity)
        {
            Queue<T> newQueue = new Queue<T>(Math.Max(sourceQueue.Count, capacity));

            foreach (T item in sourceQueue)
                newQueue.Enqueue(item);

            return newQueue;
        }
    }
}
