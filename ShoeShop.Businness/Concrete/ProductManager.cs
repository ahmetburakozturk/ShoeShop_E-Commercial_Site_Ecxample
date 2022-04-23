using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ShoeShop.Businness.Abstract;
using ShoeShop.DataAccess.Abstract;
using ShoeShop.Dtos.Requests;
using ShoeShop.Dtos.Responses;
using ShoeShop.Entities;

namespace ShoeShop.Businness.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBrandRepository _brandRepository;

        public ProductManager(IProductRepository productRepository, IMapper mapper, ICategoryRepository categoryRepository,IBrandRepository brandRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _brandRepository = brandRepository;
        }
        public ICollection<Product> GetAllProducts()
        {
            return _productRepository.GetAll().Where(p=>p.IsActive==true).ToList();
        }

        public Product GetProductById(int id)
        {
            return _productRepository.GetById(id);
        }

        public int CreateProduct(AddProductRequest productRequest)
        {
            var product = _mapper.Map<Product>(productRequest);
            return _productRepository.Add(product);
        }

        public ICollection<ProductListResponse> GetAllProductsWithInfo()
        {
            var productRepsonse = new List<ProductListResponse>();
            var products = _productRepository.GetAll().Where(p=>p.IsActive==true).ToList();
            foreach (var pdt in products)
            {
                var brand = _brandRepository.GetById(pdt.BrandID);
                var category = _categoryRepository.GetById(pdt.CategoryID);
                productRepsonse.Add(new ProductListResponse{Name = pdt.Name,BrandName = brand.Name,CategoryName = category.Name,Discount = pdt.Discount,ImageUrl = pdt.ImageUrl,IsActive = pdt.IsActive,Price = pdt.Price});
            }

            return productRepsonse;
        }
    }
}
