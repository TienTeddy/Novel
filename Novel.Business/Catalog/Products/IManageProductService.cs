using Microsoft.AspNetCore.Http;
using Novel.ViewModels.Catalog.Products;
using Novel.ViewModels.Catalog.Products.Manage;
using Novel.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Novel.Business.Catalog.Products
{
    public interface IManageProductService
    {
        Task<int> Create(ProductCreateRequest request);
        Task<int> Update(ProductUpdateRequest request);
        Task<int> Delete(int productId);
        Task<bool> UpdatePrice(int productId, decimal newPrice);
        Task<bool> UpdateStock(int productId, int addedQuantity);
        Task AddViewCount(int productId);
        //Task<List<ProductViewModel>> GetAll();
        Task<PagedResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request);

        Task<int> AddImages(int productId, List<IFormFile> formFiles);
        Task<int> UpdateImages(int imageId, string caption, bool IsDefault);
        Task<int> RemoveImage(int imageId);
    }
}
