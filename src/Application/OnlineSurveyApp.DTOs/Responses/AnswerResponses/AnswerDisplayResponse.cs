using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurveyApp.DTOs.Responses.AnswerResponses
{
    public class AnswerDisplayResponse
    {
        public int Id { get; set; }
        public int? Evaluation { get; set; }
        public int? RedditiveId { get; set; }
        [Required]
        public int SurveyId { get; set; }
        [Required]
        public int QuestionId { get; set; }
        public int? OptionId { get; set; }
    }
}
