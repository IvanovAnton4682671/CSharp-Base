
namespace MyAbstractClass
{
    // АБСТРАКТНЫЙ КЛАСС
    // Абстрактный класс не может создавать экземпляры, а также может иметь абстрактные методы без реализации
    // Однако в случае наследования наследник ОБЯЗАН реализовать все абстрактные методы
    // Важно: класс (обычный и абстрактный) может наследоваться только от одного обычного/абстрактного класса
    
    
    
    // ПРИМЕР
    public abstract class Shape
    {
        // Абстрактный метод (не имеет реализации)
        public abstract double CalculateArea();
    
        // Обычный метод с реализацией
        public void Print()
        {
            Console.WriteLine($"Area: {CalculateArea()}");
        }
    
        // Виртуальный метод с реализацией по умолчанию
        public virtual void Draw()
        {
            Console.WriteLine("Drawing a shape");
        }
    }

    public class Circle : Shape
    {
        public double Radius { get; set; }
    
        // Реализация абстрактного метода
        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    
        // Переопределение виртуального метода
        public override void Draw()
        {
            Console.WriteLine($"Drawing a circle with radius {Radius}");
        }
    }

    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }
    
        public override double CalculateArea()
        {
            return Width * Height;
        }
    
        public override void Draw()
        {
            Console.WriteLine($"Drawing a rectangle {Width}x{Height}");
        }
    }
}