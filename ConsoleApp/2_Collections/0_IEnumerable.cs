
using System.Collections;

// ИНТЕРФЕЙС ПЕРЕЧИСЛЯЕМОГО
// Структура интерфейса:
// public interface IEnumerable
// {
//     IEnumerator GetEnumerator();
// }
// public interface IEnumerable<out T> : IEnumerable
// {
//     IEnumerator<T> GetEnumerator();
// }
// IEnumerable предоставляет метод GetEnumerator(), который возвращает IEnumerator
// IEnumerator позволяет последовательно перебирать элементы коллекции
// Любая коллекция, реализующая IEnumerable, может использоваться в foreach



// ПРИМЕР РЕАЛИЗАЦИИ
public class SimpleCollection : IEnumerable<int>
{
    private int[] _data = { 1, 2, 3, 4, 5 };

    IEnumerator<int> IEnumerable<int>.GetEnumerator()
    {
        foreach (int item in _data)
        {
            yield return item;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerator GetEnumerator()
    {
        return GetEnumerator();
    }
}
// Использование
SimpleCollection collection = new SimpleCollection();
foreach (int item in collection)
{
    Console.WriteLine(item);
}



// КЛЮЧЕВОЕ СЛОВО YIELD
// Ключевое слово yield упрощает создание итераторов
IEnumerable<int> GetNumbers()
{
    yield return 1;
    yield return 2;
    yield return 3;
    yield return 4;
    yield return 5;
}
// Ленивое выполнение
foreach (int number in GetNumbers())
{
    Console.WriteLine(number);   // Выводит 1, 2, 3, 4, 5
}
static IEnumerable<int> GetNumbersUntil(int max)
{
    for (int i = 1; i <= int.MaxValue; i++)
    {
        if (i > max) yield break;
        yield return i;
    }
}



// МЕТОДЫ РАШИРЕНИЙ
// Многие методы LINQ являются расширяющими методами для IEnumerable<T>
public static class MyExtensions
{
    public static IEnumerable<T> Where<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        foreach (T item in source)
        {
            if (predicate(item))
                yield return item;
        }
    }
}



// ОТЛОЖЕННОЕ ВЫПОЛНЕНИЕ
// Важная особенность IEnumerable — отложенное выполнение запросов
var numbers = new List<int> { 1, 2, 3, 4, 5 };
var query = numbers.Where(n => n > 3);   // Запрос еще не выполнен
numbers.Add(6);   // Добавляем элемент после создания запроса
foreach (var number in query)   // Запрос выполняется здесь
{
    Console.WriteLine(number);   // 4, 5, 6
}