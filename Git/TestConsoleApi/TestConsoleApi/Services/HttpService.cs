using System.Net.Http;
using System.Threading.Tasks;
using TestConsoleApi;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Net.Http.Headers;


namespace TestConsoleApi.Services
{
    public class HttpService
    {
        static HttpClient client = new HttpClient();
        public string baseUrl;

        public HttpService()
        {
            this.baseUrl = "http://localhost:50729/api";
        }

       

        public async Task<T> Get<T>(string path)
        {
            T item = default(T);
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                item = await response.Content.ReadAsAsync<T>();
            }
            return item;
        }

      

       


    }
}
