using PhoneBook.Core.DataAccess;
using PhoneBook.Entities.Concrete;

namespace PhoneBook.DataAccess.Abstract
{
    public interface IPersonDal : IEntityRepository<Person>
    {
    }
}
