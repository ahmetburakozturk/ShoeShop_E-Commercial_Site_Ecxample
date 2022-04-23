using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoeShop.Dtos.Requests;
using ShoeShop.Dtos.Responses;
using ShoeShop.Entities;

namespace ShoeShop.Businness.Abstract
{
    public interface IProductService
    {
        ICollection<Product> GetAllProducts();
        Product GetProductById(int id);
        int CreateProduct(AddProductRequest productRequest);
        ICollection<ProductListResponse> GetAllProductsWithInfo();
    }
}
