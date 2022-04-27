﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoeShop.Businness.Abstract;
using ShoeShop.DataAccess.Abstract;
using ShoeShop.Entities;

namespace ShoeShop.Businness.Concrete
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandRepository _brandRepository;

        public BrandManager(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
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

        public void UpdateBrand(Brand brand)
        {
            _brandRepository.Update(brand);
        }

        public void AddBrand(Brand brand)
        {
            _brandRepository.Add(brand);
        }

        public void DeleteBrand(int brandId)
        {
            _brandRepository.DeleteById(brandId);
        }
    }
}
