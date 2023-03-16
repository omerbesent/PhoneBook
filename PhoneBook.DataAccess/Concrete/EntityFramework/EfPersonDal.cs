using PhoneBook.Core.DataAccess.EntityFramework;
using PhoneBook.DataAccess.Abstract;
using PhoneBook.DataAccess.Concrete.EntityFramework.Contexts;
using PhoneBook.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.DataAccess.Concrete.EntityFramework
{
    public class EfPersonDal : EfEntityRepositoryBase<Person, PhoneBookContext>, IPersonDal
    {
    }
}
