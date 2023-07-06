using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurveyApp.Entities
{
    public class Question : IEntity
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; } = string.Empty;    
        [Required]
        public bool ScoringRequirement { get; set; }
        public Survey? Survey { get; set; }
        public int? SurveyId { get; set; }
        public ICollection<Option>? Options { get; set; }
        public ICollection<Answer>? Answers { get; set; }
    }
}
