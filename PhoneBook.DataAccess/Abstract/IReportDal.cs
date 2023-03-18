using PhoneBook.Core.DataAccess;
using PhoneBook.Entities.Concrete;

namespace PhoneBook.DataAccess.Abstract
{
    public interface IReportDal : IEntityRepository<Report>
    {
        Report CustomAdd(Report report);
    }
}
