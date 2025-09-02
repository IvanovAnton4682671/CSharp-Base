
// УСЛОВНЫЕ КОНСТРУКЦИИ
// Есть 3 условные конструкции: if-else, тернарный оператор, switch



// IF-ELSE
// Обычный if
// if (condition) {...} - фундаментальный оператор, выполняет блок кода внутри {...}, если условие condition == true
int a = 1;
if (a > 2)
{
    Console.WriteLine(a);
}
// Конструкция if-else
// if (condition) {...} else {...} - если условие condition == false, то выполняется блок else
int b = 2;
if (b > 10)
{
    Console.WriteLine("b > 10");
}
else
{
    Console.WriteLine("b <= 10");
}
// Конструкция if-else if-else
// if (condition1) {...} else if (condition2) {...} ... else if (conditionN) {...} else {...} - позволяет реализовать систему с множеством услоий
int c = 3;
if (c == 0)
{
    Console.WriteLine("c == 0");
}
else if (c < 10)
{
    Console.WriteLine("c < 10");
}
else
{
    Console.WriteLine("c > 10");
}
// ВАЖНО: нужно располагать более специфичные условия выше более общих, иначе выполнение просто не попадёт в более узкий случай
int d = 50;
if (d > 10)
{
    Console.WriteLine("d > 10");
}
else if (d > 40) // Выполнение никогда не попадёт в этот блок, потому что если d > 40, то оно автоматически > 10 и перехватится верхним условием
{
    Console.WriteLine("d > 40");
}
else
{
    Console.WriteLine("d < 40");
}



// ТЕРНАРНЫЙ ОПЕРАТОР
// Простой однострочный аналог if-else
// Синтаксис: condition ? expression_if_true : expression_if_false
int a1 = 10;
bool res1 = a1 > 10 ? true : false; // res1 = false поскольку 10 == 10
// ВАЖНО: тернарный оператор в обоих случаях должен возвращать значение, причём такое, которое поддерживается типом результирующей переменной



// SWITCH
// Используется когда одно выражение нужно сравнивать с большим количеством значений, что проще чем цепочке if-else
// switch (condition) {case 1: ..., case 2: ..., ..., default: ...} - сравнивает condition со значениями case
// Т.е. проверяет condition == 1, condition == 2, ..., и выполняет соответствующий код
int a2 = 3;
switch (a2)
{
    case 1: // Проверяется a2 == 1
        Console.WriteLine("a1 = 1");
        break; // Должен быть для выхода из case
    case 2:
        Console.WriteLine("a2 = 2");
        break;
    case 3:
        Console.WriteLine("a3 = 3");
        break;
    default: // Выполняется, если ни один case не подошёл
        Console.WriteLine("undefined");
        break;
}
// Условия case можно объединять
int b2 = 6;
switch (b2)
{
    // Для условий b2 == 2, b2 == 4, b2 == 6 выполняется одинаковый код
    case 2:
    case 4:
    case 6:
        Console.WriteLine("b2 чётное");
        break;
    case 1:
    case 3:
    case 5:
        Console.WriteLine("b2 нечётное");
        break;
    default: //default может быть пустой
        break;
}
// Можно выполнять проверки на тип
object c2 = 10;
switch (c2)
{
    case int i:
        Console.WriteLine("c2 is integer");
        break;
    case string s:
        Console.WriteLine("c2 is string");
        break;
    case null:
        Console.WriteLine("c2 is null");
        break;
    default:
        Console.WriteLine("c2 is undefined");
        break;
}
// Можно добавлять условия в проверки
int d2 = 10;
switch (d2)
{
    case int i when i % 2 == 0:
        Console.WriteLine("d2 чётное");
        break;
    case int i when i % 2 != 0:
        Console.WriteLine("d2 нечётное");
        break;
    default:
        break;
}
// Можно использовать как выражение с возвратом значения
int? e2 = 3;
string e2Res = e2 switch
{
    1 => "1",
    2 => "2",
    3 => "3",
    4 or 5 => "4 or 5",                  // Можно объединять условия
    > 5 and < 7 => "6",                  // Можно усложнять логику
    int and >= 7 and <= 8 => "7 or 8",   // Можно объединять с проверками на тип
    _ => "null"                          // _ аналог default
};