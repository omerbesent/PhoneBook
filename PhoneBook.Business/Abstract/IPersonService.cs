using PhoneBook.Core.Utilities.Results;
using PhoneBook.Entities.Concrete;

namespace PhoneBook.Business.Abstract
{
    public interface IPersonService
    {
        IResult Add(Person person);
        IResult Delete(int personId);
        IDataResult<IList<Person>> GetList();
    }
}
