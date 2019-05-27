using System.Net.Http;
using System.Threading.Tasks;

namespace CinemaBooking.Infrastructure
{
    public interface IClientHelper
    {
        Task<HttpContent> GetAsync(string requestUri, string baseAddress = CinemaBookingConstants.WebAPIsUrl);
    }
}