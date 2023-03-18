using PhoneBook.Core.DataAccess;
using PhoneBook.Entities.Concrete;
using PhoneBook.Entities.Concrete.Dto;

namespace PhoneBook.DataAccess.Abstract
{
    public interface IPersonDal : IEntityRepository<Person>
    {
        IList<LocationReportDto> LocationReport();
    }
}
