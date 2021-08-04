using Novel.DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Novel.ViewModels.Common;
using Novel.ViewModels.Catalog.Products;

namespace Novel.Business.Catalog.Products
{
    public class PublicProductService : IPublicProductService
    {
        private readonly ShopDbContext _context;
        public PublicProductService(ShopDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<ProductViewModel>> GetAll()
        {
            var query =  from product in _context.Products
                        join productTranslation in _context.ProductTranslations on product.id_product equals productTranslation.id_product
                        select new { product, productTranslation };

            //Paging 
            int totalRow = await query.CountAsync();

            //Select and projection
            var data = await query.Select(x => new ProductViewModel()
                {
                    id_product = x.product.id_product,
                    name = x.productTranslation.name,
                    date_created = x.product.date_created,
                    description = x.productTranslation.description,
                    details = x.productTranslation.details,
                    id_language = x.productTranslation.id_language,
                    price = x.product.price,
                    original_price = x.product.original_price,
                    seo_alias = x.productTranslation.seo_alias,
                    seo_description = x.productTranslation.seo_description,
                    seo_title = x.productTranslation.seo_title,
                    stock = x.product.stock,
                    view_count = x.product.view_count
                }).ToListAsync();
            var pagedResult = new PagedResult<ProductViewModel>()
            {
                TotalRecord = totalRow,
                Items = data
            };
            return pagedResult;
        }

        public async Task<PagedResult<ProductViewModel>> GetAllByCategoryId(GetPublicProductPagingRequest request)
        {
            //Select join
            var query = from product in _context.Products
                        join productTranslation in _context.ProductTranslations on product.id_product equals productTranslation.id_product
                        join productInCategory in _context.ProductInCategories on product.id_product equals productInCategory.id_product
                        join category in _context.Categories on productInCategory.id_category equals category.id_category
                        select new { product, productTranslation, productInCategory };

            //Filter
            if (request.CategoryId.HasValue && request.CategoryId.Value > 0)
            {
                query = query.Where(x => x.productInCategory.id_category == request.CategoryId);
            }

            //Paging 
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ProductViewModel()
                {
                    id_product = x.product.id_product,
                    name = x.productTranslation.name,
                    date_created = x.product.date_created,
                    description = x.productTranslation.description,
                    details = x.productTranslation.details,
                    id_language = x.productTranslation.id_language,
                    price = x.product.price,
                    original_price = x.product.original_price,
                    seo_alias = x.productTranslation.seo_alias,
                    seo_description = x.productTranslation.seo_description,
                    seo_title = x.productTranslation.seo_title,
                    stock = x.product.stock,
                    view_count = x.product.view_count
                }).ToListAsync();

            //Select and projection
            var pagedResult = new PagedResult<ProductViewModel>()
            {
                TotalRecord = totalRow,
                Items = data
            };
            return pagedResult;
        }
    }
}
