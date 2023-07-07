using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurveyApp.Entities
{
    public class Survey : IEntity
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Explanation { get; set; } = string.Empty;
        [Required]
        public DateTime CreationDate { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        public User Constituent { get; set; }
        [Required]
        public int ConstituentId { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<Answer>? Answers { get; set; }
    }
}
