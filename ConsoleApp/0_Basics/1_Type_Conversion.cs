
// ПРЕОБРАЗОВАНИЕ ТИПОВ
// Есть 4 типа преобразования: неявное, явное, с помощью вспомогательных классов и методов, пользовательское



// НЕЯВНОЕ ПРЕОБРАЗОВАНИЕ
// Что это? Автоматическое преобразование, которое компилятор C# выполняет безопасно самостоятельно, без какого-либо специального синтаксиса со стороны программиста
// Когда возможно?
//   - Когда преобразование является безопасным, то есть не приводит к потере данных
//   - Когда существует встроенная поддержка такого преобразования в языке
int intVal = 10;                // Просто int
long longVal = intVal;          // Неявное приведение int к long, поскольку любой int поместится в long
double doubleVal = longVal;     // Неявное приведение long к double
float floatVal = 10.5F;         // Просто float
doubleVal = floatVal;           // Неявное приведение float к double
decimal decimalVal = longVal;   // Неявное приведение long к decimal
int? nullableIntVal = intVal;   //Неявное приведение int к int?



// ЯВНОЕ ПРЕОБРАЗОВАИЕ
// Что это? Преобразование, которое инициируется программистом с помощью оператора приведения — указания целевого типа в круглых скобках перед преобразуемым значением
// Когда возможно?
//   - Когда преобразование небезопасно и может привести к потере данных
//   - Когда компилятор не может самостоятельно гарантировать успешность преобразования
double doubleVal2 = 123.456;          // Просто double
int intVal2 = (int)doubleVal2;        // Явное приведение double к int (часть после запятой удалилась)
long longVal2 = 1_000_000_000;        // Просто long (да, _ можно визуально разделять значение)
int intVal3 = (int)longVal2;          // Явное приведение long к int (поместилось)
int? nullableIntVal2 = 777;           // Просто nullable int
int intVal4 = (int)nullableIntVal2;   // Явное приведение nullable int к int



// ПРЕОБРАЗОВАНИЕ С ПОМОЩЬЮ ВСПОМОГАТЕЛЬНЫХ КЛАССОВ И МЕТОДОВ
// Что это? Преобразование, выполняемое через применение определённых методов конкретных классов
// Когда возможно?
//   - Когда используемый класс предоставляет нужный метод с поддерживаемым типом
//   - Когда обычное преобразование по каким-то причинам невозможно
string strVal = "123";                                         // Просто string
int intVal5 = Convert.ToInt32(strVal);                         //Конвертирование с использованием класса Convert, поддерживает все базовые типы
double doubleVal6 = Convert.ToDouble("123.456");               // Аналогичное конвертирование
object nullObj = null;                                         // Просто object null
int intFromNull = Convert.ToInt32(nullObj);                    // Для null будет 0
string strVal2 = "123";                                        // Просто string
int intFromStr2 = int.Parse(strVal2);                          // Метод преобразование в int
string strVal3 = "123abc";                                     // Просто string
// int intFromStr3 = int.Parse(strVal3);                       // Ошибка, поскольку есть буквы
bool isSuccess = int.TryParse(strVal3, out int intFromStr3);   // Не ошибка, а отрицательный статус isSuccess



// ПОЛЬЗОВАТЕЛЬСКОЕ ПРЕОБРАЗОВАНИЕ
// Что это? Программист может определить правила явного или неявного преобразования для своих собственных классов (class) или структур (struct)
// Когда возможно? Всегда
// Как это делается?
// Внутри класса/структуры объявляется специальный метод с использованием ключевых слов implicit operator (для неявного) или explicit operator (для явного преобразования)
public class Celsius
{
    public double Degrees { get; }
    public Celsius(double degrees) { Degrees = degrees; }

    // Пользовательское НЕЯВНОЕ преобразование из double в Celsius
    public static implicit operator Celsius(double d)
    {
        return new Celsius(d);
    }

    // Пользовательское ЯВНОЕ преобразование из Celsius в Fahrenheit
    public static explicit operator Fahrenheit(Celsius c)
    {
        return new Fahrenheit((9.0 / 5.0) * c.Degrees + 32);
    }
}
public class Fahrenheit
{
    public double Degrees { get; }
    public Fahrenheit(double degrees) { Degrees = degrees; }
}
// Использование пользовательских преобразований
Celsius celsius = 25.0;               // Неявное преобразование double -> Celsius (работает автоматически)
Console.WriteLine(celsius.Degrees);      // 25
//Fahrenheit fahr = celsius;             // Ошибка компиляции! Нет неявного преобразования
Fahrenheit fahr = (Fahrenheit)celsius;   // Явное преобразование Celsius в Fahrenheit
Console.WriteLine(fahr.Degrees);         // 77