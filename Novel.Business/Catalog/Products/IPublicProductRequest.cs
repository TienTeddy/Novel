using Novel.Business.Catalog.Products.Dtos;
using Novel.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novel.Business.Catalog.Products
{
    public interface IPublicProductRequest
    {
        PagedViewModel<ProductViewModel> GetAllByCategoryId(int categoryId, int pageIndex, int pageSize);
    }
}
