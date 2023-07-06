using Microsoft.EntityFrameworkCore;
using OnlineSurveyApp.Entities;
using OnlineSurveyApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurveyApp.Infrastructure.Repositories.SurveyRepository
{
    public class EFSurveyRepository : ISurveyRepository
    {
        private readonly OnlineSurveyDbContext onlineSurveyDbContext;

        public EFSurveyRepository(OnlineSurveyDbContext onlineSurveyDbContext)
        {
            this.onlineSurveyDbContext = onlineSurveyDbContext;
        }

        public void Create(Survey entity)
        {
            onlineSurveyDbContext.Surveys.Add(entity);
            onlineSurveyDbContext.SaveChangesAsync();
        }

        public async Task CreateAsync(Survey entity)
        {
            await onlineSurveyDbContext.Surveys.AddAsync(entity);
            await onlineSurveyDbContext.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var deletingSurvey = onlineSurveyDbContext.Surveys.Find(id);
            onlineSurveyDbContext.Surveys.Remove(deletingSurvey);
            onlineSurveyDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var deletingSurvey = await onlineSurveyDbContext.Surveys.FindAsync(id);
            onlineSurveyDbContext.Surveys.Remove(deletingSurvey);
            await onlineSurveyDbContext.SaveChangesAsync();
        }

        public Survey? Get(int id)
        {
            return onlineSurveyDbContext.Surveys.SingleOrDefault(s => s.Id == id);
        }

        public async Task<Survey?> GetAsync(int id)
        {
            return await onlineSurveyDbContext.Surveys.SingleOrDefaultAsync(s => s.Id == id);
        }

        public IList<Survey?> GetAll()
        {
            return onlineSurveyDbContext.Surveys.ToList();
        }

        public async Task<IList<Survey?>> GetAllAsync()
        {
            return await onlineSurveyDbContext.Surveys.ToListAsync();
        }

        public void Update(Survey entity)
        {
            onlineSurveyDbContext.Surveys.Update(entity);
            onlineSurveyDbContext.SaveChanges();
        }

        public async Task UpdateAsync(Survey entity)
        {
            onlineSurveyDbContext.Surveys.Update(entity);
            await onlineSurveyDbContext.SaveChangesAsync();
        }

        public async Task<bool> IsExistsAsync(int id)
        {
            return await onlineSurveyDbContext.Surveys.AnyAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Survey>> GetActiveSurveysAsync()
        {
            return await onlineSurveyDbContext.Surveys.AsNoTracking()
                                                      .Where(s => s.Active == true)
                                                      .ToListAsync();
        }

        public async Task<IEnumerable<Survey>> GetPassiveSurveysAsync()
        {
            return await onlineSurveyDbContext.Surveys.AsNoTracking()
                                                      .Where(s => s.Active == false)
                                                      .ToListAsync();
        }

        public async Task<IEnumerable<Survey>> GetSurveysByConstituentAsync(int constituentId)
        {
            return await onlineSurveyDbContext.Surveys.AsNoTracking()
                                                      .Where(s => s.ConstituentId == constituentId)
                                                      .ToListAsync();
        }


        public async Task<IEnumerable<Survey>> GetActiveSurveysByConstituentAsync(int constituentId)
        {
            return await onlineSurveyDbContext.Surveys.AsNoTracking()
                                                      .Where(s => s.ConstituentId == constituentId && s.Active == true)
                                                      .ToListAsync();
        }


        public async Task<IEnumerable<Survey>> GetPassiveSurveysByConstituentAsync(int constituentId)
        {
            return await onlineSurveyDbContext.Surveys.AsNoTracking()
                                                      .Where(s => s.ConstituentId == constituentId && s.Active == false)
                                                      .ToListAsync();
        }
    }
}
