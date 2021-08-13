﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Novel.Business.Catalog.Products;
using Novel.ViewModels.Catalog.Products;
using Novel.ViewModels.Catalog.ProductImages;
using Novel.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Novel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IPublicProductService _pubicProductService;
        private readonly IManageProductService _manageProductService;
        public ProductsController(IPublicProductService publicProductService, IManageProductService manageProductService)
        {
            _pubicProductService = publicProductService;
            _manageProductService = manageProductService;
        }

        [HttpGet("public-paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetPublicProductPagingRequest request)
        {
            var data = await _pubicProductService.GetAllByCategoryId(request);
            return Ok(data);
        }

        [HttpGet("all/{languageId}")]
        public async Task<IActionResult> GetAll(string languageId)
        {
            var data = await _pubicProductService.GetAll(languageId);
            return Ok(data);
        }
       
        [HttpGet("{productId}/{languageId}")]
        public async Task<IActionResult> GetById(int productId, string languageId)
        {
            var product = _manageProductService.GetById(productId, languageId);
            if (product == null)
            {
                return BadRequest("Cannot find product");
            }
            var result = new PagedResult<ProductViewModel>()
            {
                Items = await product,
                TotalRecord = 1,
                Message = "Success"
            };

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var productId = await _manageProductService.Create(request);
            if (productId == 0)
            {
                return BadRequest();
            }
            var product = await _manageProductService.GetById(productId, request.id_language);

            return CreatedAtAction(nameof(GetById), new { id = productId, languageId=request.id_language }, product);
            //return CreatedAtAction(nameof(GetById), new { productId,  request.id_language});
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] ProductUpdateRequest request)
        {
            var productId = await _manageProductService.Update(request);
            if (productId == 0)
            {
                return BadRequest();
            }

            PagedResult<ProductViewModel> p = new PagedResult<ProductViewModel>()
            {
                Items = null,
                TotalRecord = 1,
                Message = $"UPdate product id is {productId} success."
            };
            return Ok(p);
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> Delete(int productId)
        {
            var product = await _manageProductService.Delete(productId);
            if (product == 0)
            {
                return BadRequest();
            }
            PagedResult<ProductViewModel> p = new PagedResult<ProductViewModel>()
            {
                Items = null,
                TotalRecord = 1,
                Message = $"Deleted product id is {productId} success"
            };
            
            return Ok(p);
        }

        [HttpPatch("price-update/{productId}/{newPrice}")]
        public async Task<IActionResult> UpdatePrice(int productId, decimal newPrice)
        {
            var result = await _manageProductService.UpdatePrice(productId, newPrice);
            if (result)
            {
                PagedResult<ProductViewModel> p = new PagedResult<ProductViewModel>()
                {
                    Items = null,
                    TotalRecord = 1,
                    Message = $"Update product id is {productId} success"
                };
                return Ok(p);
            }

            return BadRequest("Update new price error.");
        }

        [HttpPatch("price-stock/{productId}/{newQuantity}")]
        public async Task<IActionResult> UpdateStock([FromQuery]int productId, int newQuantity)
        {
            var result = await _manageProductService.UpdateStock(productId, newQuantity);
            if (result == false)
            {
                return BadRequest("Update stock error.");
            }

            PagedResult<ProductViewModel> p = new PagedResult<ProductViewModel>()
            {
                Items = null,
                TotalRecord = 1,
                Message = $"Deleted product id is {productId} success"
            };
            return Ok(p);
        }

        [HttpGet("images/{productId}")]
        public async Task<IActionResult> GetProductImages(int productId)
        {
            var result = await _manageProductService.GetProductImages(productId);

            
            if (result.TotalRecord == 0)
            {
                return BadRequest("Image not find item.");
            }

            return Ok(result);
        }

        [HttpPost("images-add")]
        public async Task<IActionResult> AddImages([FromForm] ProductImageCreate_UpdateRequest formFiles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var images = await _manageProductService.AddImages(formFiles);
            if (images > 0)
            {
                var result = new PagedResult<object>()
                {
                    Items=null,
                    TotalRecord=1,
                    Message="Add images success."
                };
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPut("images-update")]
        public async Task<IActionResult> UpdateImage(int imageId,[FromForm] ProductImageCreate_UpdateRequest formFiles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var images = await _manageProductService.UpdateImages(imageId,formFiles);
            if (images > 0)
            {
                var result = new PagedResult<object>()
                {
                    Items = null,
                    TotalRecord = 1,
                    Message = "Update images success."
                };
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpDelete("images-remove")]
        public async Task<IActionResult> RemoveImage(int imageId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var images = await _manageProductService.RemoveImage(imageId);
            if (images > 0)
            {
                var result = new PagedResult<object>()
                {
                    Items = null,
                    TotalRecord = 1,
                    Message = "Remove image success."
                };
                return Ok(result);
            }

            return BadRequest();
        }

        //QR-CODE
        [HttpGet("qr-code/{userId}")]
        public async Task<IActionResult> GetQrCodeId(Guid userId)
        {
            var qrcode = await _manageProductService.GetQrCodeId(userId);
            if (qrcode == null)
            {
                return BadRequest();
            }
            return Ok(qrcode);
        }

        [HttpPost("qr-code/create")]
        public async Task<IActionResult> CreateQrCodeUser(Guid userId, string qrCodeText)
        {
            var qrcode = await _manageProductService.CreateQrCodeUser(userId, qrCodeText);
            if (qrcode == null)
            {
                return BadRequest();
            }

            var qr = await _manageProductService.GetQrCodeId(qrcode);
            return CreatedAtAction(nameof(GetQrCodeId), new { userId = qrcode }, qr);
        }

        [HttpPost("qr-code/remove")]
        public async Task<IActionResult> RemoveQrCodeUser(Guid userId)
        { 
            var qrcode = await _manageProductService.RemoveQrCodeUser(userId);
            if (qrcode > 0)
            {
                var result = new PagedResult<object>()
                {
                    Items = null,
                    TotalRecord = 1,
                    Message = "Remove QR-Code success."
                };
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
