using PhoneBook.Core.Utilities.Results;
using PhoneBook.Entities.Concrete;

namespace PhoneBook.Business.Abstract
{
    public interface IReportService
    {
        Report Add(Report report);
        IResult Update(Report report);
        IDataResult<Report> GetById(int reportId);
        IDataResult<IList<Report>> GetAll();
    }
}
