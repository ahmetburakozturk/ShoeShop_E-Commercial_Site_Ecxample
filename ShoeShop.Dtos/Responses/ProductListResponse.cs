using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShop.Dtos.Responses
{
    public class ProductListResponse
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public double? Discount { get; set; }
        public bool? IsActive { get; set; }
        public string BrandName { get; set; }
        public string CategoryName { get; set; }

    }
}
