using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurveyApp.DTOs.Responses.SurveyResponses
{
    public class SurveyDisplayResponse
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Explanation { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        public bool Active { get; set; }
        public int? ConstituentId { get; set; }
    }
}
