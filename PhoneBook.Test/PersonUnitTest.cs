using PhoneBook.Business.Concrete;
using PhoneBook.DataAccess.Concrete.EntityFramework;
using PhoneBook.Entities.Concrete;

namespace PhoneBook.Test
{
    public class PersonUnitTest
    {
        [Fact]
        public void PersonAdd()
        {
            var personManager = new PersonManager(new EfPersonDal());

            var person = new Person
            {
                Name = "TestName",
                LastName = "TestLastName",
                Company = "TestCompany"
            };

            var result = personManager.Add(person);

            Assert.True(result.Success);
        }

        [Fact]
        public void PersonDelete()
        {
            var personManager = new PersonManager(new EfPersonDal());

            var personId = 1;

            var result = personManager.Delete(personId);

            Assert.True(result.Success);
        }
    }
}