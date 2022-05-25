using System;
using Microsoft.AspNetCore.Mvc;

namespace ShoeShop.API.Filters.IsExist
{
    public class BrandIsExistAttribute : TypeFilterAttribute
    {
        public BrandIsExistAttribute() : base(typeof(BrandCheckExisting))
        {
        }
    }
}
