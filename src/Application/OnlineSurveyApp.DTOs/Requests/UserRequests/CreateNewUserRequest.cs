using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurveyApp.DTOs.Requests.UserRequests
{
    public class CreateNewUserRequest
    {
        [Required(ErrorMessage = "Ad Alanı Boş Bırakılmamalıdır!")]
        [MinLength(2, ErrorMessage = "Ad Alanı En Az 2 Harften Oluşmak Zorundadır!")]
        public string FirstName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Soyad Alanı Boş Bırakılmamalıdır!")]
        [MinLength(2, ErrorMessage = "Soyad Alanı En Az 2 Harften Oluşmak Zorundadır!")]
        public string LastName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Kullanıcı Adı Alanı Boş Bırakılmamalıdır!")]
        [MinLength(3, ErrorMessage = "Kullanıcı Adı Alanı En Az 3 Harften Oluşmak Zorundadır!")]
        public string UserName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Şifre Alanı Boş Bırakılmamalıdır!")]
        [MinLength(6, ErrorMessage = "Şifre Alanı En Az 6 Harften Oluşmak Zorundadır!")]
        public string Password { get; set; } = string.Empty;
        [Required(ErrorMessage = "Rol Alanı Boş Bırakılmamalıdır!")]
        [RegularExpression("^(Anketör|Admin|Ziyaretçi)$", ErrorMessage = "Geçersiz Rol!")]
        public string Role { get; set; } = string.Empty;
    }
}
