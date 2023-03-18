using PhoneBook.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Entities.Concrete
{
    public class Report : IEntity
    {
        [Key]
        public int UUID { get; set; }
        public DateTime ReportCreatedDate { get; set; }
        public string ReportStatus { get; set; }
        public string ReportPath { get; set; }
    }
}
