using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoeShop.Entities.Concrete;

namespace ShoeShop.Businness.Abstract
{
    public interface IColorService
    {
        ICollection<Color> GetAllColors();
        Color GetColor(int id);
    }
}
