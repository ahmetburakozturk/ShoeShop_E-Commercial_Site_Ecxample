using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ShoeShop.Dtos;
using ShoeShop.Dtos.Requests;
using ShoeShop.Dtos.Responses;
using ShoeShop.Entities;

namespace ShoeShop.Businness.MapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Product,AddProductRequest>();
            CreateMap<AddProductRequest,Product>();
            CreateMap<Product,ProductListResponse>();
            CreateMap<Product,ProductDetailsResponse>();
            CreateMap<UpdateProductRequest,Product>();
            CreateMap<Product,UpdateProductRequest>();
            CreateMap<Product,DeleteProductRequest>();
            CreateMap<DeleteProductRequest,Product>();
            CreateMap<CategoryDto,Category>();
            CreateMap<Category,CategoryDto>();
        }
    }
}
