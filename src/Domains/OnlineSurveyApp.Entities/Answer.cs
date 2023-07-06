using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurveyApp.Entities
{
    public class Answer : IEntity
    {
        public int Id { get; set; }
        public int? Evaluation { get; set; }
        public User? Redditive { get; set; }
        public int? RedditiveId { get; set; }
        public Survey? Survey { get; set; }
        public int? SurveyId { get; set; }
        public Question? Question { get; set; }
        public int? QuestionId { get; set; }
        public Option? Option { get; set; }
        public int? OptionId { get; set; }     
    }
}
