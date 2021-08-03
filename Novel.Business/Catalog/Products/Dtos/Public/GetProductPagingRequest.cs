using Novel.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novel.Business.Catalog.Products.Dtos.Public
{
    public class GetProductPagingRequest : PagingRequestBase
    {
        public int? CategoryId { get; set; }
    }
}
