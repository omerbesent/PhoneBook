using PhoneBook.Core.DataAccess.EntityFramework;
using PhoneBook.DataAccess.Abstract;
using PhoneBook.DataAccess.Concrete.EntityFramework.Contexts;
using PhoneBook.Entities.Concrete;

namespace PhoneBook.DataAccess.Concrete.EntityFramework
{
    public class EfContactInformationDal : EfEntityRepositoryBase<ContactInformation, PhoneBookContext>, IContactInformationDal
    {
    }
}
