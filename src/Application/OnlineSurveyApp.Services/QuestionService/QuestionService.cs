using AutoMapper;
using OnlineSurveyApp.DTOs.Requests.QuestionRequests;
using OnlineSurveyApp.DTOs.Responses.QuestionResponses;
using OnlineSurveyApp.Entities;
using OnlineSurveyApp.Infrastructure.Repositories.QuestionRepository;
using OnlineSurveyApp.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurveyApp.Services.QuestionService
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _repository;
        private readonly IMapper _mapper;

        public QuestionService(IQuestionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateQuestionAsync(CreateNewQuestionRequest createNewQuestionRequest)
        {
            var question = _mapper.ConvertCreateRequestToQuestion(createNewQuestionRequest);
            await _repository.CreateAsync(question);
        }

        public async Task DeleteAsync(int questionId)
        {
            await _repository.DeleteAsync(questionId);
        }

        public async Task<IEnumerable<QuestionDisplayResponse>> GetAllQuestionsAsync()
        {
            var questions = await _repository.GetAllAsync();
            var responses = questions.ConvertQuestionsToDisplayResponses(_mapper);
            return responses;
        }

        public async Task<QuestionDisplayResponse> GetQuestionByIdAsync(int questionId)
        {
            var question = await _repository.GetAsync(questionId);
            var response = question.ConvertQuestionToDisplayResponse(_mapper);
            return response;
        }

        public async Task<IEnumerable<QuestionDisplayResponse>> GetQuestionsBySurveyAsync(int surveyId)
        {
            var questions = await _repository.GetQuestionsBySurveyAsync(surveyId);
            var response = questions.ConvertQuestionsToDisplayResponses(_mapper);
            return response;
        }

        public async Task<bool> QuestionIsExistsAsync(int questionId)
        {
            return await _repository.IsExistsAsync(questionId);
        }

        public async Task UpdateQuestionAsync(UpdateQuestionRequest updateQuestionRequest)
        {
            var question = _mapper.ConvertUpdateRequestToQuestion(updateQuestionRequest);
            await _repository.UpdateAsync(question);
        }
    }
}
