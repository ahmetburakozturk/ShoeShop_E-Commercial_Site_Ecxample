using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoeShop.Dtos.Abstract;

namespace ShoeShop.Dtos
{
    public class FavoriteDto : IDto
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int UserID { get; set; }
        public bool IsFavorite { get; set; }
    }
}
