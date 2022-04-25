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
        private readonly IColorRepository _colorRepository;
        private readonly IGenderRepository _genderRepository;

        public ProductManager(IProductRepository productRepository, IMapper mapper, ICategoryRepository categoryRepository,
            IBrandRepository brandRepository,IColorRepository colorRepository,IGenderRepository genderRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _brandRepository = brandRepository;
            _colorRepository = colorRepository;
            _genderRepository = genderRepository;
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
                productRepsonse.Add(new ProductListResponse{ID = pdt.ID,Name = pdt.Name,ColorID = pdt.ColorID,BrandID = pdt.BrandID,GenderID = pdt.GenderID,BrandName = brand.Name,CategoryName = category.Name,Discount = pdt.Discount,ImageUrl = pdt.ImageUrl,IsActive = pdt.IsActive,Price = pdt.Price});
            }

            return productRepsonse;
        }

        public ProductDetailsResponse GetProductWithDetails(int id)
        {
            var product = _productRepository.GetById(id);
            var productDetails = _mapper.Map<ProductDetailsResponse>(product);
            var brandName = _brandRepository.GetById(product.BrandID).Name;
            productDetails.BrandName = brandName;
            var genderName = _genderRepository.GetById(product.GenderID).Name;
            productDetails.GenderName = genderName;
            var categoryName = _categoryRepository.GetById(product.CategoryID).Name;
            productDetails.CategoryName = categoryName;
            var colorName = _colorRepository.GetById(product.ColorID).Name;
            productDetails.ColorName = colorName;
            return productDetails;
        }

        public UpdateProductRequest GetProductForUpdate(int id)
        {
            var product = _productRepository.GetById(id);
            var response = _mapper.Map<UpdateProductRequest>(product);
            return response;
        }

        public int UpdateProduct(UpdateProductRequest productRequest)
        {
            Product product = _mapper.Map<Product>(productRequest);
            return _productRepository.Update(product);
        }

        

        public bool isExist(int id)
        {
            return _productRepository.IsExists(id);
        }
    }
}
