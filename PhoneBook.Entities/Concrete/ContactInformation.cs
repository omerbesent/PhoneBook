using PhoneBook.Core.Entities;

namespace PhoneBook.Entities.Concrete
{
    public class ContactInformation : IEntity
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
    }
}
