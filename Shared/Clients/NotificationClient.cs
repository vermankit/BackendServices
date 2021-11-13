using System.Net.Http;
using Shared.Clients.Interface;

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
