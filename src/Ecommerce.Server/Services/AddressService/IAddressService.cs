using Ecommerce.Shared.Models.Data;

namespace Ecommerce.Server.Services.AddressService
{
    public interface IAddressService
    {
        Task<ServiceResponseRecord<UserAddressesRecord>> AddOrUpdateAddress(UserAddressesRecord address);
        Task<ServiceResponseRecord<UserAddressesRecord>> GetAddress();

    }
}
