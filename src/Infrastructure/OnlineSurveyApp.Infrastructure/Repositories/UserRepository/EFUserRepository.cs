using Microsoft.EntityFrameworkCore;
using OnlineSurveyApp.Entities;
using OnlineSurveyApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurveyApp.Infrastructure.Repositories.UserRepository
{
    public class EFUserRepository : IUserRepository
    {
        private readonly OnlineSurveyDbContext onlineSurveyDbContext;

        public EFUserRepository(OnlineSurveyDbContext onlineSurveyDbContext)
        {
            this.onlineSurveyDbContext = onlineSurveyDbContext;
        }

        public void Create(User entity)
        {
            onlineSurveyDbContext.Users.Add(entity);
            onlineSurveyDbContext.SaveChangesAsync();
        }

        public async Task CreateAsync(User entity)
        {
            await onlineSurveyDbContext.Users.AddAsync(entity);
            await onlineSurveyDbContext.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var deletingUser = onlineSurveyDbContext.Users.Find(id);
            onlineSurveyDbContext.Users.Remove(deletingUser);
            onlineSurveyDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var deletingUser = await onlineSurveyDbContext.Users.FindAsync(id);
            onlineSurveyDbContext.Users.Remove(deletingUser);
            await onlineSurveyDbContext.SaveChangesAsync();
        }

        public User? Get(int id)
        {
            return onlineSurveyDbContext.Users.SingleOrDefault(u => u.Id == id);
        }

        public async Task<User?> GetAsync(int id)
        {
            return await onlineSurveyDbContext.Users.SingleOrDefaultAsync(u => u.Id == id);
        }

        public IList<User?> GetAll()
        {
            return onlineSurveyDbContext.Users.ToList();
        }

        public async Task<IList<User?>> GetAllAsync()
        {
            return await onlineSurveyDbContext.Users.ToListAsync();
        }

        public IList<User> GetAllWithPredicate(Expression<Func<User, bool>> predicate)
        {
            return onlineSurveyDbContext.Users.Where(predicate).ToList();
        }

        public void Update(User entity)
        {
            onlineSurveyDbContext.Users.Update(entity);
            onlineSurveyDbContext.SaveChanges();
        }

        public async Task UpdateAsync(User entity)
        {
            onlineSurveyDbContext.Users.Update(entity);
            await onlineSurveyDbContext.SaveChangesAsync();
        }

        public async Task<bool> IsExistsAsync(int id)
        {
            return await onlineSurveyDbContext.Users.AnyAsync(u => u.Id == id);
        }
    }
}
