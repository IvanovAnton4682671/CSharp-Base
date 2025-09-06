
// LINQ
// LINQ (Language Integrated Query) -  это технология .NET, которая предоставляет унифицированный синтаксис для запросов к различным источникам данных
// LINQ позволяет писать выразительные, декларативные запросы к коллекциям, базам данных, XML и другим источникам



public class MyLinq
{
    public static void Main()
    {
        // 2 СИНТАКСИСА
        void TwoSyntaxes()
        {
            // Методы расширений
            var numbers = new List<int> { 1, 2, 3, 4, 5 };
            var result = numbers
                .Where(n => n > 2)
                .Select(n => n * 2)
                .OrderByDescending(n => n);
            // Синтаксис запросов
            var numbers2 = new List<int> { 1, 2, 3, 4, 5 };
            var result2 = from n in numbers2
                where n > 2
                select n * 2;
        }
        
        
        
        // ОСНОВНЫЕ ОПЕРАЦИИ
        void Operations()
        {
            // ФИЛЬТРАЦИЯ
            var numbers = new List<int> { 1, 2, 3, 4, 5 };
            // Where - фильтрация элементов
            var evenNumbers = numbers.Where(n => n % 2 == 0);   // 2, 4
            // OfType - фильтрация по типу
            var mixedList = new List<object> { 1, "hello", 2, "world" };
            var strings = mixedList.OfType<string>();   // "hello", "world"
            
            // ПРОЕКЦИЯ
            var persons = new List<Person>
            {
                new Person { Name = "Alice", Age = 25 },
                new Person { Name = "Bob", Age = 30 }
            };
            // Select - преобразование элементов
            var names = persons.Select(p => p.Name);   // "Alice", "Bob"
            // SelectMany - "разворачивание" коллекций
            var allHobbies = persons.SelectMany(p => p.Hobbies);
            
            // СОРТИРОВКА
            var persons2 = new List<Person> { /* ... */ };
            // OrderBy / ThenBy - восходящая сортировка
            var sorted = persons2.OrderBy(p => p.Age).ThenBy(p => p.Name);
            // OrderByDescending / ThenByDescending - нисходящая сортировка
            var sortedDesc = persons2.OrderByDescending(p => p.Age);
            
            // ГРУППИРОВКА
            var persons3 = new List<Person> { /* ... */ };
            // GroupBy - группировка элементов
            var groups = persons3.GroupBy(p => p.Age);
            foreach (var group in groups)
            {
                Console.WriteLine($"Age: {group.Key}");
                foreach (var person in group)
                {
                    Console.WriteLine($"  {person.Name}");
                }
            }
            
            // АГРЕГАЦИЯ
            var numbers2 = new List<int> { 1, 2, 3, 4, 5 };
            // Count - количество элементов
            int count = numbers2.Count();   // 5
            int countEven = numbers2.Count(n => n % 2 == 0);   // 2
            // Sum - сумма элементов
            int sum = numbers2.Sum();   // 15
            // Average - среднее значение
            double average = numbers2.Average();   // 3
            // Min/Max - минимальное/максимальное значение
            int min = numbers2.Min();   // 1
            int max = numbers2.Max();   // 5
            // Aggregate - пользовательская агрегация
            int product = numbers2.Aggregate(1, (acc, n) => acc * n);   // 120
            
            // КВАНТОРЫ
            var numbers3 = new List<int> { 1, 2, 3, 4, 5 };
            // Any - проверка наличия элементов
            bool hasElements = numbers3.Any();   // true
            bool hasEven = numbers3.Any(n => n % 2 == 0);   // true
            // All - проверка всех элементов
            bool allEven = numbers3.All(n => n % 2 == 0);   // false
            // Contains - проверка наличия элемента
            bool containsThree = numbers3.Contains(3);   // true
            
            // ПОЛУЧЕНИЕ ЭЛЕМЕНТОВ
            var numbers4 = new List<int> { 1, 2, 3, 4, 5 };
            // First/FirstOrDefault - первый элемент
            int first = numbers4.First();   // 1
            int firstEven = numbers4.First(n => n % 2 == 0);   // 2
            int firstOrDefault = numbers4.FirstOrDefault(n => n > 10);   // 0
            // Last/LastOrDefault - последний элемент
            int last = numbers4.Last();   // 5
            // Single/SingleOrDefault - единственный элемент
            int single = numbers4.Single(n => n == 3);   // 3
            // ElementAt/ElementAtOrDefault - элемент по индексу
            int third = numbers4.ElementAt(2);   // 3
            
            // РАБОТА С МНОЖЕСТВАМИ
            var set1 = new List<int> { 1, 2, 3 };
            var set2 = new List<int> { 3, 4, 5 };
            // Distinct - уникальные элементы
            var unique = numbers.Distinct();
            // Union - объединение множеств
            var union = set1.Union(set2);   // 1, 2, 3, 4, 5
            // Intersect - пересечение множеств
            var intersect = set1.Intersect(set2);   // 3
            // Except - разность множеств
            var except = set1.Except(set2);   // 1, 2
            // Concat - конкатенация последовательностей
            var concat = set1.Concat(set2);   // 1, 2, 3, 3, 4, 5
            
            // РАЗБИЕНИЕ
            var numbers5 = new List<int> { 1, 2, 3, 4, 5 };
            // Skip - пропуск элементов
            var skipped = numbers5.Skip(2); // 3, 4, 5
            // Take - взятие элементов
            var taken = numbers5.Take(3); // 1, 2, 3
            // SkipWhile/TakeWhile - пропуск/взятие по условию
            var skippedWhile = numbers5.SkipWhile(n => n < 3); // 3, 4, 5
        }
        
        
        
        // ОТЛОЖЕННОЕ И НЕМЕДЛЕННОЕ ВЫПОЛНЕНИЕ
        void Returning()
        {
            // ОТЛОЖЕННОЕ
            var numbers = new List<int> { 1, 2, 3, 4, 5 };
            var query = numbers.Where(n => n > 3);   // Запрос не выполняется
            numbers.Add(6);   // Изменения влияют на результат
            foreach (var n in query)   // Запрос выполняется здесь
            {
                Console.WriteLine(n);   // 4, 5, 6
            }
            
            // НЕМЕДЛЕННОЕ
            var numbers2 = new List<int> { 1, 2, 3, 4, 5 };
            var list = numbers2.Where(n => n > 3).ToList();   // Запрос выполняется немедленно
            numbers2.Add(6);   // Изменения не влияют на результат
            foreach (var n in list)
            {
                Console.WriteLine(n);   // 4, 5
            }
        }
    }
}