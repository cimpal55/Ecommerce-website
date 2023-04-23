using Ecommerce.Server.Services.ProductTypesService;
using Ecommerce.Shared.Models.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypesService _productTypeService;

        public ProductTypeController(IProductTypesService productTypeService)
        {
            _productTypeService = productTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponseRecord<List<ProductTypesRecord>>>> GetProductTypes()
        {
            var response = await _productTypeService.GetProductTypes();
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponseRecord<List<ProductTypesRecord>>>> AddProductType(ProductTypesRecord productType)
        {
            var response = await _productTypeService.AddProductType(productType);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponseRecord<List<ProductTypesRecord>>>> UpdateProductType(ProductTypesRecord productType)
        {
            var response = await _productTypeService.UpdateProductType(productType);
            return Ok(response);
        }
    }
}
