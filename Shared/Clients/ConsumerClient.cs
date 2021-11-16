﻿using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Shared.Clients.Interface;
using Shared.Clients.Models;

namespace Shared.Clients
{
    public class ConsumerClient : IConsumerClient
    {
        private readonly HttpClient _httpClient;
        public ConsumerClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Customer> GetCustomer(string email)
        {
            var response = await _httpClient.GetFromJsonAsync<Customer>($"/customer/{email}");
            return response;
        }
    }
}
