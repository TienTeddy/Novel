using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Novel.Business.Catalog.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IPublicProductService _pubicProductService;
        public ProductController(IPublicProductService publicProductService)
        {
            _pubicProductService = publicProductService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _pubicProductService.GetAll();
            return Ok(data);
        }
    }
}
