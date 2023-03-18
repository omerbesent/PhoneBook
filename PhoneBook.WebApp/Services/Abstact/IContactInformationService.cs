using PhoneBook.WebApp.Models.ServiceModel;
using PhoneBook.WebApp.Models;

namespace PhoneBook.WebApp.Services.Abstact
{
    public interface IContactInformationService
    {
        ResponseModel Add(ContactInformationViewModel contactInformationViewModel);
        ResponseDataModel<List<ContactInformation>> GetAllByPersonId(int personId);
        ResponseModel Delete(int contactInformationId);
    }
}
