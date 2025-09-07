
namespace MyInheritance
{
    // НАСЛЕДОВАНИЕ
    // Наследование — это механизм, позволяющий создавать новый класс на основе существующего класса
    // Новый класс (производный) наследует члены базового класса и может добавлять собственные члены или изменять унаследованные
    
    
    
    // БАЗОВЫЙ СИНТАКСИС
    public class BaseInheritance
    {
        // Базовый класс (родительский)
        public class Animal
        {
            public string Name { get; set; }
    
            public void Eat()
            {
                Console.WriteLine($"{Name} is eating.");
            }
    
            public virtual void MakeSound()
            {
                Console.WriteLine("Some generic animal sound");
            }
        }

        // Производный класс (дочерний)
        public class Dog : Animal // Наследование обозначается :
        {
            public void Bark()
            {
                Console.WriteLine($"{Name} is barking.");
            }
    
            // Переопределение виртуального метода
            public override void MakeSound()
            {
                Console.WriteLine("Woof woof!");
            }
        }

        // Еще один производный класс
        public class Cat : Animal
        {
            public void Purr()
            {
                Console.WriteLine($"{Name} is purring.");
            }
    
            public override void MakeSound()
            {
                Console.WriteLine("Meow!");
            }
        }
    }
    
    
    
    // КЛЮЧЕВЫЕ СЛОВА И МОДИФИКАТОРЫ
    // base - доступ к членам базового класса
    public class BaseExample
    {
        public class Animal
        {
            protected string _sound = "Generic sound";
    
            public virtual void MakeSound()
            {
                Console.WriteLine(_sound);
            }
        }

        public class Dog : Animal
        {
            public Dog()
            {
                _sound = "Woof";
            }
    
            public override void MakeSound()
            {
                base.MakeSound(); // Вызов метода базового класса
                Console.WriteLine("Additional dog sound");
            }
        }
    }
    // sealed - запрет дальнейшего наследования
    public class SealedExample
    {
        public sealed class CannotBeInherited
        {
            // Класс не может быть унаследован
        }

        // Ошибка компиляции:
        // public class TryInherit : CannotBeInherited { }

        // sealed можно применять и к методам
        public class Animal
        {
            public virtual void MakeSound() { }
        }

        public class Dog : Animal
        {
            public sealed override void MakeSound() // Запечатанный метод
            {
                Console.WriteLine("Woof");
            }
        }

        public class Puppy : Dog
        {
            // Ошибка: нельзя переопределить запечатанный метод
            // public override void MakeSound() { }
        }
    }
    // new - сокрытие членов базового класса
    public class NewExample
    {
        public class BaseClass
        {
            public void Method()
            {
                Console.WriteLine("Base method");
            }
        }

        public class DerivedClass : BaseClass
        {
            public new void Method() // Сокрытие метода базового класса
            {
                Console.WriteLine("Derived method");
            }
        }

        // Использование:
        BaseClass obj1 = new DerivedClass();
        // obj1.Method(); // Base method

        DerivedClass obj2 = new DerivedClass();
        // obj2.Method(); // Derived method
    }
    
    
    
    // КОНСТРУКТОРЫ И НАСЛЕДОВАНИЕ
    // Конструкторы не наследуются, но производный класс должен вызывать конструктор базового класса
    public class ConstructorExample
    {
        public class Animal
        {
            public string Name { get; set; }
    
            public Animal(string name)
            {
                Name = name;
                Console.WriteLine($"Animal constructor: {name}");
            }
        }

        public class Dog : Animal
        {
            public string Breed { get; set; }
    
            public Dog(string name, string breed) : base(name) // Вызов конструктора базового класса
            {
                Breed = breed;
                Console.WriteLine($"Dog constructor: {breed}");
            }
        }

        // Использование:
        Dog dog = new Dog("Rex", "German Shepherd");
        // Output:
        // Animal constructor: Rex
        // Dog constructor: German Shepherd
    }
}