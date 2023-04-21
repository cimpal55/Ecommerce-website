using Ecommerce.Shared.Models.Data;

namespace Ecommerce.Client.Services.AddressService
{
    public class AddressService : IAddressService
    {
        private readonly HttpClient _http;

        public AddressService(HttpClient http)
        {
            _http = http;
        }

        public async Task<UserAddressesRecord> AddOrUpdateAddress(UserAddressesRecord address)
        {
            var response = await _http.PostAsJsonAsync("api/address", address);
            return response.Content
                .ReadFromJsonAsync<ServiceResponseRecord<UserAddressesRecord>>().Result.Data;
        }

        public async Task<UserAddressesRecord> GetAddress()
        {
            var response = await _http
                .GetFromJsonAsync<ServiceResponseRecord<UserAddressesRecord>>("api/address");
            return response.Data;
        }
    }
}
