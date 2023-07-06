using Microsoft.EntityFrameworkCore;
using OnlineSurveyApp.Entities;
using OnlineSurveyApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurveyApp.Infrastructure.Repositories.QuestionRepository
{
    public class EFQuestionRepository : IQuestionRepository
    {
        private readonly OnlineSurveyDbContext onlineSurveyDbContext;

        public EFQuestionRepository(OnlineSurveyDbContext onlineSurveyDbContext)
        {
            this.onlineSurveyDbContext = onlineSurveyDbContext;
        }

        public void Create(Question entity)
        {
            onlineSurveyDbContext.Questions.Add(entity);
            onlineSurveyDbContext.SaveChangesAsync();
        }

        public async Task CreateAsync(Question entity)
        {
            await onlineSurveyDbContext.Questions.AddAsync(entity);
            await onlineSurveyDbContext.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var deletingQuestion = onlineSurveyDbContext.Questions.Find(id);
            onlineSurveyDbContext.Questions.Remove(deletingQuestion);
            onlineSurveyDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var deletingQuestion = await onlineSurveyDbContext.Questions.FindAsync(id);
            onlineSurveyDbContext.Questions.Remove(deletingQuestion);
            await onlineSurveyDbContext.SaveChangesAsync();
        }

        public Question? Get(int id)
        {
            return onlineSurveyDbContext.Questions.SingleOrDefault(q => q.Id == id);
        }

        public async Task<Question?> GetAsync(int id)
        {
            return await onlineSurveyDbContext.Questions.SingleOrDefaultAsync(q => q.Id == id);
        }

        public IList<Question?> GetAll()
        {
            return onlineSurveyDbContext.Questions.ToList();
        }

        public async Task<IList<Question?>> GetAllAsync()
        {
            return await onlineSurveyDbContext.Questions.ToListAsync();
        }

        public void Update(Question entity)
        {
            onlineSurveyDbContext.Questions.Update(entity);
            onlineSurveyDbContext.SaveChanges();
        }

        public async Task UpdateAsync(Question entity)
        {
            onlineSurveyDbContext.Questions.Update(entity);
            await onlineSurveyDbContext.SaveChangesAsync();
        }

        public async Task<bool> IsExistsAsync(int id)
        {
            return await onlineSurveyDbContext.Questions.AnyAsync(q => q.Id == id);
        }

        public async Task<IEnumerable<Question>> GetQuestionsBySurveyAsync(int surveyId)
        {
            return await onlineSurveyDbContext.Questions.AsNoTracking().Where(c => c.SurveyId == surveyId).ToListAsync();
        }
    }
}
