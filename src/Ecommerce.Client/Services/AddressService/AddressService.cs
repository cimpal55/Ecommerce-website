using Ecommerce.Client.Services.AuthService;
using Ecommerce.Shared.Models.Data;
using LinqToDB;
using Ecommerce.Client.DbAccess;

namespace Ecommerce.Client.Services.AddressService
{
    public class AddressService : IAddressService
    {
        private readonly SqlDataAccess _conn;
        private readonly IAuthService _authService;

        public AddressService(SqlDataAccess conn, IAuthService authService)
        {
            _conn = conn;
            _authService = authService;
        }

        public async Task InsertAddressAsync(UserAddressesRecord address)
        {
            await _conn
                .InsertAsync(address)
                .ConfigureAwait(false);
        }
        public async Task UpdateAddressAsync(UserAddressesRecord address)
        {
            await _conn
                .UpdateAsync(address)
                .ConfigureAwait(false);
        }
        public async Task DeleteAddressAsync(UserAddressesRecord address)
        {
            await _conn
                .DeleteAsync(address)
                .ConfigureAwait(false);
        }
        public async Task<ServiceResponseRecord<UserAddressesRecord>> AddOrUpdateAddress(UserAddressesRecord address)
        {
            var response = new ServiceResponseRecord<UserAddressesRecord>();
            var dbAddress = (await GetAddress()).Data;
            if (dbAddress == null)
            {
                address.UserId = _authService.GetUserId();
                await _conn.InsertAsync(address).ConfigureAwait(false);
                response.Data = address;
            }
            else
            {
                dbAddress.FirstName = address.FirstName;
                dbAddress.LastName = address.LastName;
                dbAddress.State = address.State;
                dbAddress.Country = address.Country;
                dbAddress.City = address.City;
                dbAddress.Zip = address.Zip;
                dbAddress.Street = address.Street;
                response.Data = dbAddress;
            }

            await UpdateAddressAsync(dbAddress).ConfigureAwait(false);

            return response;
        }

        public async Task<ServiceResponseRecord<UserAddressesRecord>> GetAddress()
        {
            int userId = _authService.GetUserId();
            var address = await _conn.UserAddresses
                            .FirstOrDefaultAsync(a => a.UserId == userId);
            return new ServiceResponseRecord<UserAddressesRecord> { Data = address };
        }
    }
}
