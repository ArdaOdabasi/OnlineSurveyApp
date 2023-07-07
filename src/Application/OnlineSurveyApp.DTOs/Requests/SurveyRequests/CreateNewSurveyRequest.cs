using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurveyApp.DTOs.Requests.SurveyRequests
{
    public class CreateNewSurveyRequest
    {
        [Required(ErrorMessage = "Anket Başlığı Alanı Boş Bırakılmamalıdır!")]
        [MinLength(3, ErrorMessage = "Anket Başlığı Alanı En Az 3 Harften Oluşmak Zorundadır!")]
        public string Title { get; set; } = string.Empty;
        [Required(ErrorMessage = "Anket Açıklaması Alanı Boş Bırakılmamalıdır!")]
        [MinLength(3, ErrorMessage = "Anket Açıklaması Alanı En Az 3 Harften Oluşmak Zorundadır!")]
        public string Explanation { get; set; } = string.Empty;
        [Required(ErrorMessage = "Anket Oluşturulma Tarihi Alanı Boş Bırakılamaz!")]
        public DateTime CreationDate { get; set; }
        [Required(ErrorMessage = "Aktiflik Alanı Boş Bırakılmamalıdır!")]
        public bool Active { get; set; }
        [Required(ErrorMessage = "Constituent Id Alanı Boş Bırakılmamalıdır!")]
        public int ConstituentId { get; set; }
    }
}
