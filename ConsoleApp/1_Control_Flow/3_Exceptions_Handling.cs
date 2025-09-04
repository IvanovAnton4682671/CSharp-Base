
// ОБРАБОТКА ИСКЛЮЧЕНИЙ



// Тестовый класс для работы с исключениями
public class ExceptionHandling
{
    static void Main()
    {
        // БЛОК TRY-CATCH-FINALLY
        // Синтаксис:
        // try
        // {...}         - код, который может вызвать исключение, "опасное" место
        // catch (...)   - какую ошибку обрабатываем
        // {...}         - как обрабатываем
        // finally
        // {...}         - что делаем в любом случае (даже если появилась ошибка)
        try
        {
            int[] intArray = new int[] { 1, 2, 3, 4, 5 };
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(intArray[i]);
            }
        }
        catch (IndexOutOfRangeException e)
        {
            Console.WriteLine($"index out of range exception: {e.Message}");
        }
        finally
        {
            Console.WriteLine("Finally");
        }

        // Можно обрабатывать разные типы исключений
        // ВАЖНО: более общие обработки следует ставить последними, а более частные - первыми, иначе какой-нибудь (Exception e) будет перехватывать всё
        try
        {
            int[] intArray = new int[] { 1, 2, 3, 4, 5 };
            Console.WriteLine(intArray[5]);
            object obj = null;
            Console.WriteLine(obj.ToString());
        }
        catch (IndexOutOfRangeException e)
        {
            Console.WriteLine($"index out of range exception: {e.Message}");
        }
        catch (NullReferenceException e)
        {
            Console.WriteLine($"null reference exception: {e.Message}");
        }

        // Можно фильтровать исключения
        try
        {
            int a = 0;
        }
        catch (Exception e) when (e.Message.Contains("специфическая ошибка"))
        {
            Console.WriteLine("Специфическая ошибка");
        }
        catch (Exception e) when (DateTime.Now.Hour < 12)
        {
            Console.WriteLine("Ошибка произошла в первой половине дня");
        }



        // КОНСТРУКЦИЯ USING
        // Для объектов, реализующих интерфейс IDisposable, есть упрощённая конструкция:
        // using (ResourceType resource = new ResourceType)
        // {...}
        using (FileStream file = File.Open("test.txt", FileMode.Open))
        {
            // Работа с файлом file
            // Когда код закончится и произойдёт выход из using, компилятор сам очистит ресурсы
        }



        // ВЫБРАСЫВАНИЕ ИСКЛЮЧЕНИЙ
        // throw
        try
        {
            // Код
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw; // Выбрасывание оригинального исключения с оригинальным stack trace
        }

        // throw e;
        try
        {
            // Код
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw e; // Так делать не рекомендуется, поскольку теряется оригинальная информация об ошибке
        }

        // Обёртывание исключения
        try
        {
            // Код
        }
        catch (Exception e)
        {
            throw new Exception("Ошибка при обработке кода", e);
        }



        // ПОЛЬЗОВАТЕЛЬСКИЕ ИСКЛЮЧЕНИЯ
        // Можно создавать свои особенные исключения, если пронаследоваться от обычных исключений
        public class InvalidAgeException : ArgumentException
        {
            public InvalidAgeException() : base("Возраст должен быть между 0 и 120") { }
    
            public InvalidAgeException(string message) : base(message) { }
    
            public InvalidAgeException(string message, Exception innerException) : base(message, innerException) { }
        }
        try
        {
            int age = -5;
            if (age < 0 || age > 120) throw new InvalidAgeException();
        }
        catch (ExceptionHandling.InvalidAgeException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}