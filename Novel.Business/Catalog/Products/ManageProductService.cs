﻿using Novel.DAL.EF;
using Novel.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utilities.Exceptions;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Novel.ViewModels.Catalog.Products.Manage;
using Novel.ViewModels.Common;
using Novel.ViewModels.Catalog.Products;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.IO;
using Novel.Business.Common;

namespace Novel.Business.Catalog.Products.ManageProductService
{
    public class ManageProductService : IManageProductService
    {
        private readonly ShopDbContext _context;
        private readonly IStorageService _storageService;
        public ManageProductService(ShopDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task AddViewCount(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            product.view_count += 1;
            await _context.SaveChangesAsync();
            //throw new NotImplementedException();
        }

        public async Task<int> Create(ProductCreateRequest request)
        {
            var product = new Product()
            {
                price = request.price,
                original_price = request.original_price,
                stock = request.stock,
                view_count = 0,
                date_created = DateTime.Now,
                ProductTranslations = new List<ProductTranslation>
                {
                    new ProductTranslation()
                    {
                        name = request.name,
                        description=request.description,
                        details=request.details,
                        seo_description=request.seo_description,
                        seo_title=request.seo_title,
                        seo_alias=request.seo_alias,
                        id_language=request.id_language
                    }
                }

            };

            //Save Thumbnail Image
            if (request.thumbnailImage != null)
            {
                product.ProductImages = new List<ProductImage>()
                {
                    new ProductImage()
                    {
                        caption=$"Thumbnail Image {request.name}",
                        date_created=DateTime.Now,
                        file_size=request.thumbnailImage.Length,
                        image_path=await this.SaveFile(request.thumbnailImage),
                        IsDefault=true,
                        sort_order=1
                    }
                };
            }
            _context.Products.Add(product);
            return await _context.SaveChangesAsync();
            //throw new NotImplementedException();
        }

        public async Task<int> Delete(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                throw new NovelException($"Cannot find is product {productId}");
            }
            var images = _context.ProductImages.Where(x => x.id_product == productId);
            foreach(var image in images)
            {
                await _storageService.DeleteFileAsync(image.image_path);
            }

            _context.Products.Remove(product);
            return await _context.SaveChangesAsync();
            //throw new NotImplementedException();
        }

        public async Task<PagedResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request)
        {
            //Select join
            var query = from product in _context.Products
                        join productTranslation in _context.ProductTranslations on product.id_product equals productTranslation.id_product
                        join productInCategory in _context.ProductInCategories on product.id_product equals productInCategory.id_product
                        join category in _context.Categories on productInCategory.id_category equals category.id_category
                        select new { product, productTranslation,  productInCategory};

            //Filter
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.productTranslation.name.Contains(request.Keyword));
            }

            if (request.CategoryIds.Count > 0)
            {
                query = query.Where(x=>request.CategoryIds.Contains(x.productInCategory.id_category));
            }

            //Paging 
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ProductViewModel()
                {
                    id_product =  x.product.id_product,
                    name =  x.productTranslation.name,
                    date_created =  x.product.date_created,
                    description= x.productTranslation.description,
                    details=x.productTranslation.details,
                    id_language=x.productTranslation.id_language,
                    price=x.product.price,
                    original_price=x.product.original_price,
                    seo_alias=x.productTranslation.seo_alias,
                    seo_description=x.productTranslation.seo_description,
                    seo_title=x.productTranslation.seo_title,
                    stock=x.product.stock,
                    view_count=x.product.view_count
                }).ToListAsync();

            //Select and projection
            var pagedResult = new PagedResult<ProductViewModel>()
            {
                TotalRecord = totalRow,
                Items = data
            };
            return pagedResult;
        }

        public async Task<int> Update(ProductUpdateRequest request)
        {
            var product = await _context.Products.FindAsync(request.id_product);
            var productTranslation = await _context.ProductTranslations.FirstOrDefaultAsync(x=>x.id_product == request.id_product && x.id_language == request.id_language);
            if (product == null || productTranslation==null)
            {
                throw new NovelException($"Cannot find a product with id: {request.id_product}");
            }

            //Update
            productTranslation.name = request.name;
            productTranslation.seo_alias = request.seo_alias;
            productTranslation.seo_description = request.seo_description;
            productTranslation.seo_title = request.seo_title;
            productTranslation.description = request.description;
            productTranslation.details = request.details;

            //Save Thumbnail Image
            if (request.thumbnailImage != null)
            {
                var thumbnail_Image = await _context.ProductImages.FirstOrDefaultAsync(x => x.IsDefault == true && x.id_product == request.id_product);
                if (thumbnail_Image != null)
                {
                    thumbnail_Image.caption = $"Thumbnail Image {request.name}";
                    thumbnail_Image.file_size = request.thumbnailImage.Length;
                    thumbnail_Image.image_path = await this.SaveFile(request.thumbnailImage);
                    _context.ProductImages.Update(thumbnail_Image);
                }                
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdatePrice(int productId, decimal newPrice)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                throw new NovelException($"Cannot find a product with id: {productId}");
            }
            product.price = newPrice;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateStock(int productId, int addedQuantity)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                throw new NovelException($"Cannot find a product with id: {productId}");
            }
            product.stock += addedQuantity;
            return await _context.SaveChangesAsync() > 0;
        }


        public async Task<int> AddImages(int productId, List<IFormFile> formFiles)
        {
            var images = await _context.ProductImages.FirstOrDefaultAsync(x => x.id_product == productId);
            if (images != null)
            {
                throw new NovelException($"Product Id exist!");
            }

            int flag = 1;
            var listImage = new List<ProductImage>();
            var img = new ProductImage();
            if (formFiles != null)
            {
                foreach(var formFile in formFiles)
                {
                    img.caption = $"Thumbnail Image {formFile.FileName}";
                    img.date_created = DateTime.Now;
                    img.file_size = formFile.Length;
                    img.image_path = await this.SaveFile(formFile);
                    img.IsDefault = true;
                    img.sort_order = flag;
                    listImage.Add(img);
                    flag++;
                }

                await _context.ProductImages.AddRangeAsync(listImage);
                return await _context.SaveChangesAsync();
            }

            throw new NovelException($"The image empty");
        }
        public async Task<int> RemoveImage(int imageId)
        {
            var image = await _context.ProductImages.FirstOrDefaultAsync(x=>x.id_productImage==imageId);
            if (image == null)
            {
                throw new NovelException($"Image Id doest not exist!");
            }

             await _storageService.DeleteFileAsync(image.image_path);
            _context.ProductImages.Remove(image);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> UpdateImages(int imageId, string caption, bool IsDefault)
        {
            var image = await _context.ProductImages.FirstOrDefaultAsync(x => x.id_productImage == imageId);
            if (image == null)
            {
                throw new NovelException($"Image Id doest not exist!");
            }

            image.caption = caption;
            image.IsDefault = IsDefault;
            _context.ProductImages.Update(image);
            return await _context.SaveChangesAsync();
        }

        //IFormFile
        private async Task<string> SaveFile(IFormFile formFile)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(formFile.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(formFile.OpenReadStream(), fileName);
            return fileName;
        }
    }
}
