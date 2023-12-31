﻿using OnlineSurveyApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurveyApp.Infrastructure.Repositories
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        T? Get(int id);
        Task<T?> GetAsync(int id);

        IList<T?> GetAll();
        Task<IList<T?>> GetAllAsync();

        void Create(T entity);
        Task CreateAsync(T entity);

        void Update(T entity);
        Task UpdateAsync(T entity);

        void Delete(int id);
        Task DeleteAsync(int id);

        Task<bool> IsExistsAsync(int id);
    }
}
