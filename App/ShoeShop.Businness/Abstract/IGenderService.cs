using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoeShop.Entities.Concrete;

namespace ShoeShop.Businness.Abstract
{
    public interface IGenderService
    {
        ICollection<Gender> GetAllGenders();
        Gender GetGender(int id);
    }
}
