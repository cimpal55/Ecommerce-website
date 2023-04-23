using Ecommerce.Shared.Models.Data;

namespace Ecommerce.Client.Services.AddressService
{
    public interface IAddressService
    {
        Task<UserAddressesRecord> GetAddress();
        Task<UserAddressesRecord> AddOrUpdateAddress(UserAddressesRecord address);
    }
}
