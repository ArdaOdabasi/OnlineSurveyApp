using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurveyApp.Entities
{
    public class Option : IEntity
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; } = string.Empty;
        public Question Question { get; set; }
        public int QuestionId { get; set; }
        public ICollection<Answer>? Answers { get; set; }
    }
}
