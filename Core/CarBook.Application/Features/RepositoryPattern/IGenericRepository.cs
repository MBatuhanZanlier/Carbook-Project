﻿namespace CarBook.Application.Features.RepositoryPattern
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetAll();
        void Create(T entity);
        void Update(T entity);
        void Remove(T Entity);
        T GetById(int id);
        List<T> GetCommentsByBlog(int id); 
        public int GetCountCommentByBlog(int id);
    }
}
