
namespace MyEntityFramework
{
    // ENTITY FRAMEWORK
    // Entity Framework - это объектно-реляционный маппер (ORM) для .NET
    // Он позволяет работать с базой данных, используя объекты C#, без написания большого количества SQL-кода
    // Основные задачи:
    // - Преобразование объектов C# в записи БД и обратно
    // - Управление подключением к БД
    // - Генерация SQL-запросов
    // - Отслеживание изменений объектов
    // Подходы к работе:
    // - Code First — создание классов сущностей в коде, на основе которых генерируется БД (наиболее популярен)
    // - Database First — генерация классов сущностей из существующей БД
    // - Model First — проектирование модели в дизайнере EF с последующей генерацией БД и классов



    // СОЗДАНИЕ МОДЕЛЕЙ (СУЩНОСТЕЙ)
    public class EntitiesExample
    {
        public class User
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
    
            // Навигационное свойство (связь 1 ко многим)
            public List<Book> Books { get; set; } = new List<Book>();
        }

        public class Book
        {
            public int Id { get; set; }
            public string Title { get; set; }
    
            // Внешний ключ
            public int UserId { get; set; }
            // Навигационное свойство (обратная связь)
            public User User { get; set; }
        }
    }
    
    
    
    // СОЗДАНИЕ КОНТЕКСТА ДАННЫХ (DBCONTEXT)
    public class ContextExample
    {
        using Microsoft.EntityFrameworkCore;

        public class AppDbContext : DbContext
        {
            // Коллекции сущностей (таблицы в БД)
            public DbSet<User> Users { get; set; }
            public DbSet<Book> Books { get; set; }

            // Настройка подключения к БД
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=MyAppDb;Trusted_Connection=True;");
            }

            // Настройка моделей и связей
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                // Настройка связи User -> Books (1 ко многим)
                modelBuilder.Entity<User>()
                    .HasMany(u => u.Books)
                    .WithOne(b => b.User)
                    .HasForeignKey(b => b.UserId);
            }
        }
    }



    // ДОБАВЛЕНИЕ ДАННЫХ
    public class AddExample
    {
        using (var context = new AppDbContext())
        {
            var user = new User { Name = "Alice", Age = 30 };
            context.Users.Add(user);
            context.SaveChanges(); // Сохраняет изменения в БД
        }
    }
    
    
    
    // ЧТЕНИЕ ДАННЫХ
    public class ReadExample
    {
        using (var context = new AppDbContext())
        {
            // Получить всех пользователей
            var allUsers = context.Users.ToList();
        
            // Получить пользователя по ID
            var user = context.Users.Find(1);
        
            // Фильтрация и включение связанных данных
            var usersWithBooks = context.Users
                .Where(u => u.Age > 25)
                .Include(u => u.Books) // Жадно загружает книги
                .ToList();
        }
    }
    
    
    
    // ОБНОВЛЕНИЕ ДАННЫХ
    public class UpdateExample
    {
        using (var context = new AppDbContext())
        {
            var user = context.Users.Find(1);
            user.Name = "Bob";
            context.SaveChanges();
        }
    }
    
    
    
    // УДАЛЕНИЕ ДАННЫХ
    public class DeleteExample
    {
        using (var context = new AppDbContext())
        {
            var user = context.Users.Find(1);
            context.Users.Remove(user);
            context.SaveChanges();
        }
    }
    
    
    
    // АСИНХРОННАЯ РАБОТА
    public class AsyncExample
    {
        public async Task<User> GetUserAsync(int id)
        {
            using (var context = new AppDbContext())
            {
                return await context.Users
                    .Include(u => u.Books)
                    .FirstOrDefaultAsync(u => u.Id == id);
            }
        }

        public async Task AddUserAsync(User user)
        {
            using (var context = new AppDbContext())
            {
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();
            }
        }
    }
}