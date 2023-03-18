using PhoneBook.Core.Entities;

namespace PhoneBook.Entities.Concrete.Dto
{
    public class LocationReportDto : IDto
    {
        public string Location { get; set; }
        public int PhoneCount { get; set; }
        public int PersonCount { get; set; }
    }
}
