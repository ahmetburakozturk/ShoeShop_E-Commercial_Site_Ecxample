using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoeShop.Entities.Abstract;
using ShoeShop.Entities.Concrete;

namespace ShoeShop.Entities
{
    public class Product:IEntity
    {
        [Key]
        [Display(Name ="Ürün Kodu")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz!")]
        [Display(Name = "Marka")]
        public int BrandID { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz!")]
        [Display(Name = "Kategori")]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz!")]
        [Display(Name = "Renk")]
        public int ColorID { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz!")]
        [Display(Name = "Cinsiyet")]
        public int GenderID { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz!")]
        [Display(Name = "Model Adı")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz!")]
        [Display(Name = "Numara")]
        public double Size { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz!")]
        [Display(Name = "Görsel 1")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz!")]
        [Display(Name = "Görsel 2")]
        public string? ImageUrl2 { get; set; }

        [Display(Name = "Görsel 3")]
        public string? ImageUrl3 { get; set; }

        [Display(Name = "Görsel 4")]
        public string? ImageUrl4 { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz!")]
        [Display(Name = "Fiyat")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz!")]
        [Display(Name = "İndirim Oranı")]
        public double? Discount { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz!")]
        [Display(Name = "Dış Materyal")]
        public string? Material { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; }

        [Display(Name = "Ürün Listelensin Mi?")]
        public bool IsActive { get; set; }
        public Brand Brand { get; set; }
        public Category Category { get; set; }
        public Color Color { get; set; }
        public Gender Gender { get; set; }

        public ICollection<Stock> Stocks { get; set; }
    }
}
