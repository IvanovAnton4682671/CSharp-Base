
// СТЕК
// Стек - коллекция, работающая по принципу LIFO (Last In - First Out) - последний добавленный элемент извлекается первым



public class MyStack
{
    public static void Main()
    {
        // ИНИЦИАЛИЗАЦИЯ
        void Creating()
        {
            Stack<int> stack = new Stack<int>();   // Пустой стек
            Stack<string> names = new Stack<string>(100);   // С начальной емкостью
            List<int> list = new List<int> { 1, 2, 3 };
            Stack<int> fromList = new Stack<int>(list);   // Из другой коллекции (порядок: 3, 2, 1 (так как добавляются в обратном порядке))
        }
        
        
        
        // ОСНОВНЫЕ ОПЕРАЦИИ
        void Operations()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);   // Добавление элементов (стек: [1])
            stack.Push(2);   // Стек: [2, 1]
            stack.Push(3);   // Стек: [3, 2, 1]
            int top = stack.Pop();     // Извлечение элемента (вернёт 3, Стек: [2, 1])
            int next = stack.Peek();   // Просмотр верхнего элемента без извлечения (вернёт 2, Стек остается: [2, 1])
            bool isEmpty = stack.Count == 0;   // Проверка наличия элементов (false)
            int count = stack.Count;   // Количество элементов (2)
            stack.Clear();   // Очистка стека
        }
    }
}