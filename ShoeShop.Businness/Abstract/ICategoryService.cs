using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoeShop.Entities;

namespace ShoeShop.Businness.Abstract
{
    public interface ICategoryService
    {
        ICollection<Category> GetAllCategories();
        Category geGetCategoryById(int id);
    }
}
