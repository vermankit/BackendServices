using Shared.Clients.Interface;
using System.Net.Http;

namespace Shared.Clients
{
    public class BookingClient : IBookingClient
    {
        private readonly HttpClient _httpClient;
        public BookingClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public dynamic AddBooking()
        {
            throw new System.NotImplementedException();
        }
    }
}
