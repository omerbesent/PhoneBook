using PhoneBook.Business.Concrete;
using PhoneBook.DataAccess.Concrete.EntityFramework;
using PhoneBook.Entities.Concrete;

namespace PhoneBook.Test
{
    public class ContactInformationUnitTest
    {
        [Fact]
        public void ContactInformationAdd()
        {
            var contactInformationManager = new ContactInformationManager(new EfContactInformationDal());

            var contactInformation = new ContactInformation
            {
                PersonUUID = 2,
                Phone = "TestPhone",
                Email = "TestEmail",
                Location = "TestLocation"
            };

            var result = contactInformationManager.Add(contactInformation);

            Assert.True(result.Success);
        }

        [Fact]
        public void ContactInformationDelete()
        {
            var contactInformationManager = new ContactInformationManager(new EfContactInformationDal());

            var contactInformationId = 1;

            var result = contactInformationManager.Delete(contactInformationId);

            Assert.True(result.Success);
        }
    }
}