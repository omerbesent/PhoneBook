namespace PhoneBook.WebApp.Models.ServiceModel
{
    public class ResponseDataModel<T>: ResponseModel
    {
        public T Data { get; set; }
    }
}
