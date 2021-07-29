using Novel.Business.Catalog.Products.Dtos;
using Novel.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Novel.Business.Catalog.Products
{
    public interface IManageProductService
    {
        Task<int> Create(ProductCreateRequest request);
        Task<int> Update(ProductEditRequest request);
        Task<int> Delete(int productId);

        Task<List<ProductViewModel>> GetAll();
        Task<PagedViewModel<ProductViewModel>> GetAllPaging(string keyword, int pageIndex, int pageSize);
    }
}
