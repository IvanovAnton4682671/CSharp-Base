
namespace MyInterface
{
    // ИНТЕРФЕЙС
    // Интерфейс определяет контракт, который реализуют классы
    // Он содержит только объявления методов, свойств, событий и индексаторов без реализации
    // Важно: классы и интерфейсы могут реализовывать сколько угодно интерфейсов
    
    
    
    // ПРИМЕР ИНТЕРФЕЙСОВ
    public interface IDrawable
    {
        void Draw(); // По умолчанию public
        string Color { get; set; } // Свойство
    }

    public interface IResizable
    {
        void Resize(double factor);
    }

    public interface ISelectable
    {
        bool IsSelected { get; set; }
        void Select();
        void Deselect();
    }
    
    
    
    // РЕАЛИЗАЦИЯ ИНТЕРФЕЙСОВ
    public class InterfaceExample
    {
        public class Circle : IDrawable, IResizable, ISelectable
        {
            public double Radius { get; set; }
            public string Color { get; set; }
            public bool IsSelected { get; set; }
    
            public void Draw()
            {
                Console.WriteLine($"Drawing a {Color} circle with radius {Radius}");
            }
    
            public void Resize(double factor)
            {
                Radius *= factor;
                Console.WriteLine($"Resized to radius {Radius}");
            }
    
            public void Select()
            {
                IsSelected = true;
                Console.WriteLine("Circle selected");
            }
    
            public void Deselect()
            {
                IsSelected = false;
                Console.WriteLine("Circle deselected");
            }
        }

        public class Rectangle : IDrawable, IResizable
        {
            public double Width { get; set; }
            public double Height { get; set; }
            public string Color { get; set; }
    
            public void Draw()
            {
                Console.WriteLine($"Drawing a {Color} rectangle {Width}x{Height}");
            }
    
            public void Resize(double factor)
            {
                Width *= factor;
                Height *= factor;
                Console.WriteLine($"Resized to {Width}x{Height}");
            }
        }
    }
    
    
    
    // ЯВНАЯ РЕАЛИЗАЦИЯ ИНТЕРФЕЙСОВ
    public class InterfaceExample2
    {
        public class AdvancedCircle : IDrawable, IResizable
        {
            public double Radius { get; set; }
    
            // Явная реализация интерфейса
            void IDrawable.Draw()
            {
                Console.WriteLine($"Drawing circle with radius {Radius}");
            }
    
            void IResizable.Resize(double factor)
            {
                Radius *= factor;
            }
    
            // Обычный публичный метод
            public void PrintInfo()
            {
                Console.WriteLine($"Circle radius: {Radius}");
            }
        }

        // Использование явной реализации:
        AdvancedCircle circle = new AdvancedCircle { Radius = 5 };
        // circle.PrintInfo(); // Circle radius: 5

        // circle.Draw(); // Ошибка: метод не доступен напрямую
        IDrawable drawable = circle;
        // drawable.Draw(); // Drawing circle with radius 5

        IResizable resizable = circle;
        // resizable.Resize(2.0);
        // circle.PrintInfo(); // Circle radius: 10
    }
    // Важно: при явной реализации методы не являются частью публичного контракта класса
    // Т.е. для использование таких методов нужно применять апкаст
    // Кроме того, явная реализация обычно применяется для предотвращения конфликтов имён, например, когда в нескольких интерфейсах есть методы с одинаковой сигнатурой
}