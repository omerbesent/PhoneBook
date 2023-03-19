using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using PhoneBook.Entities.Concrete;

namespace PhoneBook.DataAccess.Concrete.EntityFramework.Contexts
{
    public class PhoneBookContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            JToken jAppSettings = JToken.Parse(
             File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "../PhoneBook.WebAPI/appsettings.json")));
            string connectionString = jAppSettings["ConnectionStrings"]["PhoneBookConnection"].ToString();

            optionsBuilder.UseNpgsql(connectionString);
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<ContactInformation> ContactInformations { get; set; }
        public DbSet<Report> Reports { get; set; }
    }
}
