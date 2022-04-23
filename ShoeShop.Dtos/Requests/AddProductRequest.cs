using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoeShop.Entities;
using ShoeShop.Entities.Concrete;

namespace ShoeShop.Dtos.Requests
{
    public class AddProductRequest
    {
        //public int ID { get; set; }
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
        [Display(Name = "Fiyat")]
        public double Price { get; set; }
        [Display(Name = "İndirim Miktarı (0.0 - 1.00)")]
        public double? Discount { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
