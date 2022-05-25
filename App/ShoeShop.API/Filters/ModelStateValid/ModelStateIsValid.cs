using System;
using Microsoft.AspNetCore.Mvc;

namespace ShoeShop.API.Filters.ModelStateValid
{
    public class ModelStateIsValid : TypeFilterAttribute
    {
        public ModelStateIsValid() : base(typeof(CheckModelStateValidity))
        {
        }
    }
}
