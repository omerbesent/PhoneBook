using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PhoneBook.WebApp.Models;
using PhoneBook.WebApp.Models.ServiceModel;
using PhoneBook.WebApp.Services.Abstact;
using System;
using System.Net.Http;
using System.Text;

namespace PhoneBook.WebApp.Services.Concrete
{
    public class PersonManager : IPersonService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        string apiUrl;
        public PersonManager(IConfiguration configuration)
        {
            _configuration = configuration;
            var webServiceUrl = _configuration.GetSection("WebServiceURL").Get<string>();
            apiUrl = $"{webServiceUrl}/Persons";

            _httpClient = HttpClientFactory.Create();
        }
        public ResponseModel Add(PersonViewModel personViewModel)
        {
            var result = new ResponseModel { Success = false };

            HttpContent body = new StringContent(JsonConvert.SerializeObject(personViewModel), Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = _httpClient.PostAsync($"{apiUrl}/Add", body).Result;
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonData = httpResponseMessage.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<ResponseModel>(jsonData);
            }
            return result;
        }

        public void Delete(int personId)
        {
            throw new NotImplementedException();
        }

        public ResponseDataModel<List<Person>> GetAll()
        {
            var result = new ResponseDataModel<List<Person>>() { Success = false };
            HttpResponseMessage httpResponseMessage = _httpClient.GetAsync($"{apiUrl}/GetAll").Result;
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonData = httpResponseMessage.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<ResponseDataModel<List<Person>>>(jsonData);
            }
            return result;
        }
    }
}
