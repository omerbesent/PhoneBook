﻿using PhoneBook.Core.DataAccess.EntityFramework;
using PhoneBook.DataAccess.Abstract;
using PhoneBook.DataAccess.Concrete.EntityFramework.Contexts;
using PhoneBook.Entities.Concrete;

namespace PhoneBook.DataAccess.Concrete.EntityFramework
{
    public class EfPersonDal : EfEntityRepositoryBase<Person, PhoneBookContext>, IPersonDal
    {
    }
}
