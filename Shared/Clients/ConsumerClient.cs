using System.Net.Http;
using Shared.Clients.Interface;

namespace Shared.Clients
{
    public class ConsumerClient : IConsumerClient
    {
        private readonly HttpClient _httpClient;
        public ConsumerClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
