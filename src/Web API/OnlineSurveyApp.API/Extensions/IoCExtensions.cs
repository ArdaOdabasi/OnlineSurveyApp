using Microsoft.AspNetCore.Hosting;
using OnlineSurveyApp.Infrastructure.Data;
using OnlineSurveyApp.Infrastructure.Repositories.AnswerRepository;
using OnlineSurveyApp.Infrastructure.Repositories.OptionRepository;
using OnlineSurveyApp.Infrastructure.Repositories.QuestionRepository;
using OnlineSurveyApp.Infrastructure.Repositories.SurveyRepository;
using OnlineSurveyApp.Infrastructure.Repositories.UserRepository;
using OnlineSurveyApp.Services.AnswerService;
using OnlineSurveyApp.Services.Mappings;
using OnlineSurveyApp.Services.OptionService;
using OnlineSurveyApp.Services.QuestionService;
using OnlineSurveyApp.Services.SurveyService;
using OnlineSurveyApp.Services.UserService;

namespace OnlineSurveyApp.API.Extensions
{
    public static class IoCExtensions
    {
        public static IServiceCollection AddInjections(this IServiceCollection services)
        {
            services.AddScoped<IOptionService, OptionService>();
            services.AddScoped<IOptionRepository, EFOptionRepository>();
            services.AddScoped<IAnswerService, AnswerService>();
            services.AddScoped<IAnswerRepository, EFAnswerRepository>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IQuestionRepository, EFQuestionRepository>();
            services.AddScoped<ISurveyService, SurveyService>();
            services.AddScoped<ISurveyRepository, EFSurveyRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, EFUserRepository>();
            services.AddDbContext<OnlineSurveyDbContext>();
            services.AddAutoMapper(typeof(MapProfile));

            return services;
        }
    }
}
