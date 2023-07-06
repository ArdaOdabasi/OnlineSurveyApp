using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurveyApp.DTOs.Requests.AnswerRequests
{
    public class UpdateAnswerRequest
    {
        public int Id { get; set; }
        [Range(1, 10, ErrorMessage = "Değerlendirme 1 ile 10 arasında olmalıdır!")]
        public int? Evaluation { get; set; }
        public int? RedditiveId { get; set; }
        public int? SurveyId { get; set; }
        public int? QuestionId { get; set; }
        public int? OptionId { get; set; }
    }
}
