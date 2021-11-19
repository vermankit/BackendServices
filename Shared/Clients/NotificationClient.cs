using Shared.Clients.Interface;
using System.Net.Http;

namespace Shared.Clients
{
    public class NotificationClient : INotificationClient
    {
        private readonly HttpClient _httpClient;
        public NotificationClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
