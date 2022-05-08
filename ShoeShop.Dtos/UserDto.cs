using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShop.Dtos
{
    public class UserDto
    {
        public int ID { get; set; }

        
        [Display(Name = "Ad - Soyad")]
        public string FullName { get; set; }

        
        [Display(Name = "E-posta")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Adres")]
        
        public string Address { get; set; }

        
        [Display(Name = "Telefon Numarası")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        
        public string Role { get; set; }    
    }
}
