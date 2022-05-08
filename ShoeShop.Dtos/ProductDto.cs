using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoeShop.Entities;
using ShoeShop.Entities.Concrete;

namespace ShoeShop.Dtos
{
    public class ProductDto
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz!")]
        [Display(Name = "Marka *")]
        public int BrandID { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz!")]
        [Display(Name = "Kategori *")]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz!")]
        [Display(Name = "Renk *")]
        public int ColorID { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz!")]
        [Display(Name = "Cinsiyet *")]
        public int GenderID { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz!")]
        [Display(Name = "Model Adı *")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz!")]
        [Display(Name = "Numara *")]
        public double Size { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz!")]
        [Display(Name = "Görsel 1 *")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz!")]
        [Display(Name = "Görsel 2 *")]
        public string? ImageUrl2 { get; set; }

        [Display(Name = "Görsel 3")]
        public string? ImageUrl3 { get; set; }

        [Display(Name = "Görsel 4")]
        public string? ImageUrl4 { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz!")]
        [Display(Name = "Fiyat *")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz!")]
        [Display(Name = "İndirim Oranı (%) *")]
        public double? Discount { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz!")]
        [Display(Name = "Dış Materyal *")]
        public string? Material { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; }

        [Display(Name = "Ürün listelensin mi *")]
        public bool IsActive { get; set; }

        public string SizeNumber { get; set; }
        public string BrandName { get; set; }
        public string CategoryName { get; set; }
        public string GenderName { get; set; }
        public string ColorName { get; set; }
        public int ShoeSize { get; set; }
        public int StockNumber { get; set; }
    }
}
