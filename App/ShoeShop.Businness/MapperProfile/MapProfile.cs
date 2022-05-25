using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ShoeShop.Dtos;
using ShoeShop.Dtos.Concrete;
using ShoeShop.Entities;
using ShoeShop.Entities.Concrete;

namespace ShoeShop.Businness.MapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<CategoryDto,Category>();
            CreateMap<Category,CategoryDto>();
            CreateMap<ProductDto,Product>();
            CreateMap<Product,ProductDto>();
            CreateMap<User,UserDto>();
            CreateMap<UserDto,User>();
            CreateMap<Stock,StockDto>();
            CreateMap<StockDto,Stock>();
            CreateMap<FavoriteDto,Favorite>();
            CreateMap<Favorite,FavoriteDto>();
            CreateMap<Brand, BrandDto>();
            CreateMap<BrandDto, Brand>();
        }
    }
}
