
using System.Text;

namespace MyStringStringBuilder
{
    // СТРОКИ
    // Строка - ссылочный тип (System.String), представляющий неизменяемую (immutable) последовательность символов Unicode
    // Особенности:
    // - Любая операция, изменяющая строку (например, конкатенация), создает новый объект в куче
    // - Строки используют интернирование (пул строк): идентичные литералы могут ссылаться на один объект в памяти
    // - Для экранирования символов используются управляющие последовательности (\n, \t и т.д.)
    
    
    // СТРОКА
    public class MyString
    {
        // СОЗДАНИЕ СТРОК
        string s1 = "Hello";                          // Литерал
        string s2 = new string('a', 5);       // "aaaaa" (из символа)
        char[] chars = { 'w', 'o', 'r', 'l', 'd' };
        string s3 = new string(chars);                // "world" (из массива char)
        
        
        
        // ОПЕРАЦИИ СО СТРОКАМИ
        // Конкатенация (создает новую строку)
        string concat = s1 + " " + s3;                // "Hello world"
        // Интерполяция (удобный синтаксис)
        string interpolated = $"{s1} {s3}";           // "Hello world"
        // Форматирование
        string formatted = string.Format("{0} {1}", s1, s3); // "Hello world"
        // Поиск
        int index = s3.IndexOf('r');                   // 2
        bool contains = s3.Contains("or");             // true
        // Разделение и объединение
        string[] parts = "a,b,c".Split(',');           // Массив ["a", "b", "c"]
        string joined = string.Join("-", parts);       // "a-b-c"
        // Изменение регистра
        string upper = s1.ToUpper();                   // "HELLO"
        string lower = s1.ToLower();                   // "hello"
        // Подстроки
        string sub = s3.Substring(1, 3);               // "orl"
        // Замена
        string replaced = s3.Replace("world", "C#");   // "C#"
        // Обрезка пробелов
        string trimmed = "  text  ".Trim();            // "text"
        
        
        
        // ОСОБЕННОСТИ
        string path = @"C:\Users\File.txt"; // Не требует двойного обратного слеша
        string multiline = @"Line 1
        Line 2";
        bool isEmpty = string.IsNullOrEmpty(s);
        bool isWhiteSpace = string.IsNullOrWhiteSpace(s);
    }


    // STRINGBUILDER
    // StringBuilder - Класс System.Text.StringBuilder представляет изменяемую строку
    // Используется для частых операций изменения, чтобы избежать создания множества объектов
    // Особенности:
    // - Хранит символы во внутреннем массиве, который динамически расширяется
    // - Операции изменяют существующий объект, а не создают новый
    // - Экономит память и улучшает производительность при массовых операциях
    
    
    
    // STRINGBUILDER
    public class MyStringBuilder
    {
        // СОЗДАНИЕ И ИСПОЛЬЗОВАНИЕ
        // Создание с начальным значением и вместимостью
        var sb = new StringBuilder("Hello", 50); // Начальная вместимость = 50 символов
        // Добавление строк
        sb.Append(" world");                    // "Hello world"
        sb.AppendLine("!");                     // Добавляет строку с переводом "Hello world!\n"
        sb.Insert(5, " beautiful");             // "Hello beautiful world!"
        // Замена
        sb.Replace("world", "C#");              // "Hello beautiful C#!"
        // Удаление
        sb.Remove(5, 10);                       // "Hello C#!"
        // Очистка
        sb.Clear();                             // Очищает содержимое
        // Преобразование в string
        string result = sb.ToString();          // Явное преобразование
        
        
        
        // ВМЕСТИМОСТЬ
        var sb2 = new StringBuilder(100); // Указание вместимости заранее избегает частого копирования
        Console.WriteLine(sb2.Capacity);  // Текущая вместимость
        sb2.EnsureCapacity(200);          // Гарантирует минимальную вместимость
    }
}