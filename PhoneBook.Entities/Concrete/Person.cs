using PhoneBook.Core.Entities;

namespace PhoneBook.Entities.Concrete
{
    public class Person : IEntity
    {
        public int UUID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
    }
}
