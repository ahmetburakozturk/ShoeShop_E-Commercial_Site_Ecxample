using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ShoeShop.Businness.Abstract;
using ShoeShop.DataAccess.Abstract;
using ShoeShop.Dtos;
using ShoeShop.Dtos.Requests;
using ShoeShop.Dtos.Responses;
using ShoeShop.Entities;

namespace ShoeShop.Businness.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductManager(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public ICollection<Product> GetAllProducts()
        {
            return _productRepository.GetAll().ToList();
        }

        public ICollection<ProductDto> GetAllActiveProductsWithBrand()
        {
            var productsDto = _productRepository.GetAllActiveProductsWithBrand().ToList();
            return productsDto;
        }

        public int CreateProduct(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            return _productRepository.Add(product);
        }

        public ProductDto GetProductByIdWithDetails(int id)
        {
            var product = _productRepository.GetProductByIdWithDetails(id).FirstOrDefault();
            return product;
        }

        public ProductDto GetProductById(int id)
        {
            var product = _productRepository.GetProductById(id).FirstOrDefault();
            return product;
        }

        public int UpdateProduct(ProductDto productDto)
        {
            Product product = _mapper.Map<Product>(productDto);
            return _productRepository.Update(product);
        }

        public bool isExist(int id)
        {
            return _productRepository.IsExists(id);
        }

    }
}
