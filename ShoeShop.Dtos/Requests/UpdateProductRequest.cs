using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShop.Dtos.Requests
{
    public class UpdateProductRequest
    {
        public int ID { get; set; } 
        [Display(Name = "Marka")]
        public int BrandID { get; set; }
        [Display(Name = "Kategori")]
        public int CategoryID { get; set; }
        [Display(Name = "Renk")]
        public int ColorID { get; set; }
        [Display(Name = "Cinsiyet")]
        public int GenderID { get; set; }
        [Required(ErrorMessage = "Please Enter a Poduct Name!")]
        public string Name { get; set; }
        [Display(Name = "Numara")]
        public double Size { get; set; }
        [Display(Name = "Fotoğraf Linki")]
        public string ImageUrl { get; set; }
        [Display(Name = "Fotoğraf Linki 2")]
        public string ImageUrl2 { get; set; }
        [Display(Name = "Fotoğraf Linki 3")]
        public string ImageUrl3 { get; set; }
        [Display(Name = "Fotoğraf Linki 4")]
        public string ImageUrl4 { get; set; }
        [Display(Name = "Fiyat")]
        public double Price { get; set; }
        [Display(Name = "İndirim Miktarı (0.0 - 1.00)")]
        public double? Discount { get; set; }
        public bool IsActive { get; set; } = true;
        public string Material { get; set; }
        public DateTime? ModifiedDate { get; set; }

    }
}
