﻿using Newtonsoft.Json;
using PhoneBook.WebApp.Models.ServiceModel;
using PhoneBook.WebApp.Services.Abstact;

namespace PhoneBook.WebApp.Services.Concrete
{
    public class ReportManager : IReportService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        string apiUrl;
        public ReportManager(IConfiguration configuration)
        {
            _configuration = configuration;
            var webServiceUrl = _configuration.GetSection("WebServiceURL").Get<string>();
            apiUrl = $"{webServiceUrl}/Reports";

            _httpClient = HttpClientFactory.Create();
        }
        public ResponseDataModel<List<Report>> GetAll()
        {
            var result = new ResponseDataModel<List<Report>>() { Success = false };
            HttpResponseMessage httpResponseMessage = _httpClient.GetAsync($"{apiUrl}/GetAll").Result;
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonData = httpResponseMessage.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<ResponseDataModel<List<Report>>>(jsonData);
            }
            return result;
        }

        public bool RequestReport()
        {
            var result = new ResponseDataModel<List<Report>>() { Success = false };
            HttpResponseMessage httpResponseMessage = _httpClient.GetAsync($"{apiUrl}/RequestReport").Result;
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

        public byte[] ReportDownload(int reportId)
        {
            HttpResponseMessage httpResponseMessage = _httpClient.PostAsync($"{apiUrl}/ReportDownload?reportId={reportId}", null).Result;
            var file = httpResponseMessage.Content.ReadAsByteArrayAsync().Result;
            return file;
        }
    }
}