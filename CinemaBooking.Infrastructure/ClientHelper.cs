using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBooking.Infrastructure
{
    public class ClientHelper : IClientHelper
    {
        public async Task<HttpContent> GetAsync(string requestUri, string baseAddress = CinemaBookingConstants.WebAPIsUrl)
        {
            var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri(baseAddress);

            var response = await httpClient.GetAsync(requestUri);

            if (!response.IsSuccessStatusCode) return null;

            return response.Content;
        }


        public async Task<HttpContent> PostAsync<T>(string requestUri, T data, string baseAddress = CinemaBookingConstants.WebAPIsUrl)
        {
            var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri(baseAddress);

            var content = JsonConvert.SerializeObject(data);

            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await httpClient.PostAsync(requestUri, byteContent);

            if (!response.IsSuccessStatusCode) return null;

            return response.Content;
        }
    }
}
