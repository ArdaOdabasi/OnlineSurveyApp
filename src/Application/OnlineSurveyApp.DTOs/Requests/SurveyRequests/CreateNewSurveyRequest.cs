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
        [Required(ErrorMessage = "Anket Başlığı Boş Bırakılmamalıdır!")]
        [MinLength(3, ErrorMessage = "Anket Başlığı En Az 3 Harften Oluşmak Zorundadır!")]
        public string Title { get; set; } = string.Empty;
        [Required(ErrorMessage = "Anket Açıklaması Boş Bırakılmamalıdır!")]
        [MinLength(3, ErrorMessage = "Anket Açıklaması En Az 3 Harften Oluşmak Zorundadır!")]
        public string Explanation { get; set; } = string.Empty;
        [Required(ErrorMessage = "Anket Oluşturulma Tarihi Boş Bırakılamaz!")]
        public DateTime CreationDate { get; set; }
        [Required(ErrorMessage = "Aktiflik Alanı Boş Bırakılmamalıdır!")]
        public bool Active { get; set; }
        public int? ConstituentId { get; set; }
    }
}
