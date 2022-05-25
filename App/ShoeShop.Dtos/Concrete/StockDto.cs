using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;

namespace ShoeShop.Dtos
{
    public class StockDto
    {
        public int StockID { get; set; }

        [Display(Name = "Ürün")]
        [Required(ErrorMessage = "Boş bırakılamaz!")]
        public int ProductID { get; set; }

        [Display(Name = "Numara")]
        [Required(ErrorMessage = "Boş bırakılamaz!")]
        public string SizeName { get; set; }

        [Display(Name = "Adet")]
        [Required(ErrorMessage = "Boş bırakılamaz!")]
        public int StockNumber { get; set; }
    }
}
