using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoeShop.Dtos.Abstract;

namespace ShoeShop.Dtos.Concrete
{
    public class BrandDto : IDto
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz'")]
        [MinLength(3, ErrorMessage = "En az 3 karakter olmalıdır!")]
        [Display(Name = "Marka Adı")]
        public string Name { get; set; }
    }
}
