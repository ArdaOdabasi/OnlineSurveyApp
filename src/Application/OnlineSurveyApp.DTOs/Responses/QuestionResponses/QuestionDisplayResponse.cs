using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurveyApp.DTOs.Responses.QuestionResponses
{
    public class QuestionDisplayResponse
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; } = string.Empty;   
        [Required]
        public bool ScoringRequirement { get; set; }
        [Required]
        public int SurveyId { get; set; }
    }
}
