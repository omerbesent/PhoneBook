namespace PhoneBook.WebApp.Models.ServiceModel
{
    public class Report
    {
        public int UUID { get; set; }
        public DateTime ReportCreatedDate { get; set; }
        public string ReportStatus { get; set; }
        public string ReportPath { get; set; }
    }
}
