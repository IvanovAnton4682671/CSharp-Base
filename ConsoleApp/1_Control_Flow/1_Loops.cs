
// ЦИКЛЫ
// Есть 4 цикла: while, do-while, for, foreach



// WHILE
// Синтаксис: while (condition) {...} - пока выполняется условие condition будет выполняться и тело цикла {...}
int a = 0;
while (a < 10)
{
    Console.WriteLine(a);
    a++;
}

string userInput = "";
while (userInput != "q")
{
    Console.WriteLine("Please enter a number (or 'q' to exit))");
    userInput = Console.ReadLine();
    Console.WriteLine($"user input: {userInput}");
}



// DO-WHILE
// Синтаксис: do {...} while (condition) - гарантировано выполнит тело цикла 1 раз, а затем будет его выполнять пока условие истинно
int b = 0;
do
{
    Console.WriteLine(b); // Хоть и b == 0 и не выполняет условие while, блок do выполнится 1 раз
} while (b != 0);



// FOR
// Синтаксис: for (initialization; condition; iteration) - цикл с счётчиком, позволяет объединить инициализацию, условие и изменение счётчика в одной строке
for (int i = 0; i < 10; i++)    // Обычный счётчик
{
    Console.WriteLine(i);
}
for (int i = 10; i >= 10; i--)   // Обратный отсчёт
{
    Console.WriteLine(i);
}
// Можно работать с несколькими счётчиками
for (int i = 0, j = 0;  (i + j) <= 10; i++, j++)
{
    Console.WriteLine($"i+j={i + j}");
}



// FOREACH
// Синтаксис: foreach (type elem in collection) - перебирает элементы коллекции (безопаснее обычного for поскольку не может выйти за пределы индексов)
int[] intList = {1, 2, 3};
foreach (int i in intList)
{
    Console.WriteLine(i);
}
// ВАЖНО: в таком цикле нельзя изменить саму переменную elem (это копия для значимого типа и ссылка для ссылочного)
foreach (int i in intList)
{
    i += 1; // i даже подчёркивается красным, не даст скомпилировать код
}

public struct Person
{
    public string Name;

    public Person(string name)
    {
        Name = name;
    }
}

Person p = new Person("Alice");
List<Person> personList = new List<Person> {p};
foreach (Person p in personList)
{
    p.Name = "Bob"; // Однако для ссылочных типов можно менять свойства, поскольку ссылка не изменяется
}



// ОПЕРАТОРЫ УПРАВЛЕНИЯ ЦИКЛАМИ
// break - немедленно завершает выполнение тела цикла и передаёт управление следующей за циклом инструкции
for (int i = 0; i < 10; i++)
{
    Console.WriteLine(i);
    break; // 1 раз выведется i, затем цикл перестанет работать
}
// continue - немедленно завершает выполнение тела цикла и переходит к следующей итерации цикла
for (int i = 0; i < 10; i++)
{
    Console.WriteLine($"вывели i 1 раз");
    continue;
    Console.WriteLine($"вывели i 2 раз"); // Не выполнится, поскольку после первого вывода начнётся следующая итерация
}



// ВАЖНО: циклы могут быть вложенными и бесконечными, так что нужно с ними работать внимательно