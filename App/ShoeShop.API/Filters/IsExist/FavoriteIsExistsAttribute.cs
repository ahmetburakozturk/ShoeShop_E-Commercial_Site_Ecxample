using System;
using Microsoft.AspNetCore.Mvc;

namespace ShoeShop.API.Filters.IsExist
{
    public class FavoriteIsExistsAttribute : TypeFilterAttribute
    {
        public FavoriteIsExistsAttribute() : base(typeof(FavoriteCheckExisting))
        {
        }
    }
}
