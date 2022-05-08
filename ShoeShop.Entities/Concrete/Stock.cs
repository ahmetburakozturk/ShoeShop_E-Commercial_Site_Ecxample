using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoeShop.Entities.Abstract;

namespace ShoeShop.Entities.Concrete
{
    public class Stock : IEntity
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Ürün")]
        [Required(ErrorMessage = "Boş bırakılamaz!")]
        public int ProductID { get; set; }
        [Display(Name = "Numara")]
        [Required(ErrorMessage = "Boş bırakılamaz!")]
        public int Size { get; set; }
        [Display(Name = "Adet")]
        [Required(ErrorMessage = "Boş bırakılamaz!")]
        public int StockNumber { get; set; }
        public Product Product { get; set; }
    }
}
