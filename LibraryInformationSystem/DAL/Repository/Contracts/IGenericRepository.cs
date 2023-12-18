﻿using LibraryInformationSystem.LibraryInformationSystem.DAL.Entities;
using System.Linq.Expressions;

namespace LibraryInformationSystem.LibraryInformationSystem.DAL.Repository.Contracts
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(long id);
        Task<IEnumerable<T>> FindManyWithFilter(Expression<Func<T, bool>> expression);
        Task<T> FindOneWithFilter(Expression<Func<T, bool>> expression);
        Task<long> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(long id);
    }
}