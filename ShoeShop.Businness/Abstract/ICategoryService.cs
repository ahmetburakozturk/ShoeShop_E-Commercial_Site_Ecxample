using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoeShop.Dtos;
using ShoeShop.Dtos.Requests;
using ShoeShop.Entities;

namespace ShoeShop.Businness.Abstract
{
    public interface ICategoryService
    {
        ICollection<Category> GetAllCategories();
        CategoryDto GetCategoryById(int id);
        void UpdateCategory(CategoryDto categoryDto);
        bool isExist(int id);
        void AddCategory(CategoryDto categoryDto);
    }
}
