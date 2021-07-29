using Novel.Business.Catalog.Products.Dtos;
using Novel.Business.Dtos;
using Novel.DAL.EF;
using Novel.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Novel.Business.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly ShopDbContext _context;
        public ManageProductService(ShopDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(ProductCreateRequest request)
        {
            var product = new Product()
            {
                price = request.price
            };

            _context.Products.Add(product);
            return await _context.SaveChangesAsync();
            //throw new NotImplementedException();
        }

        public async Task<int> Delete(int productId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<PagedViewModel<ProductViewModel>> GetAllPaging(string keyword, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update(ProductEditRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
