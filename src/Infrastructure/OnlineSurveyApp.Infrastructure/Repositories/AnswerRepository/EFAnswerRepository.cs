using Microsoft.EntityFrameworkCore;
using OnlineSurveyApp.Entities;
using OnlineSurveyApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurveyApp.Infrastructure.Repositories.AnswerRepository
{
    public class EFAnswerRepository : IAnswerRepository
    {
        private readonly OnlineSurveyDbContext onlineSurveyDbContext;

        public EFAnswerRepository(OnlineSurveyDbContext onlineSurveyDbContext)
        {
            this.onlineSurveyDbContext = onlineSurveyDbContext;
        }

        public void Create(Answer entity)
        {
            onlineSurveyDbContext.Answers.Add(entity);
            onlineSurveyDbContext.SaveChangesAsync();
        }

        public async Task CreateAsync(Answer entity)
        {
            await onlineSurveyDbContext.Answers.AddAsync(entity);
            await onlineSurveyDbContext.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var deletingAnswer = onlineSurveyDbContext.Answers.Find(id);
            onlineSurveyDbContext.Answers.Remove(deletingAnswer);
            onlineSurveyDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var deletingAnswer = await onlineSurveyDbContext.Answers.FindAsync(id);
            onlineSurveyDbContext.Answers.Remove(deletingAnswer);
            await onlineSurveyDbContext.SaveChangesAsync();
        }

        public Answer? Get(int id)
        {
            return onlineSurveyDbContext.Answers.SingleOrDefault(a => a.Id == id);
        }

        public async Task<Answer?> GetAsync(int id)
        {
            return await onlineSurveyDbContext.Answers.SingleOrDefaultAsync(a => a.Id == id);
        }

        public IList<Answer?> GetAll()
        {
            return onlineSurveyDbContext.Answers.ToList();
        }

        public async Task<IList<Answer?>> GetAllAsync()
        {
            return await onlineSurveyDbContext.Answers.ToListAsync();
        }

        public void Update(Answer entity)
        {
            onlineSurveyDbContext.Answers.Update(entity);
            onlineSurveyDbContext.SaveChanges();
        }

        public async Task UpdateAsync(Answer entity)
        {
            onlineSurveyDbContext.Answers.Update(entity);
            await onlineSurveyDbContext.SaveChangesAsync();
        }

        public async Task<bool> IsExistsAsync(int id)
        {
            return await onlineSurveyDbContext.Answers.AnyAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Answer>> GetAnswersBySurveyAsync(int surveyId)
        {
            return await onlineSurveyDbContext.Answers.AsNoTracking()
                                                      .Where(c => c.SurveyId == surveyId)
                                                      .ToListAsync();
        }
    }
}
