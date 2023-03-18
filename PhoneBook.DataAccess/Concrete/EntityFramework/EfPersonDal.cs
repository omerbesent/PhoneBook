using PhoneBook.Core.DataAccess.EntityFramework;
using PhoneBook.DataAccess.Abstract;
using PhoneBook.DataAccess.Concrete.EntityFramework.Contexts;
using PhoneBook.Entities.Concrete;
using PhoneBook.Entities.Concrete.Dto;

namespace PhoneBook.DataAccess.Concrete.EntityFramework
{
    public class EfPersonDal : EfEntityRepositoryBase<Person, PhoneBookContext>, IPersonDal
    {
        public IList<LocationReportDto> LocationReport()
        {
            using (var context = new PhoneBookContext())
            {
                var result = from ci in context.ContactInformations
                             join p in context.Persons on ci.PersonUUID equals p.UUID
                             group ci by new { ci.Location } into ciGroup
                             select new LocationReportDto
                             {
                                 Location = ciGroup.FirstOrDefault().Location,
                                 PhoneCount = ciGroup.Count(),
                                 PersonCount = ciGroup.GroupBy(x => x.PersonUUID).Count()
                             };
                return result.ToList();
            }
        }
    }
}
