using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Shared.Clients.Interface;
using Shared.Clients.Models;

namespace Shared.Clients
{
    public class PartnerClient : IPartnerClient
    {
        private readonly HttpClient _httpClient;
        public PartnerClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Partner> GetPartner(string email)
        {
            Partner response = null;
            try
            {
                response = await _httpClient.GetFromJsonAsync<Partner>($"api/partner/email/{email}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
           
            return response;
        }
    }
}
