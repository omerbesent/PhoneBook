using PhoneBook.WebApp.Models.ServiceModel;

namespace PhoneBook.WebApp.Services.Abstact
{
    public interface IReportService
    {
        bool RequestReport();
        ResponseDataModel<List<Report>> GetAll();
        byte[] ReportDownload(int reportId);
    }
}
