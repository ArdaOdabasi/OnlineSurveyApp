using AutoMapper;
using OnlineSurveyApp.DTOs.Requests.AnswerRequests;
using OnlineSurveyApp.DTOs.Requests.OptionRequests;
using OnlineSurveyApp.DTOs.Requests.QuestionRequests;
using OnlineSurveyApp.DTOs.Requests.SurveyRequests;
using OnlineSurveyApp.DTOs.Requests.UserRequests;
using OnlineSurveyApp.DTOs.Responses.AnswerResponses;
using OnlineSurveyApp.DTOs.Responses.OptionResponses;
using OnlineSurveyApp.DTOs.Responses.QuestionResponses;
using OnlineSurveyApp.DTOs.Responses.SurveyResponses;
using OnlineSurveyApp.DTOs.Responses.UserResponses;
using OnlineSurveyApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurveyApp.Services.Mappings
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Survey, SurveyDisplayResponse>();
            CreateMap<Question, QuestionDisplayResponse>();
            CreateMap<Option, OptionDisplayResponse>();
            CreateMap<Answer, AnswerDisplayResponse>();
            CreateMap<User, UserDisplayResponse>()
                                                  .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                                                  .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                                                  .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                                                  .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName));
            CreateMap<CreateNewSurveyRequest, Survey>();
            CreateMap<CreateNewQuestionRequest, Question>();
            CreateMap<CreateNewOptionRequest, Option>();
            CreateMap<CreateNewAnswerRequest, Answer>();
            CreateMap<CreateNewUserRequest, User>();
            CreateMap<UpdateSurveyRequest, Survey>().ReverseMap();
            CreateMap<UpdateQuestionRequest, Question>().ReverseMap();
            CreateMap<UpdateOptionRequest, Option>().ReverseMap();
            CreateMap<UpdateAnswerRequest, Answer>().ReverseMap();
            CreateMap<UpdateUserRequest, User>().ReverseMap();
        }
    }
}
