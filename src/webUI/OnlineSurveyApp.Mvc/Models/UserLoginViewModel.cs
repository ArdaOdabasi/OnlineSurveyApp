using System.ComponentModel.DataAnnotations;

namespace OnlineSurveyApp.Mvc.Models
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "Kullanıcı Adı Boş Olamaz!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Şifre Boş Olamaz!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
