﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurveyApp.DTOs.Requests.QuestionRequests
{
    public class CreateNewQuestionRequest
    {
        [Required(ErrorMessage = "Soru Yazısı Boş Bırakılmamalıdır!")]
        [MinLength(3, ErrorMessage = "Soru Yazısı En Az 3 Harften Oluşmak Zorundadır!")]
        public string Text { get; set; } = string.Empty;      
        [Required(ErrorMessage = "Puanlandırma Gereksinimi Alanı Boş Bırakılmamalıdır!")]
        public bool ScoringRequirement { get; set; }
        public int? SurveyId { get; set; }
    }
}
