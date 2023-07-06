using AutoMapper;
using OnlineSurveyApp.DTOs.Requests.OptionRequests;
using OnlineSurveyApp.DTOs.Requests.QuestionRequests;
using OnlineSurveyApp.DTOs.Responses.OptionResponses;
using OnlineSurveyApp.Entities;
using OnlineSurveyApp.Infrastructure.Repositories.OptionRepository;
using OnlineSurveyApp.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurveyApp.Services.OptionService
{
    public class OptionService : IOptionService
    {
        private readonly IOptionRepository _repository;
        private readonly IMapper _mapper;

        public OptionService(IOptionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateOptionAsync(CreateNewOptionRequest createNewOptionRequest)
        {
            var option = _mapper.ConvertCreateRequestToOption(createNewOptionRequest);
            await _repository.CreateAsync(option);
        }

        public async Task DeleteAsync(int optionId)
        {
            await _repository.DeleteAsync(optionId);
        }

        public async Task<IEnumerable<OptionDisplayResponse>> GetAllOptionsAsync()
        {
            var options = await _repository.GetAllAsync();
            var responses = options.ConvertOptionsToDisplayResponses(_mapper);
            return responses;
        }

        public async Task<OptionDisplayResponse> GetOptionByIdAsync(int optionId)
        {
            var option = await _repository.GetAsync(optionId);
            var response = option.ConvertOptionToDisplayResponse(_mapper);
            return response;
        }

        public async Task<IEnumerable<OptionDisplayResponse>> GetOptionsByQuestionAsync(int questionId)
        {
            var options = await _repository.GetOptionsByQuestionAsync(questionId);
            var response = options.ConvertOptionsToDisplayResponses(_mapper);
            return response;
        }

        public async Task<bool> OptionIsExistsAsync(int optionId)
        {
            return await _repository.IsExistsAsync(optionId);
        }

        public async Task UpdateOptionAsync(UpdateOptionRequest updateOptionRequest)
        {
            var option = _mapper.ConvertUpdateRequestToOption(updateOptionRequest);
            await _repository.UpdateAsync(option);
        }
    }
}
