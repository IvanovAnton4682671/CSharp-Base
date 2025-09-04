
// СПИСКИ
// Списки представляют собой набор элементов одного типа, однако в отличии от массивов списки могут динамически изменять свой размер



public class Lists
{
    public static void Main()
    {
        // СОЗДАНИЕ И ИНИЦИАЛИЗАЦИЯ
        List<int> numbers = new List<int>();                    // Пустой список
        List<string> names = new List<string>(100);     // С начальной емкостью (capacity)
        List<int> numbers2 = new List<int> { 1, 2, 3, 4, 5 };   // С начальными элементами
        var numbers3 = new List<int> { 1, 2, 3, 4, 5 };         // Упрощённый вид
        int[] array = { 1, 2, 3 };
        List<int> fromArray = new List<int>(array);   // Из другого перечисления (массива, другого списка)
        
        
        
        // ОСНОВНЫЕ ОПЕРАЦИИ
        // Добавление
        List<int> nums = new List<int>();
        nums.Add(10);                                             // Добавление одного элемента { 10 }
        nums.Add(20);                                             // { 10, 20 }
        nums.AddRange(new int[] { 30, 40, 50 });          // Добавление коллекции элементов { 10, 20, 30, 40, 50 }
        nums.Insert(2, 25);                                  // Вставка элемента по индексу { 10, 20, 25, 30, 40, 50 }
        nums.InsertRange(3, new int[] { 27, 28 });   // { 10, 20, 25, 27, 28, 30, 40, 50 }
        
        // Удаление
        nums.Remove(30);                        // Удаление по значению (удаляет первое вхождение) { 10, 20, 40, 50, 30 } - удален первый 30
        nums.RemoveAt(0);                  // Удаление по индексу { 20, 40, 50, 30 }
        nums.RemoveRange(1, 2);      // Удаление диапазона { 20, 30 } - удалено 2 элемента начиная с индекса 1
        nums.RemoveAll(x => x > 25);   // Удаление всех элементов, удовлетворяющих условию { 20 } - удалены все элементы > 25
        nums.Clear();                           // Очистка всего списка { }
        
        // Доступ к элементам
        List<string> fruits = new List<string> { "apple", "banana", "cherry" };
        string first = fruits[0];                                  // Чтение по индексу "apple"
        string last = fruits[^1];                                  // "cherry" (индекс с конца)
        fruits[1] = "blueberry";                                   // Запись по индексу { "apple", "blueberry", "cherry" }
        List<string> sublist = fruits.GetRange(1, 2);   // Получение диапазона { "blueberry", "cherry" }
        
        // Поиск и проверка
        List<int> nums1 = new List<int> { 5, 3, 8, 1, 9, 3 };
        bool hasFive = nums1.Contains(5);                           // Проверка существования элемента true
        int index = nums1.IndexOf(8);                               // Поиск индекса 2
        int lastIndex = nums1.LastIndexOf(3);                       // 5
        int firstEven = nums1.Find(x => x % 2 == 0);       // Поиск элементов по условию 8
        int lastEven = nums1.FindLast(x => x % 2 == 0);    // 8
        List<int> allEvens = nums1.FindAll(x => x % 2 == 0);     // Поиск всех элементов по условию { 8 }
        bool allPositive = nums1.TrueForAll(x => x > 0);   // Проверка всех элементов на условие true
        
        // Сортировка и преобразование
        List<int> nums2 = new List<int> { 5, 3, 8, 1, 9 };
        nums2.Sort();                                                          // Сортировка { 1, 3, 5, 8, 9 }
        nums2.Reverse();                                                       // Обратный порядок { 9, 8, 5, 3, 1 }
        int[] array2 = nums2.ToArray();                                        // Преобразование в массив из элементов
        List<string> stringNumbers = nums2.ConvertAll(x => x.ToString());   // Преобразование в другой тип { "9", "8", "5", "3", "1" }
        
        // Вместимость и производительность
        List<int> nums3 = new List<int>();
        Console.WriteLine($"Count: {nums3.Count}, Capacity: {nums3.Capacity}");   // Ёмкость (Capacity) и количество элементов (Count) 0, 0
        nums3.Add(1);
        Console.WriteLine($"Count: {nums3.Count}, Capacity: {nums3.Capacity}");   // 1, 4
        nums3.AddRange(new int[] { 2, 3, 4 });                            // Добавление 4 элементов
        Console.WriteLine($"Count: {nums3.Count}, Capacity: {nums3.Capacity}");   // 4, 4
        nums3.Add(5);                                                             // Добавление 5-го элемента - емкость удваивается
        Console.WriteLine($"Count: {nums3.Count}, Capacity: {nums3.Capacity}");   // 5, 8
        List<int> optimizedList = new List<int>(1000);                    // Оптимизация: установка емкости для избежания лишних расширений
        for (int i = 0; i < 1000; i++)
        {
            optimizedList.Add(i);   // Не будет многократного расширения массива
        }
        optimizedList.TrimExcess();                                                               // Освобождение неиспользуемой памяти
        Console.WriteLine($"Count: {optimizedList.Count}, Capacity: {optimizedList.Capacity}");   // 1000, 1000
        
        // Итерация по списку
        List<string> fruits2 = new List<string> { "apple", "banana", "cherry" };
        // Цикл for
        for (int i = 0; i < fruits2.Count; i++)
        {
            Console.WriteLine(fruits2[i]);
        }
        // Цикл foreach
        foreach (string fruit in fruits2)
        {
            Console.WriteLine(fruit);
        }
        // Использование метода ForEach
        fruits2.ForEach(fruit => Console.WriteLine(fruit));
        // С использованием индексов и диапазонов
        foreach (string fruit in fruits2[0..2])   // Первые два элемента
        {
            Console.WriteLine(fruit);
        }
    }
}