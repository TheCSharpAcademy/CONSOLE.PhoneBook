using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PhoneBook.Models;

namespace PhoneBook
{ 
    public class DataContext: DbContext
    {
        static IConfiguration configuration = (new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build());
        public static string connectionString = configuration["ConnectionString"].ToString();

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(connectionString);
            // options.LogTo(Console.WriteLine);
        }
    }
}
