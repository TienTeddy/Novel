using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novel.ViewModels.Catalog.ProductImages
{
    public class ProductImageCreate_UpdateRequest
    {
        public int id_product { get; set; }

        public string caption { get; set; }

        public bool IsDefault { get; set; } = true;

        public IFormFile thumbnailImage { get; set; }

    }
}
