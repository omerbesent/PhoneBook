using PhoneBook.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Entities.Concrete
{
    public class Person : IEntity
    {
        [Key]
        public int UUID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
    }
}
