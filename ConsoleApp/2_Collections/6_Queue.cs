
// ОЧЕРЕДЬ
// Очередь - коллекция, работающая по принципу FIFO (First In - First Out) - первый добавленный элемент извлекается первым



public class MyQueue
{
    public static void Main()
    {
        // ИНИЦИАЛИЗАЦИЯ
        void Creating()
        {
            Queue<int> queue = new Queue<int>();   // Пустая очередь
            Queue<string> names = new Queue<string>(100);   // С начальной емкостью
            List<int> list = new List<int> { 1, 2, 3 };
            Queue<int> fromList = new Queue<int>(list);   // Из другой коллекции (порядок: 1, 2, 3)
        }
        
        
        
        // ОСНОВНЫЕ ОПЕРАЦИИ
        void Operations()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);   // Добавление элементов (очередь: [1])
            queue.Enqueue(2);   // Очередь: [1, 2]
            queue.Enqueue(3);   // Очередь: [1, 2, 3]
            int first = queue.Dequeue();   // Извлечение элемента (вернёт 1, очередь: [2, 3])
            int next = queue.Peek();       // Просмотр первого элемента без извлечения (вернёт 2, очередь остается: [2, 3])
            bool isEmpty = queue.Count == 0;   // Проверка наличия элементов (false)
            int count = queue.Count;   // Количество элементов (2)
            queue.Clear();   // Очистка очереди
        }
        
        
        
        // МНОГОПОТОЧНОСТЬ
        // Стандартная Queue<T> не является потокобезопасной
        // Для многопоточных сценариев используется ConcurrentQueue<T>
        void MultiThreading()
        {
            using System.Collections.Concurrent;
            
            ConcurrentQueue<int> concurrentQueue = new ConcurrentQueue<int>();
            concurrentQueue.Enqueue(1);
            concurrentQueue.TryDequeue(out int result);   // result = 1
        }
    }
}