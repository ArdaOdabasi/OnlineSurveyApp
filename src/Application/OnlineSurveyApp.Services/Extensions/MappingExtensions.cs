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

namespace OnlineSurveyApp.Services.Extensions
{
    public static class MappingExtensions
    {
        public static IEnumerable<AnswerDisplayResponse> ConvertAnswersToDisplayResponses(this IEnumerable<Answer> answers, IMapper mapper)
        {
            return mapper.Map<IEnumerable<AnswerDisplayResponse>>(answers);
        }

        public static AnswerDisplayResponse ConvertAnswerToDisplayResponse(this Answer answer, IMapper mapper)
        {
            return mapper.Map<AnswerDisplayResponse>(answer);
        }

        public static Answer ConvertCreateRequestToAnswer(this IMapper mapper, CreateNewAnswerRequest createNewAnswerRequest)
        {
            return mapper.Map<Answer>(createNewAnswerRequest);
        }

        public static Answer ConvertUpdateRequestToAnswer(this IMapper mapper, UpdateAnswerRequest updateAnswerRequest)
        {
            return mapper.Map<Answer>(updateAnswerRequest);
        }

        public static UpdateAnswerRequest ConvertAnswerToUpdateRequest(this IMapper mapper, Answer answer)
        {
            return mapper.Map<UpdateAnswerRequest>(answer);
        }

        public static IEnumerable<OptionDisplayResponse> ConvertOptionsToDisplayResponses(this IEnumerable<Option> options, IMapper mapper)
        {
            return mapper.Map<IEnumerable<OptionDisplayResponse>>(options);
        }

        public static OptionDisplayResponse ConvertOptionToDisplayResponse(this Option option, IMapper mapper)
        {
            return mapper.Map<OptionDisplayResponse>(option);
        }

        public static Option ConvertCreateRequestToOption(this IMapper mapper, CreateNewOptionRequest createNewOptionRequest)
        {
            return mapper.Map<Option>(createNewOptionRequest);
        }

        public static Option ConvertUpdateRequestToOption(this IMapper mapper, UpdateOptionRequest updateOptionRequest)
        {
            return mapper.Map<Option>(updateOptionRequest);
        }

        public static UpdateOptionRequest ConvertOptionToUpdateRequest(this IMapper mapper, Option option)
        {
            return mapper.Map<UpdateOptionRequest>(option);
        }

        public static IEnumerable<QuestionDisplayResponse> ConvertQuestionsToDisplayResponses(this IEnumerable<Question> questions, IMapper mapper)
        {
            return mapper.Map<IEnumerable<QuestionDisplayResponse>>(questions);
        }

        public static QuestionDisplayResponse ConvertQuestionToDisplayResponse(this Question question, IMapper mapper)
        {
            return mapper.Map<QuestionDisplayResponse>(question);
        }

        public static Question ConvertCreateRequestToQuestion(this IMapper mapper, CreateNewQuestionRequest createNewQuestionRequest)
        {
            return mapper.Map<Question>(createNewQuestionRequest);
        }

        public static Question ConvertUpdateRequestToQuestion(this IMapper mapper, UpdateQuestionRequest updateQuestionRequest)
        {
            return mapper.Map<Question>(updateQuestionRequest);
        }

        public static UpdateQuestionRequest ConvertQuestionToUpdateRequest(this IMapper mapper, Question question)
        {
            return mapper.Map<UpdateQuestionRequest>(question);
        }

        public static IEnumerable<SurveyDisplayResponse> ConvertSurveysToDisplayResponses(this IEnumerable<Survey> surveys, IMapper mapper)
        {
            return mapper.Map<IEnumerable<SurveyDisplayResponse>>(surveys);
        }

        public static SurveyDisplayResponse ConvertSurveyToDisplayResponse(this Survey survey, IMapper mapper)
        {
            return mapper.Map<SurveyDisplayResponse>(survey);
        }

        public static Survey ConvertCreateRequestToSurvey(this IMapper mapper, CreateNewSurveyRequest createNewSurveyRequest)
        {
            return mapper.Map<Survey>(createNewSurveyRequest);
        }

        public static Survey ConvertUpdateRequestToSurvey(this IMapper mapper, UpdateSurveyRequest updateSurveyRequest)
        {
            return mapper.Map<Survey>(updateSurveyRequest);
        }

        public static UpdateSurveyRequest ConvertSurveyToUpdateRequest(this IMapper mapper, Survey survey)
        {
            return mapper.Map<UpdateSurveyRequest>(survey);
        }

        public static IEnumerable<UserDisplayResponse> ConvertUsersToDisplayResponses(this IEnumerable<User> users, IMapper mapper)
        {
            return mapper.Map<IEnumerable<UserDisplayResponse>>(users);
        }

        public static UserDisplayResponse ConvertUserToDisplayResponse(this User user, IMapper mapper)
        {
            return mapper.Map<UserDisplayResponse>(user);
        }

        public static User ConvertCreateRequestToUser(this IMapper mapper, CreateNewUserRequest createNewUserRequest)
        {
            return mapper.Map<User>(createNewUserRequest);
        }

        public static User ConvertUpdateRequestToUser(this IMapper mapper, UpdateUserRequest updateUserRequest)
        {
            return mapper.Map<User>(updateUserRequest);
        }

        public static UpdateUserRequest ConvertUserToUpdateRequest(this IMapper mapper, User user)
        {
            return mapper.Map<UpdateUserRequest>(user);
        }
    }
}
