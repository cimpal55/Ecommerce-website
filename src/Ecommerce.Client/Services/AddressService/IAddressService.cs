using Ecommerce.Shared.Models.Data;

namespace Ecommerce.Client.Services.AddressService
{
    public interface IAddressService
    {
        Task<ServiceResponseRecord<UserAddressesRecord>> AddOrUpdateAddress(UserAddressesRecord address);
        Task<ServiceResponseRecord<UserAddressesRecord>> GetAddress();

    }
}
