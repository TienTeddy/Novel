using Novel.Business.Catalog.Products.Dtos;
using Novel.Business.Catalog.Products.Dtos.Public;
using Novel.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Novel.Business.Catalog.Products
{
    public interface IPublicProductRequest
    {
        Task<PagedResult<ProductViewModel>> GetAllByCategoryId(GetProductPagingRequest request);
    }
}
