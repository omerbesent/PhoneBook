using PhoneBook.Core.Utilities.Results;
using PhoneBook.Entities.Concrete;
using PhoneBook.Entities.Concrete.Dto;

namespace PhoneBook.Business.Abstract
{
    public interface IPersonService
    {
        IResult Add(Person person);
        IResult Delete(int personId);
        IDataResult<IList<Person>> GetList();
        IList<LocationReportDto> GetLocationReport();
    }
}
