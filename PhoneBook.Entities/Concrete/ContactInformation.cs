using PhoneBook.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Entities.Concrete
{
    public class ContactInformation : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int PersonUUID { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Location { get; set; } 
    }
}
