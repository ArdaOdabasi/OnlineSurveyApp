using Microsoft.EntityFrameworkCore;
using OnlineSurveyApp.Entities;
using OnlineSurveyApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurveyApp.Infrastructure.Repositories.OptionRepository
{
    public class EFOptionRepository : IOptionRepository
    {
        private readonly OnlineSurveyDbContext onlineSurveyDbContext;

        public EFOptionRepository(OnlineSurveyDbContext onlineSurveyDbContext)
        {
            this.onlineSurveyDbContext = onlineSurveyDbContext;
        }

        public void Create(Option entity)
        {
            onlineSurveyDbContext.Options.Add(entity);
            onlineSurveyDbContext.SaveChangesAsync();
        }

        public async Task CreateAsync(Option entity)
        {
            await onlineSurveyDbContext.Options.AddAsync(entity);
            await onlineSurveyDbContext.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var deletingOption = onlineSurveyDbContext.Options.Find(id);
            onlineSurveyDbContext.Options.Remove(deletingOption);
            onlineSurveyDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var deletingOption = await onlineSurveyDbContext.Options.FindAsync(id);
            onlineSurveyDbContext.Options.Remove(deletingOption);
            await onlineSurveyDbContext.SaveChangesAsync();
        }

        public Option? Get(int id)
        {
            return onlineSurveyDbContext.Options.SingleOrDefault(o => o.Id == id);
        }

        public async Task<Option?> GetAsync(int id)
        {
            return await onlineSurveyDbContext.Options.SingleOrDefaultAsync(o => o.Id == id);
        }

        public IList<Option?> GetAll()
        {
            return onlineSurveyDbContext.Options.ToList();
        }

        public async Task<IList<Option?>> GetAllAsync()
        {
            return await onlineSurveyDbContext.Options.ToListAsync();
        }

        public void Update(Option entity)
        {
            onlineSurveyDbContext.Options.Update(entity);
            onlineSurveyDbContext.SaveChanges();
        }

        public async Task UpdateAsync(Option entity)
        {
            onlineSurveyDbContext.Options.Update(entity);
            await onlineSurveyDbContext.SaveChangesAsync();
        }

        public async Task<bool> IsExistsAsync(int id)
        {
            return await onlineSurveyDbContext.Options.AnyAsync(o => o.Id == id);
        }

        public async Task<IEnumerable<Option>> GetOptionsByQuestionAsync(int questionId)
        {
            return await onlineSurveyDbContext.Options.AsNoTracking()
                                                      .Where(c => c.QuestionId == questionId)
                                                      .ToListAsync();
        }
    }
}
