using PhoneBook.Core.Utilities.Results;
using PhoneBook.Entities.Concrete;

namespace PhoneBook.Business.Abstract
{
    public interface IContactInformationService
    {
        IResult Add(ContactInformation contactInformation);
        IResult Delete(int contactInformationId);
        IDataResult<IList<ContactInformation>> GetListByPersonId(int personId);
    }
}
