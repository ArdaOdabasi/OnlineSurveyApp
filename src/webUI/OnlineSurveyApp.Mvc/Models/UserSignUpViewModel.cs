using System.ComponentModel.DataAnnotations;

namespace OnlineSurveyApp.Mvc.Models
{
    public class UserSignUpViewModel
    {
        [Required(ErrorMessage = "Kullanıcı Adı Boş Olamaz!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Ad Boş Olamaz!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Soyad Boş Olamaz!")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Şifre Boş Olamaz!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Rol Boş Olamaz!")]
        [DataType(DataType.Password)]
        public string Role { get; set; }
    }
}
