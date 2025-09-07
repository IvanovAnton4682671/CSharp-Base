
namespace MyClass
{
    // КЛАСС
    // Класс — это пользовательский тип данных, который инкапсулирует данные (поля) и поведение (методы) в единую сущность
    // Базовый синтаксис:
    // [модификаторы_доступа] class ИмяКласса
    // {
    //     // Поля (данные)
    //     // Свойства (контролируемый доступ к данным)
    //     // Методы (поведение)
    //     // Конструкторы (инициализация)
    //     // Деструкторы (очистка ресурсов)
    //     // События
    //     // Индексаторы
    //     // Вложенные типы
    // }
    
    
    
    // ПРИМЕР КЛАССА
    public class Person
    {
        // Поля (обычно private)
        private string _name;
        private int _age;
    
        // Свойства (обычно public)
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    
        public int Age
        {
            get { return _age; }
            set 
            { 
                if (value >= 0) 
                    _age = value; 
            }
        }
    
        // Метод
        public void Introduce()
        {
            Console.WriteLine($"Hi, I'm {_name} and I'm {_age} years old.");
        }
    }
    
    
    
    // СОЗДАНИЕ ОБЪЕКТОВ (ЭКЗЕМПЛЯРОВ КЛАССА)
    // Объекты создаются с помощью оператора new, который выделяет память и вызывает конструктор
    public class CreatingObj
    {
        Person person1 = new Person(); // Создание объекта с помощью конструктора по умолчанию
        Person person2 = new Person // Создание объекта с инициализацией свойств
        { 
            Name = "Alice", 
            Age = 25 
        };
        // Person person3 = new Person("Bob", 30); // Создание объекта с вызовом параметризованного конструктора
    }
    
    
    
    // КОНСТРУКТОРЫ
    // Конструкторы — это специальные методы, которые вызываются при создании объекта для его инициализации
    public class Constructors
    {
        // ТИПЫ КОНСТРУКТОРОВ
        public class Person1
        {
            private string _name;
            private int _age;
    
            // 1. Конструктор по умолчанию (без параметров)
            public Person1()
            {
                _name = "Unknown";
                _age = 0;
            }
    
            // 2. Параметризованный конструктор
            public Person1(string name, int age)
            {
                _name = name;
                _age = age;
            }
    
            // 3. Конструктор копирования
            public Person1(Person1 otherPerson)
            {
                _name = otherPerson._name;
                _age = otherPerson._age;
            }
    
            // 4. Статический конструктор (вызывается один раз при первом обращении к классу)
            static Person1()
            {
                Console.WriteLine("Person class initialized");
            }
        }
        
        // ЦЕПОЧКА КОНСТРУКТОРОВ THIS
        // При использовании this сначала выполняется он, а затем блок кода, который его вызвал
        public class Person2
        {
            private string _name;
            private int _age;
    
            public Person2() : this("Unknown", 0) // Person2() вызывает Person2("Unknown", 0)
            {
                // После выполнения конструктора Person("Unknown", 0) можно добавить дополнительную логику
            }
    
            public Person2(string name) : this(name, 0) // Person2(string name) вызывает Person2(name, 0)
            {
                // После выполнения конструктора Person(name, 0) можно добавить дополнительную логику
            }
    
            public Person2(string name, int age)
            {
                _name = name;
                _age = age;
            }
        }
    }
    
    
    
    // ДЕСТРУКТОРЫ
    public class ResourceHolder
    {
        private int? _handle; // Пример неуправляемого ресурса
    
        public ResourceHolder()
        {
            _handle = 0; // Инициализация ресурса
        }
    
        // Деструктор (финализатор)
        ~ResourceHolder()
        {
            // Освобождение неуправляемых ресурсов
            if (_handle != null)
            {
                /* освобождение ресурса */
                _handle = null;
            }
        }
    }
    // Важно: в современном C# вместо деструкторов рекомендуется использовать интерфейс IDisposable и паттерн Dispose
    
    
    
    // СТАТИЧЕСКИЕ ЧЛЕНЫ КЛАССА
    // Статические члены принадлежат классу, а не конкретному объекту
    public class StaticExample
    {
        public class MathOperations
        {
            // Статическое поле
            public static int OperationCount = 0;
    
            // Статический метод
            public static int Add(int a, int b)
            {
                OperationCount++;
                return a + b;
            }
    
            // Статическое свойство
            public static double Pi { get; } = 3.14159;
    
            // Статический конструктор
            static MathOperations()
            {
                Console.WriteLine("MathOperations static constructor called");
            }
        }

        // Использование статических членов
        int result = MathOperations.Add(5, 3); // Обращение через имя класса
        double pi = MathOperations.Pi;
    }
    
    
    
    // ВЛОЖЕННЫЕ КЛАССЫ
    // Классы можно объявлять внутри других классов
    
    
    
    // ЧАСТИЧНЫЕ КЛАССЫ
    // Класс может быть разделен на несколько файлов с помощью ключевого слова partial
    // File1.cs
    public partial class PersonPart
    {
        private string _name;
    
        public PersonPart(string name)
        {
            _name = name;
        }
    
        partial void Validate(); // Объявление частичного метода
    }
    // File2.cs
    public partial class PersonPart
    {
        private int _age;
    
        public void SetAge(int age)
        {
            _age = age;
            Validate(); // Вызов частичного метода
        }
    
        partial void Validate() // Реализация частичного метода
        {
            if (_age < 0) throw new ArgumentException("Age cannot be negative");
        }
    }
}