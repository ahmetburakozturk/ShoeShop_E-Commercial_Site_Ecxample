using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoeShop.Entities;

namespace ShoeShop.Businness.Abstract
{
    public interface IBrandService
    {
        ICollection<Brand> GetAllBrands();
        Brand GetBrand(int id);
        bool IsExist(int id);
        void UpdateBrand(Brand brand);
        void AddBrand(Brand brand);
        void DeleteBrand(int brandId);
    }   
}
