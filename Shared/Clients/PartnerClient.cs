using System.Net.Http;
using Shared.Clients.Interface;

namespace Shared.Clients
{
    public class PartnerClient : IPartnerClient
    {
        private readonly HttpClient _httpClient;
        public PartnerClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
