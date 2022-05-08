using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoeShop.Businness.Abstract;
using ShoeShop.DataAccess.Abstract;
using ShoeShop.Entities.Concrete;

namespace ShoeShop.Businness.Concrete
{
    public class ColorManager : IColorService
    {
        private readonly IColorRepository _colorRepository;

        public ColorManager(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }
        public ICollection<Color> GetAllColors()
        {
            return _colorRepository.GetAll();
        }

        public Color GetColor(int id)
        {
            return _colorRepository.GetById(id);
        }
    }
}
