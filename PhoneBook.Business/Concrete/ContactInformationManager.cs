using PhoneBook.Business.Abstract;
using PhoneBook.Core.Utilities.Results;
using PhoneBook.DataAccess.Abstract;
using PhoneBook.Entities.Concrete;

namespace PhoneBook.Business.Concrete
{
    public class ContactInformationManager : IContactInformationService
    {
        private readonly IContactInformationDal _contactInformationDal;

        public ContactInformationManager(IContactInformationDal contactInformationDal)
        {
            _contactInformationDal = contactInformationDal;
        }

        public IResult Add(ContactInformation contactInformation)
        {
            _contactInformationDal.Add(contactInformation);
            return new SuccessResult("İletişim bilgisi oluşturuldu");
        }

        public IResult Delete(int contactInformationId)
        {
            var contactInformation = _contactInformationDal.Get(x => x.Id == contactInformationId);
            _contactInformationDal.Delete(contactInformation);
            return new SuccessResult("İletişim bilgisi silindi");
        }

        public IDataResult<IList<ContactInformation>> GetListByPersonId(int personId)
        {
            var contactInformations = _contactInformationDal.GetList(x => x.PersonUUID == personId);
            return new SuccessDataResult<IList<ContactInformation>>(contactInformations, "İletişim bilgileri listelendi");
        }
    }
}
