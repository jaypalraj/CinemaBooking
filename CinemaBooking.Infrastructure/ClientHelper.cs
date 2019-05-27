using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
    }
}
