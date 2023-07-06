using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurveyApp.DTOs.Requests.OptionRequests
{
    public class CreateNewOptionRequest
    {
        [Required(ErrorMessage = "Seçenek Yazısı Alanı Boş Bırakılmamalıdır!")]
        [MinLength(3, ErrorMessage = "Seçenek Yazısı Alanı En Az 3 Harften Oluşmak Zorundadır!")]
        public string Text { get; set; } = string.Empty;
        public int? QuestionId { get; set; }
    }
}
