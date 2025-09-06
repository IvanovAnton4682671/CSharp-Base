
// СЛОВАРИ
// Словарь представляет собой коллекцию пар ключ-значение. Ключи должны быть уникальными, значения могут повторяться



public class Dictionaries
{
    public static void Main()
    {
        // СОЗДАНИЕ И ИНИЦИАЛИЗАЦИЯ
        void Creating()
        {
            Dictionary<string, int> ages = new Dictionary<string, int>();   // Пустой словарь
            Dictionary<int, string> products = new Dictionary<int, string>(100);   // С начальной емкостью
            Dictionary<string, string> capitals = new Dictionary<string, string>   // С начальными элементами
            {
                ["Russia"] = "Moscow",
                ["USA"] = "Washington",
                ["France"] = "Paris"
            };
            Dictionary<string, int> scores = new Dictionary<string, int>   // Альтернативный синтаксис инициализации
            {
                { "Alice", 100 },
                { "Bob", 85 },
                { "Charlie", 92 }
            };
            var countries = new Dictionary<string, string> { ["Germany"] = "Berlin" };   // Использование var
        }
        
        
        
        // ОСНОВНЫЕ ОПЕРАЦИИ
        void Operations()
        {
            Dictionary<string, int> ages = new Dictionary<string, int>();
            // Добавление
            ages.Add("Alice", 25);   // Добавляет пару ("Alice", 25)
            ages["Charlie"] = 35;    // Добавляет пару ("Charlie", 35)
            ages["Alice"] = 26;      // Обновляет значение для "Alice" на 26
            if (!ages.ContainsKey("David"))   // Безопасное добавление (если ключ не существует)
            {
                ages.Add("David", 40);
            }
            bool added = ages.TryAdd("Eve", 28);   // true если добавлен, false если ключ уже существует
            // Удаление
            Dictionary<string, int> ages2 = new Dictionary<string, int>
            {
                ["Alice"] = 25,
                ["Bob"] = 30,
                ["Charlie"] = 35
            };
            ages2.Remove("Bob");   // Удаляет пару с ключом "Bob"
            bool removed = ages2.Remove("David");   // Попытка удаления несуществующего ключа (false)
            ages2.Clear();   // Удаление всех элементов (словарь становится пустым)
            // Доступ к элементам
            Dictionary<string, int> ages3 = new Dictionary<string, int>
            {
                ["Alice"] = 25,
                ["Bob"] = 30
            };
            int aliceAge = ages3["Alice"];   // Чтение значения по ключу (25)
            if (ages3.TryGetValue("Alice", out int age))   // Безопасное получение значения
            {
                Console.WriteLine(age);   // 25
            }
            bool hasAlice = ages3.ContainsKey("Alice");   // Проверка существования ключа (true)
            bool hasAge25 = ages3.ContainsValue(25);   // Проверка существования значения (true)
        }
        
        
        
        // ИТЕРАЦИЯ ПО СЛОВАРЮ
        void Iteration()
        {
            Dictionary<string, int> ages = new Dictionary<string, int>
            {
                ["Alice"] = 25,
                ["Bob"] = 30,
                ["Charlie"] = 35
            };
            foreach (KeyValuePair<string, int> pair in ages)   // Итерация по парам ключ-значение
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
            foreach (string name in ages.Keys)   // Итерация только по ключам
            {
                Console.WriteLine(name);
            }
            foreach (int age in ages.Values)   // Итерация только по значениям
            {
                Console.WriteLine(age);
            }
            foreach (var (name, age) in ages)   // Использование деконструкции
            {
                Console.WriteLine($"{name}: {age}");
            }
        }
        
        
        
        // СВЙОСТВА СЛОВАРЯ
        void Properties()
        {
            Dictionary<string, int> ages = new Dictionary<string, int>
            {
                ["Alice"] = 25,
                ["Bob"] = 30
            };
            int count = ages.Count;                  // Количество элементов (2)
            int capacity = ages.EnsureCapacity(0);   // Емкость словаря (внутренний размер массива/текущая емкость)
            ICollection<string> keys = ages.Keys;    // Коллекция всех ключей
            ICollection<int> values = ages.Values;   // Коллекция всех значений
        }
        
        
        
        // ПРОИЗВОДИТЕЛЬСНОТЬ И ЁМКОСТЬ
        void Capacity()
        {
            Dictionary<string, int> bigDictionary = new Dictionary<string, int>(10000);   // Установка начальной ёмкости для оптимизации
            bigDictionary.TrimExcess();            // Оптимизация ёмкости после добавления элементов
            bigDictionary.EnsureCapacity(20000);   // Резервирование ёмкости для будущих элементов
        }
        
        
        
        // ОСОБЕННОСТИ ИСПОЛЬЗОВАНИЯ КЛЮЧЕЙ
        // Ключи в словаре должны быть неизменяемыми или, по крайней мере, не менять свой хэш-код после добавления в словарь
        // Вот как можно реализовать использование кастомных объектов в качестве ключей
        void KeyFeatures()
        {
            public class Person
            {
                public string Name { get; set; }
                public int Age { get; set; }

                public override bool Equals(object obj)
                {
                    return obj is Person person &&
                           Name == person.Name &&
                           Age == person.Age;
                }

                public override int GetHashCode()
                {
                    return HashCode.Combine(Name, Age);
                }
            }
            // Использование кастомного объекта как ключа
            Dictionary<Person, string> personDescriptions = new Dictionary<Person, string>();
            Person alice = new Person { Name = "Alice", Age = 25 };
            personDescriptions.Add(alice, "Software Developer");
            // Поиск по ключу
            Person searchKey = new Person { Name = "Alice", Age = 25 };
            if (personDescriptions.TryGetValue(searchKey, out string description))
            {
                Console.WriteLine(description);   // "Software Developer"
            }
        }
        
        
        
        // МНОГОПОТОЧНОСТЬ
        // Стандартный Dictionary<TKey, TValue> не является потокобезопасным
        // Для многопоточных сценариев используется ConcurrentDictionary<TKey, TValue>
        void MultiThreading()
        {
            using System.Collections.Concurrent;
            
            ConcurrentDictionary<string, int> concurrentAges = new ConcurrentDictionary<string, int>();
            concurrentAges.TryAdd("Alice", 25);
            concurrentAges.AddOrUpdate("Alice", 26, (key, oldValue) => oldValue + 1);   // Обновление значения
        }
    }
}