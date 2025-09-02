
// МЕТОДЫ
// В данном разделе будут рассматриваться статические методы как аналог "глобальных" функций



// Тестовый класс для работы с методами
public class Methods
{
    static void Main()
    {
        // СИНТАКСИС И ВЫЗОВ
        // модификатор возвращаемый_тип название(тип_параметра1 параметр1, ...)
        // {
        //     тело метода
        //     return результат; (если тип не void)
        // }
        // название(параметр1); - вызов
        static void PrintGreeting()
        {
            Console.WriteLine("Hello, World!");
        }
        PrintGreeting();
        
        
        
        // МОДИФИКАТОРЫ ДОСТУПА
        // Определяют видимость метода. Пока используется static для вызова без создания объекта
        // public - доступен из любого места
        // private - доступен только внутри класса
        // protected - доступен в текущем классе и его производных
        // internal - доступен в пределах сборки
        
        
        
        // ПЕРЕДАЧА ПАРАМЕТРОВ
        // Простые параметры
        static void PrintMessageCount(string message, int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(message);
            }
        }
        PrintMessageCount("Hello, World!", 5);
        
        // ПЕРЕДАЧА С РАЗЛИЧНЫМИ СВОЙСТВАМИ
        // Передача по значению
        // При передаче значащего типа передаётся его копия, т.е. модернизировать изначальную переменную нельзя
        static void ModifyNumber(int num)
        {
            num *= 10;
            Console.WriteLine($"num inside method: {num}");
        }
        int num1 = 1;
        ModifyNumber(num1);
        Console.WriteLine($"num1 outside method: {num1}");
        // Передача по ссылке
        // При передаче значащего типа по ссылке можно изменять изначальную переменную, а не её копию, т.е. работать как с ссылочным типом
        // Для этого перед типом аргумента добавляется модификатор ref
        static void ModifyNumberRef(ref int num)
        {
            num *= 10;
            Console.WriteLine($"num inside method: {num}");
        }

        int num2 = 1;
        ModifyNumberRef(ref num2);
        Console.WriteLine($"num2 outside method: {num2}");
        // Выходные параметры
        // При указании выходного параметра функция ДОЛЖНА вернуть его в любом случае; в таком случае результирующий параметр можно не инициализировать
        // Для этого перед типом аргумента добавляется модификатор out
        static int ModifyNumberOut(int num, out int res)
        {
            num *= 10;
            res = num;
            return res;
        }

        int num3 = 1;
        ModifyNumberOut(num3, out int res);
        Console.WriteLine($"res modify method out = {res}");
        // Только для чтения
        // При указании такого модификатора нельзя менять переданный аргумент, можно его только читать
        // Для этого перед указанием аргумента добавляется модификатор in
        static void NotModifyNumber(in int num)
        {
            if (num > 10)
            {
                Console.WriteLine("num is greater than 10");
            }
            else
            {
                Console.WriteLine("num is less than 10");
            }
        }

        int num4 = 5;
        NotModifyNumber(num4);
        // Массив через params
        // Позволяет "упаковать" все переданные параметры одного типа в массив
        static void ParamsMethod(params int[] nums)
        {
            if (nums.Length == 0)
            {
                Console.WriteLine("nums are empty");
            }
            else
            {
                foreach (int num in nums)
                {
                    Console.WriteLine(num);
                }
            }
        }
        ParamsMethod(1, 2, 3, 4, 5);
        // Необязательные параметры
        // Такие параметры имеют значение по умолчанию, которое подставляется ели не указано иное
        static void DefaultParams(string name = "Alice", int age = 20)
        {
            Console.WriteLine($"name: {name}, age: {age}");
        }
        DefaultParams();
        DefaultParams("Bob");
        DefaultParams("Clare", 25);
        
        
        
        // ВОЗВРАЩАЕМЫЙ РЕЗУЛЬТАТ
        // void - метод ничего не возвращает
        // int, string, bool, ... - метод возвращает значение любого стандартного типа
        // (int intRes, string strRes) - кортеж, т.е. метод возвращает последовательность результатов
        static (int age, string name) PersonCheck(int num)
        {
            switch (num)
            {
                case 1:
                    return (1, "Alice");
                case 2:
                    return (2, "Bob");
                case 3:
                    return (3, "Clare");
                default:
                    return (0, "");
            }
        }
        (int age, string name) person = PersonCheck(1);
        Console.WriteLine($"person age: {person.age}, person name: {person.name}");
        
        
        
        // ПЕРЕГРУЗКА МЕТОДОВ
        // Можно создавать методы с одинаковым названием, но с разными сигнатурами аргументов, тогда компилятор сам поймёт какой метод использовать
        // public static int Addition(int a, int b) => a + b;
        // public static double Addition(double a, double b) => a + b;
        // public static int Addition(int a, int b, int c) => a + b + c;
        
        
        
        // РЕКУРСИВНЫЕ МЕТОДЫ
        // Методы могут вызывать сами себя. Это используется для рекурсивных вычислений, однако их применение не рекомендуется из-за вероятности переполнения стека
        static int Factorial(int num)
        {
            if (num <= 0) return 1;
            return num * Factorial(num - 1);
        }
        int factRes = Factorial(5);
    }
}