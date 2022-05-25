using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ShoeShop.Businness.Abstract;
using ShoeShop.DataAccess.Abstract;
using ShoeShop.Dtos.Concrete;
using ShoeShop.Entities;

namespace ShoeShop.Businness.Concrete
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public BrandManager(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }
        public ICollection<Brand> GetAllBrands()
        {
            return _brandRepository.GetAll();
        }

        public Brand GetBrand(int id)
        {
            return _brandRepository.GetById(id);
        }

        public bool IsExist(int id)
        {
            return _brandRepository.IsExists(id);
        }

        public void UpdateBrand(BrandDto brandDto)
        {
            var brand = _mapper.Map<Brand>(brandDto);
            _brandRepository.Update(brand);
        }

        public int AddBrand(Brand brand)
        {
            return _brandRepository.Add(brand);
        }

        public void DeleteBrand(int brandId)
        {
            _brandRepository.DeleteById(brandId);
        }
    }
}
