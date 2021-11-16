using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace UI.Common.APIcalls
{
    public class GenericCallsClass
    {
        public HttpResponseMessage GetAsyncCall(string url, string call)
        {
            string BaseAddressAPI = url;
            var client = new HttpClient
            {
                BaseAddress = new Uri(BaseAddressAPI)
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = TimeSpan.FromMinutes(30);

            HttpResponseMessage response = client.GetAsync(call).Result;

            return response;
        }

        public HttpResponseMessage PostAsJsonAsyncCall(string url, string call, Object model)
        {
            string BaseAddressAPI = url;
            var client = new HttpClient
            {
                BaseAddress = new Uri(BaseAddressAPI)
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = TimeSpan.FromMinutes(30);

            HttpResponseMessage response = client.PostAsJsonAsync(call, model).Result;

            return response;
        }

        public HttpResponseMessage PutAsJsonAsyncCall(string url, string call, Object model)
        {
            string BaseAddressAPI = url;
            var client = new HttpClient
            {
                BaseAddress = new Uri(BaseAddressAPI)
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = TimeSpan.FromMinutes(30);

            HttpResponseMessage response = client.PutAsJsonAsync(call, model).Result;

            return response;
        }

        public HttpResponseMessage DeleteAsJsonAsyncCall(string url, string call)
        {
            string BaseAddressAPI = url;
            var client = new HttpClient
            {
                BaseAddress = new Uri(BaseAddressAPI)
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = TimeSpan.FromMinutes(30);

            HttpResponseMessage response = client.DeleteAsync(call).Result;

            return response;
        }
    }
}
