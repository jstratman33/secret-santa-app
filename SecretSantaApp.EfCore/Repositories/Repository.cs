using System;
using System.Collections.Generic;
using System.Linq;
using SecretSantaApp.EfCore.Interfaces;

namespace SecretSantaApp.EfCore.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class 
    {
        protected SecretSantaContext Context { get; }

        public Repository(SecretSantaContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Create(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            Context.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            Context.Set<TEntity>().Attach(entity);
            Context.Set<TEntity>().Remove(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToArray();
        }

        public IEnumerable<TEntity> Where(Func<TEntity, bool> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public TEntity First(Func<TEntity, bool> predicate)
        {
            return Context.Set<TEntity>().FirstOrDefault(predicate);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}