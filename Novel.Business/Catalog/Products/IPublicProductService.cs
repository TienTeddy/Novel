using Novel.ViewModels.Catalog.Products;
using Novel.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Novel.Business.Catalog.Products
{
    public interface IPublicProductService
    {
        Task<PagedResult<ProductViewModel>> GetAllByCategoryId(GetPublicProductPagingRequest request);
        Task<PagedResult<ProductViewModel>> GetAll(string languageId); 
    }
}
