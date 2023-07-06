using AutoMapper;
using OnlineSurveyApp.DTOs.Requests.AnswerRequests;
using OnlineSurveyApp.DTOs.Requests.OptionRequests;
using OnlineSurveyApp.DTOs.Responses.AnswerResponses;
using OnlineSurveyApp.Infrastructure.Repositories.AnswerRepository;
using OnlineSurveyApp.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurveyApp.Services.AnswerService
{
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerRepository _repository;
        private readonly IMapper _mapper;

        public AnswerService(IAnswerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> AnswerIsExistsAsync(int answerId)
        {
            return await _repository.IsExistsAsync(answerId);
        }

        public async Task CreateAnswerAsync(CreateNewAnswerRequest createNewAnswerRequest)
        {
            var answer = _mapper.ConvertCreateRequestToAnswer(createNewAnswerRequest);
            await _repository.CreateAsync(answer);
        }

        public async Task DeleteAsync(int answerId)
        {
            await _repository.DeleteAsync(answerId);
        }

        public async Task<IEnumerable<AnswerDisplayResponse>> GetAllAnswersAsync()
        {
            var answers = await _repository.GetAllAsync();
            var responses = answers.ConvertAnswersToDisplayResponses(_mapper);
            return responses;
        }

        public async Task<AnswerDisplayResponse> GetAnswerByIdAsync(int answerId)
        {
            var answer = await _repository.GetAsync(answerId);
            var response = answer.ConvertAnswerToDisplayResponse(_mapper);
            return response;
        }

        public async Task<IEnumerable<AnswerDisplayResponse>> GetAnswersBySurveyAsync(int surveyId)
        {
            var answers = await _repository.GetAnswersBySurveyAsync(surveyId);
            var response = answers.ConvertAnswersToDisplayResponses(_mapper);
            return response;
        }

        public async Task UpdateAnswerAsync(UpdateAnswerRequest updateAnswerRequest)
        {
            var answer = _mapper.ConvertUpdateRequestToAnswer(updateAnswerRequest);
            await _repository.UpdateAsync(answer);
        }
    }
}
