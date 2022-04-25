using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShop.Dtos.Responses
{
    public class ProductDetailsResponse
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string ImageUrl2 { get; set; }
        public string ImageUrl3 { get; set; }
        public string ImageUrl4 { get; set; }
        public double Price { get; set; }
        public double? Discount { get; set; }
        public string BrandName { get; set; }
        public string CategoryName { get; set; }
        public string ColorName { get; set; }
        public double Size { get; set; }
        public string Material { get; set; }
        public string GenderName { get; set; }
    }
}
