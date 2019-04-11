using System;
using System.Collections.Generic;

namespace SecretSantaApp.EfCore.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Create(TEntity entity);
        void Delete(TEntity entity);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Where(Func<TEntity, bool> predicate);
        TEntity First(Func<TEntity, bool> predicate);
        void SaveChanges();
    }
}