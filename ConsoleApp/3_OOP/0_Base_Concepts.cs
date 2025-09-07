
// БАЗОВЫЕ КОНЦЕПЦИИ ООП
// Объектно-Ориентированное Программирование (ООП) — это парадигма программирования, основанная на концепции "объектов",
//     которые содержат данные (поля) и методы для работы с этими данными. ООП позволяет создавать более модульные,
//     поддерживаемые и масштабируемые приложения
// 4 основных принципа ООП:
//     - Инкапсуляция (объединение полей и методов для работы с этими полями в единый объект)
//     - Наследование (создание новых классов на основе предыдущих)
//     - Полиморфизм (возможность объектов разных классов обрабатывать данные через один интерфейс)
//     - Абстракция (работа с объектами через их интерфейсы)



// БАЗОВАЯ КОНЦЕПЦИЯ - КЛАСС И ОБЪЕКТ
public class OuterCar
{
    // Класс - шаблон
    public class Car
    {
        public string Model;
        public int Year;
    
        public void StartEngine()
        {
            Console.WriteLine("Engine started");
        }
    }
    // Объекты - экземпляры класса
    Car myCar = new Car { Model = "Toyota", Year = 2020 };
    Car yourCar = new Car { Model = "Honda", Year = 2021 };
}



// ИНКАПСУЛЯЦИЯ
public class BankAccount   // Единый интерфейс для работы с полем через метод
{
    private decimal balance;   // Поле, с которым работаем
    
    public decimal GetBalance()   // Метод для работы
    {
        return balance;
    }
    
    public void Deposit(decimal amount)   // Ещё один метод для работы с полем
    {
        if (amount > 0)
            balance += amount;
    }
}



// НАСЛЕДОВАНИЕ
public class OuterAnimal
{
    public class Animal   // Базовый класс
    {
        public string Name { get; set; }
        public virtual void Speak() => Console.WriteLine("Some sound");
    }

    public class Dog : Animal   // Производный класс
    {
        public override void Speak() => Console.WriteLine("Woof!");
    }



    // ПОЛИМОРФИЗМ
    Animal myAnimal = new Dog();
    // myAnimal.Speak();   // "Woof!" - вызывается метод производного класса
}



// АБСТРАКЦИЯ
public interface IShape
{
    double GetArea();   // Абстрактный метод без реализации
}

public class Circle : IShape
{
    public double Radius;
    public double GetArea() => Math.PI * Radius * Radius;   // Реализация в наследнике
}



// МОДИФИКАТОРЫ ДОСТУПА
// Определяют видимость членов класса
// public - доступен из любого места
// private - доступен только внутри класса
// protected - доступен внутри класса и производных классов
// internal - доступен в пределах сборки
// protected internal - доступен в пределах сборки или в производных классах
// private protected - доступен в пределах сборки только в производных классах



// КЛЮЧЕВЫЕ СЛОВА
// class - определение класса
// struct - определение структуры
// interface - определение интерфейса
// abstract - абстрактный класс или член
// virtual - виртуальный метод (может быть переопределён)
// override - переопределение виртуального метода
// sealed - запрет наследования или переопределения
// static - статический член или класс
// new - создание объекта или скрытие члена базового класса
// base - доступ к членам базового класса
// this - ссылка на текущий объект