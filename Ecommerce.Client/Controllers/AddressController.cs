using Ecommerce.Server.Services.AddressService;
using Ecommerce.Shared.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponseRecord<UserAddressesRecord>>> GetAddress()
        {
            return await _addressService.GetAddress();
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponseRecord<UserAddressesRecord>>> AddOrUpdateAddress(UserAddressesRecord address)
        {
            return await _addressService.AddOrUpdateAddress(address);
        }
    }
}
