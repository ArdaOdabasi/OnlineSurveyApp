using AutoMapper;
using OnlineSurveyApp.DTOs.Requests.SurveyRequests;
using OnlineSurveyApp.DTOs.Requests.UserRequests;
using OnlineSurveyApp.DTOs.Responses.SurveyResponses;
using OnlineSurveyApp.Entities;
using OnlineSurveyApp.Infrastructure.Data;
using OnlineSurveyApp.Infrastructure.Repositories.SurveyRepository;
using OnlineSurveyApp.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurveyApp.Services.SurveyService
{
    public class SurveyService : ISurveyService
    {
        private readonly ISurveyRepository _repository;
        private readonly IMapper _mapper;

        public SurveyService(ISurveyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
   
        public async Task CreateSurveyAsync(CreateNewSurveyRequest createNewSurveyRequest)
        {
            var survey = _mapper.ConvertCreateRequestToSurvey(createNewSurveyRequest);
            await _repository.CreateAsync(survey);
        }

        public async Task<int> CreateSurveyAndReturnSurveyIdAsync(CreateNewSurveyRequest createNewSurveyRequest)
        {
            var survey = _mapper.ConvertCreateRequestToSurvey(createNewSurveyRequest);
            await _repository.CreateAsync(survey);
            return survey.Id;
        }

        public async Task DeleteAsync(int surveyId)
        {
            await _repository.DeleteAsync(surveyId);
        }

        public async Task<IEnumerable<SurveyDisplayResponse>> GetAllSurveysAsync()
        {
            var surveys = await _repository.GetAllAsync();
            var responses = surveys.ConvertSurveysToDisplayResponses(_mapper);
            return responses;
        }

        public async Task<SurveyDisplayResponse> GetSurveyByIdAsync(int surveyId)
        {
            var survey = await _repository.GetAsync(surveyId);
            var response = survey.ConvertSurveyToDisplayResponse(_mapper);
            return response;
        }

        public async Task<bool> SurveyIsExistsAsync(int surveyId)
        {
            return await _repository.IsExistsAsync(surveyId);
        }

        public async Task UpdateSurveyAsync(UpdateSurveyRequest updateSurveyRequest)
        {
            var survey = _mapper.ConvertUpdateRequestToSurvey(updateSurveyRequest);
            await _repository.UpdateAsync(survey);
        }

        public async Task<IEnumerable<SurveyDisplayResponse>> GetSurveysByConstituentAsync(int constituentId)
        {
            var surveys = await _repository.GetSurveysByConstituentAsync(constituentId);
            var responses = surveys.ConvertSurveysToDisplayResponses(_mapper);
            return responses;
        }
    }
}
