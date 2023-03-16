using Microsoft.EntityFrameworkCore;
using PhoneBook.Entities.Concrete;

namespace PhoneBook.DataAccess.Concrete.EntityFramework.Contexts
{
    public class PhoneBookContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=PhoneBook;Username=postgres;Password=123456a.A");
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<ContactInformation> ContactInformations { get; set; }
    }
}
