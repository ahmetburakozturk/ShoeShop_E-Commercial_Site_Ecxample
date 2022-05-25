using System;
using Microsoft.AspNetCore.Mvc;

namespace ShoeShop.API.Filters.IsExist
{
    public class CategoryIsExistsAttribute : TypeFilterAttribute
    {
        public CategoryIsExistsAttribute() : base(typeof(CategoryCheckExisting))
        {
        }
    }
}
