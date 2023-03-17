using PhoneBook.WebApp.Models;
using PhoneBook.WebApp.Models.ServiceModel;

namespace PhoneBook.WebApp.Services.Abstact
{
    public interface IPersonService
    {
        ResponseModel Add(PersonViewModel personViewModel);
        ResponseDataModel<List<Person>> GetAll();
        void Delete(int personId);
    }
}
