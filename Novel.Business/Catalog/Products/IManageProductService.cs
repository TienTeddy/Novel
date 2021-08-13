using Microsoft.AspNetCore.Http;
using Novel.Business.Catalog.Products;
using Novel.ViewModels.Catalog.Products;
using Novel.ViewModels.Catalog.ProductImages;
using Novel.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Novel.ViewModels.Catalog.QrCodeUsers;

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
        Task<List<ProductViewModel>> GetById(int productId, string languageId);
        Task<PagedResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request);

        // Product Images
        Task<PagedResult<ProductImageViewModel>> GetProductImages(int productId);
        Task<int> AddImages(ProductImageCreate_UpdateRequest formFiles);
        Task<int> UpdateImages(int imageId, ProductImageCreate_UpdateRequest productImage);
        Task<int> RemoveImage(int imageId);

        // QrCode User
        Task<PagedResult<QrCodeUserViewModel>> GetQrCodeId(Guid userId);
        Task<Guid> CreateQrCodeUser(Guid userId, string qrCodeText);
        Task<int> RemoveQrCodeUser(Guid userId);
    }
}
