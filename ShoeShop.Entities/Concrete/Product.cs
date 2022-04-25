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
        public int ID { get; set; }
        public int BrandID { get; set; }
        public int CategoryID { get; set; }
        public int ColorID { get; set; }
        public int GenderID { get; set; }
        [Required(ErrorMessage = "Please Enter a Poduct Name!")]
        public string Name { get; set; }
        public double Size { get; set; }
        public string ImageUrl { get; set; }
        public string? ImageUrl2 { get; set; }
        public string? ImageUrl3 { get; set; }
        public string? ImageUrl4 { get; set; }
        public double Price { get; set; }
        public double? Discount { get; set; }
        public string? Material { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; }
        public bool? IsFavourited { get; set; }
        public bool IsActive { get; set; }
        public Brand Brand { get; set; }
        public Category Category { get; set; }
        public Color Color { get; set; }
        public Gender Gender { get; set; }
        
    }
}
