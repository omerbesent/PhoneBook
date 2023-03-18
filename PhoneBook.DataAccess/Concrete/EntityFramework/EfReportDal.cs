using Microsoft.EntityFrameworkCore;
using PhoneBook.Core.DataAccess.EntityFramework;
using PhoneBook.DataAccess.Abstract;
using PhoneBook.DataAccess.Concrete.EntityFramework.Contexts;
using PhoneBook.Entities.Concrete;

namespace PhoneBook.DataAccess.Concrete.EntityFramework
{
    public class EfReportDal : EfEntityRepositoryBase<Report, PhoneBookContext>, IReportDal
    {
        public Report CustomAdd(Report report)
        {
            using (var context = new PhoneBookContext())
            {
                var addedEntity = context.Entry(report);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
                return addedEntity.Entity;
            }
        }
    }
}
