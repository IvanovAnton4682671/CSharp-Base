
// ХЭШ-СЕТ
// Хэш-сет - коллекция уникальных элементов, основанная на хэш-таблицах
// Он обеспечивает высокопроизводительные операции добавления, удаления и поиска элементов (в среднем O(1))
// А также предоставляет математические операции над множествами (объединение, пересечение, разность)
// Основные особенности хэш-сета:
// - содержит только уникальные элементы (дубликаты игнорируются)
// - не сохраняет порядок элементов
// - обеспечивает быстрый поиск элемента
// - поддерживает операции теории множеств



public class MyHashSet
{
    public static void Main()
    {
        // СОЗДАНИЕ И ИНИЦИАЛИЗАЦИЯ
        void Creating()
        {
            HashSet<int> numbers = new HashSet<int>();   // Пустой HashSet
            HashSet<string> names = new HashSet<string>(100);     // С начальной емкостью
            HashSet<int> numbers2 = new HashSet<int> { 1, 2, 3, 4, 5 };   // С начальными элементами
            List<int> list = new List<int> { 1, 2, 2, 3, 3, 3 };   // Из другой коллекции
            HashSet<int> fromList = new HashSet<int>(list);        // { 1, 2, 3 } - дубликаты удалены
            HashSet<string> caseInsensitive = new HashSet<string>(StringComparer.OrdinalIgnoreCase);    // С указанием компаратора для сравнения элементов (игнорирует регистр для строк)
        }
        
        
        
        // ОСНОВНЫЕ ОПЕРАЦИИ
        void Operations()
        {
            // Добавление и удаление
            HashSet<int> numbers = new HashSet<int>();
            numbers.Add(1);   //  Добавление элемента (true)
            numbers.Add(1);   // false - элемент уже существует
            numbers.UnionWith(new[] { 2, 3, 4 });   // Добавление коллекции элементов (добавляет 2, 3, 4)
            numbers.Remove(3);    // Удаление элемента (true)
            numbers.Remove(10);   // false - элемента не существует
            numbers.Clear();      // Удаление всех элементов (HashSet становится пустым)
            // Проверка существования
            bool containsThree = numbers.Contains(3);   // Проверка существования элемента (true)
            bool containsTen = numbers.Contains(10);    // false
            HashSet<int> subset = new HashSet<int> { 1, 2 };
            bool isSubset = subset.IsSubsetOf(numbers);       // Проверка является ли подмножеством (true)
            bool isSuperset = numbers.IsSupersetOf(subset);   // Проверка является ли надмножеством (true)
            HashSet<int> sameSet = new HashSet<int> { 1, 2, 3, 4 };
            bool setsEqual = numbers.SetEquals(sameSet);   // Проверка на полное совпадение (true)
        }
        
        
        
        // ОПЕРАЦИИ НАД МНОЖЕСТВАМИ
        void SetOperations()
        {
            // Модифицирующие операции
            HashSet<int> setA = new HashSet<int> { 1, 2, 3, 4, 5 };
            HashSet<int> setB = new HashSet<int> { 4, 5, 6, 7, 8 };
            setA.UnionWith(setB);             // Объединение (модифицирует исходный набор) - setA становится { 1, 2, 3, 4, 5, 6, 7, 8 }
            setA.IntersectWith(setB);         // Пересечение (модифицирует исходный набор) - setA становится { 4, 5 } (если без предыдущей операции)
            setA.ExceptWith(setB);            // Разность (модифицирует исходный набор) - setA становится { 1, 2, 3 } (если без предыдущей операции)
            setA.SymmetricExceptWith(setB);   // Симметрическая разность (элементы, которые есть только в одном из наборов) - setA становится { 1, 2, 3, 6, 7, 8 } (если без предыдущей операции)
            // Немодифицирующие операции
            HashSet<int> setC = new HashSet<int> { 1, 2, 3 };
            HashSet<int> setD = new HashSet<int> { 3, 4, 5 };
            bool overlaps = setC.Overlaps(setD);     // Проверка без модификации (true - есть общие элементы)
            bool isSubset = setC.IsSubsetOf(setD);   // false
            bool isProperSubset = setC.IsProperSubsetOf(new HashSet<int> { 1, 2, 3, 4 });   // true
            HashSet<int> union = new HashSet<int>(setC);
            union.UnionWith(setD);   // Создание новых множеств на основе операций ({ 1, 2, 3, 4, 5 })
            HashSet<int> intersection = new HashSet<int>(setC);
            intersection.IntersectWith(setD);   // { 3 }
        }
        
        // ИТЕРАЦИЯ
        void Iteration()
        {
            HashSet<string> fruits = new HashSet<string> { "apple", "banana", "cherry" };
            foreach (string fruit in fruits)   // Цикл foreach
            {
                Console.WriteLine(fruit);
            }
            string[] fruitArray = new string[fruits.Count];
            fruits.CopyTo(fruitArray);       // Копирование в массив
            string first = fruits.First();   // Использование индексатора (не рекомендуется, так как порядок не гарантирован/может возвращать любой элемент)
        }
        
        
        
        // ПРОИЗВОДИТЕЛЬНОСТЬ И ЁМКОСТЬ
        void Capacity()
        {
            HashSet<int> largeSet = new HashSet<int>(10000);   // Установка начальной ёмкости для оптимизации
            largeSet.TrimExcess();   // Оптимизация ёмкости после добавления элементов
            int capacity = largeSet.EnsureCapacity(0);   // Получение информации о ёмкости
        }
        
        
        
        // ИСПОЛЬЗОВАНИЕ С КАСТОМНЫМИ ОБЪЕКТАМИ
        void FeaturesObj()
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
            // Использование кастомного объекта
            HashSet<Person> people = new HashSet<Person>();
            Person alice = new Person { Name = "Alice", Age = 25 };
            people.Add(alice);
            // Поиск объекта
            Person searchPerson = new Person { Name = "Alice", Age = 25 };
            bool contains = people.Contains(searchPerson);   // true
        }



        // МНОГОПОТОЧНОСТЬ
        // Для работы в многопоточном режиме рекомендуется использовать ConcurrentDictionary как потокобезопасный HashSet
    }
}