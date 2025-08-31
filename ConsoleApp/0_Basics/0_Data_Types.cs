
// ТИПЫ ДАННЫХ
// Есть 2 типа дынных: значимые и ссылочные



// ЗНАЧИМЫЕ ТИПЫ (Value Types)
// Что это? Переменные этих типов содержат свои данные напрямую. Когда ты присваиваешь одну value-type переменную другой, копируется значение
// Где хранятся? Они хранятся в области памяти под названием стек (stack). Работа со стеком очень быстрая
// Поведение? При присваивании копируются все данные
// К ним относятся такие типы как: числовые (со знаком, без знака, с плавающей запятой), логический, символьный, кортеж, перечисление, структура

// 1. Целые числа (со знаком)
sbyte sbVar = 120;        // 1 байт (-128 до 127)
short shVar = 10000;      // 2 байта (-32,768 до 32,767)
int iVar = 1000000;       // 4 байта (-2,1 млрд до 2.1 млрд)
long lVar = 1000000000;   // 8 байт (очень много)

// 2. Целые числа (без знака)
byte bVar = 250;            // 1 байт (0 до 255)
ushort ushVar = 50000;      // 2 байта (0 до 65,535)
uint uiVar = 4000000;       // 4 байта (0 до 4.2 млрд)
ulong ulVar = 1000000000;   // 8 байт (0 до очень большое число)

// 3. Числа с плавающей точкой (для дробных чисел)
float  fVar = 3.14F;     // 4 байта (~6-9 знаков), суффикс 'F'
double dVar = 3.1415;    // 8 байта (~15-17 знаков)
decimal dmVar = 3.14M;   // 16 байт (для финансовых расчетов, высокая точность), суффикс 'M'

// 4. Логический тип (только true и false)
bool isAlive = true;      // Истина
bool isEnabled = false;   // Ложь

// 5. Символьный тип
char symbol = 'a';     // 2 байта (хранит один символ Unicode в одинарных кавычках)
char newLine = '\n';   // Управляющая последовательность для новой строки

// 6. Кортеж
// Представляет собой неизменяемую последовательность
// Все функции возвращают значения в виде кортежей, но об этом позже
(int, string) person = (20, "Alice");                                 // Неименованный кортеж
Console.WriteLine($"person item1={person.Item1}, person item 2={person.Item2}");
(int age, string name) namedPerson = (20, "Alice");                   // Именованный кортеж
Console.WriteLine($"namedPerson age={namedPerson.age}, namedPerson name={namedPerson.name}");

// 7. Перечисление
// Позволяет хранить некоторую последовательность данных
enum Weekday { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday };   // Без заданного базового типа
Weekday today = Weekday.Monday;
Console.WriteLine($"today={today}");
Console.WriteLine($"int today={(int)today}");
enum ErrorCode : ushort { None = 0, NotFound = 404, InternalError = 500 };         // С заданным базовым типом
ErrorCode notFound = ErrorCode.NotFound;
Console.WriteLine($"notFound={notFound}");
Console.WriteLine($"ushort notFound={(ushort)notFound}");

// 8. Структура
// Очень похода на класс, но является значимым типом
// Рекомендуется использовать когда нужно часто создавать и удалять небольшие переменные (класс будет работать дольше)
public struct Point
{
    // Поля структуры
    public int X;
    public int Y;

    // Конструктор структуры
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    // Метод структуры
    public void Print()
    {
        Console.WriteLine($"X={X}, Y={Y}");
    }
}
Point p1 =  new Point(1, 2);   //создание экземпляра структуры с аргументами для конструктора
Point p2 = p1;
p2.X = 10;
p1.Print();
p2.Print();

// Поведение
// При присваивании значение копируется
int a = 10;
int b = a;
Console.WriteLine($"a={a}, b={b}");
b = 20;
Console.WriteLine($"a={a}, b={b}");



// ССЫЛОЧНЫЕ ТИПЫ (Reference Types)
// Что это? Переменные этих типов не содержат данные напрямую, а содержат ссылку (адрес в памяти) на область, где эти данные хранятся
// Где хранятся? Данные (объекты) хранятся в области памяти под названием куча (heap). Сама переменная (ссылка) хранится в стеке
// Поведение? При присваивании копируется только ссылка на исходный объект
// К ним относятся такие типы как: объект, строка, динамический, массив, коллекции, record, класс, интерфейс, делегат

// 1. Объект
// Для объекта существуют такие понятия как Упаковка (Boxing) и Распаковка (Unboxing)
// Упаковка - процесс преобразования значимого типа в ссылочный object
// Распаковка - процесс преобразования ссылочного object обратно в значимый тип
object obj1 = "I am a string";   // Строка просто присваивается переменной object
object obj2 = 10;                // Упаковка
int obj3 = (int)obj2;            //Распаковка
Console.WriteLine($"obj1 type={obj1.GetType()}, obj2 type={obj2.GetType()}, obj3 type={obj3.GetType()}");

// 2. Строки
// У строк особое поведение: стандартное поведение когда несколько переменных ссылаются на одно значение
// Но при изменении значения одной из переменных создаётся новая строка
string alice = "Alice";
string alice2 = alice;
string alice3 = alice;
alice3 = "Alice3";
Console.WriteLine($"alice={alice}, alice2={alice2}, alice3={alice3}");

// 3. Динамический тип
// На этапе компиляции проверка типов пропускается, выполняется только во время выполнения. Не рекомендуется использовать
dynamic dynVar = "string";
Console.WriteLine($"dynVar type = {dynVar.GetType()}, dynVar={dynVar}");
dynVar = 10;
Console.WriteLine($"dynVar type={dynVar.GetType()}, dynVar={dynVar}");

// 4. Массивы
int[] intArray = [1, 2, 3, 4, 5];
string[] strArray = ["Alice", "Bob", "Clare"];

// 5. Коллекции
List<int> list = new List<int>() {1, 2, 3};                                                  // Список (последовательность)
Dictionary<string, int> dict = new Dictionary<string, int>() {{"Alice", 20}, {"Bob", 25}};   // Словарь (пары ключ-значение)
Queue<int> queue = new Queue<int>(list);                                                     // Очередь (первый пришёл - первый ушёл (FIFO))
Stack<int> stack = new Stack<int>(list);                                                     // Стек (первый пришёл - последний ушёл (LIFO))
HashSet<int> set = new HashSet<int>() {1, 2, 3};                                             // Множество (только уникальные элементы)

// 6. Record
// Неизменяемый ссылочный тип
public record Person(int Age, string Name);
Person person1 =  new Person(20, "Alice");
Person person2 = new Person(25, "Bob");

// 7. Класс
// Как структура, но ссылочный тип. Рекомендуется применять везде
public class Point2
{
    // Поля класса
    public int X;
    public int Y;

    // Конструктор класса
    public Point2(int x, int y)
    {
        X = x;
        Y = y;
    }

    // Метод класса
    public void Print()
    {
        Console.WriteLine($"X={X}, Y={Y}");
    }
}
Point2 p1 = new Point2(1, 2);
Point2 p2 = p1;
p2.Y = 10;
p1.Print();
p2.Print();

// 8. Интерфейс
public interface IPoint2
{
    void Print(string message);
}

// 9. Делегат
// Делегат - это переменная, которая является функцией
// Сигнатура - возвращаемый тип + принимаемые аргументы
public delegate void PrintHandler(string message);        // Объявление делегата
public void PrintMessage(string message)                  // Какая-то функция с сигнатурой как у делегата
{
    Console.WriteLine(message);
}
PrintHandler delegat1 = new PrintHandler(PrintMessage);   // Создание делегата
delegat1("Hello");                                // Вызов делегата



// ПСЕВДОНИМЫ ТИПОВ
// Псевдоним - это другое название, которое упрощает использование стандартного
// Например: string - псевдоним для System.String, int - для System.Int32
string str1 = "Hello";
System.String str2 = "World";
int int1 = 120;
System.Int32 int2 = 120;



// КЛЮЧЕВЫЕ СЛОВА
// 1. var
// var позволяет компилятору самому определить тип на этапе компиляции
int int3 = 150;
var int4 = 200;         // Компилятор сам определит тип
var str3 = "string4";   // Компилятор понимает по правой части что это строка

// 2. null
// null - значение по умолчанию для ссылочных типов
string s1 = null;
Console.WriteLine($"s1={s1}");
// Значимые типы обычно не могут быть null, но могут принимать такое значение с помощью суффикса ?
// int i = null; - ошибка
int? i = null;
Console.WriteLine($"i={i}");