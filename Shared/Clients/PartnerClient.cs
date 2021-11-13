using System;
using System.Net.Http;
using System.Threading.Tasks;
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

        public async Task<dynamic> GetPartner(Guid partnerId)
        {
            var response = await _httpClient.GetAsync($"/partner/{partnerId}");
            return response;
        }
    }
}
