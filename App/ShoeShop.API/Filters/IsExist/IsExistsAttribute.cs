using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ShoeShop.Businness.Abstract;

namespace ShoeShop.API.Filters.IsExist
{
    public class IsExistsAttribute : TypeFilterAttribute
    {
        public IsExistsAttribute() : base(typeof(CheckExisting))
        {
        }
    }
}

