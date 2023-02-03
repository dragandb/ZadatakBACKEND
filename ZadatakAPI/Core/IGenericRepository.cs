﻿namespace ZadatakAPI.Core
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> ALL();
        Task<T?> GetById(int Id);
        Task<bool> Add(T entity);
        Task<bool> Delete(T entity);
        Task<bool> Update(T entity);

    }
}
