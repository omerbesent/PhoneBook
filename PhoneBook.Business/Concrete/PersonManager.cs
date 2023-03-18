using PhoneBook.Business.Abstract;
using PhoneBook.Core.Utilities.Results;
using PhoneBook.DataAccess.Abstract;
using PhoneBook.Entities.Concrete;
using PhoneBook.Entities.Concrete.Dto;

namespace PhoneBook.Business.Concrete
{
    public class PersonManager : IPersonService
    {
        private readonly IPersonDal _personDal;

        public PersonManager(IPersonDal personDal)
        {
            _personDal = personDal;
        }

        public IResult Add(Person person)
        {
            _personDal.Add(person);
            return new SuccessResult("Kişi oluşturuldu");
        }

        public IResult Delete(int personId)
        {
            var person = _personDal.Get(x => x.UUID == personId);
            _personDal.Delete(person);
            return new SuccessResult("Kişi silindi");
        }

        public IDataResult<IList<Person>> GetList()
        {
            var persons = _personDal.GetList();
            return new SuccessDataResult<IList<Person>>(persons, "Kişiler listelendi");
        }

        public IList<LocationReportDto> GetLocationReport()
        {
            var report = _personDal.LocationReport();
            return report;
        }
    }
}
