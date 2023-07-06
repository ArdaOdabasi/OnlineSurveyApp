using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurveyApp.DTOs.Responses.OptionResponses
{
    public class OptionDisplayResponse
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; } = string.Empty;
        public int? QuestionId { get; set; }
    }
}
