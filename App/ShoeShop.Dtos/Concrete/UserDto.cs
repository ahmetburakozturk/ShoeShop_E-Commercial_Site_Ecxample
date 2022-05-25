using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoeShop.Dtos.Abstract;

namespace ShoeShop.Dtos
{
    public class UserDto : IDto
    {
        public int ID { get; set; }

        
        [Display(Name = "Ad - Soyad")]
        public string FullName { get; set; }

        
        [Display(Name = "E-posta")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "E-Mail boş bırakılamaz!")]
        public string Email { get; set; }

        
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre boş bırakılamaz!")]
        public string Password { get; set; }

        [Display(Name = "Adres")]

        public string Address { get; set; }

        
        [Display(Name = "Telefon Numarası")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        
        public string Role { get; set; }    

        public string oldPassword { get; set; }
    }
}
