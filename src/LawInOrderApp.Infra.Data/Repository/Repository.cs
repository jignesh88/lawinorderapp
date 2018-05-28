using System;
using System.Linq;
using LawInOrderApp.Domain.Interfaces;
using LawInOrderApp.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace LawInOrderApp.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity: class
    {
        protected readonly LawInOrderAppContext db;
        protected readonly DbSet<TEntity> dbSet; 

        public Repository(LawInOrderAppContext context)
        {
            db = context;
            dbSet = db.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public void Dispose()
        {
            db.Dispose();
            GC.SuppressFinalize(this);
        }

        public IQueryable<TEntity> GetAll()
        {
            return dbSet;
        }

        public TEntity GetById(Guid id)
        {
            return dbSet.Find(id);
        }

        public void Remove(TEntity entity)
        {
            dbSet.Remove(entity);
        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            dbSet.Update(entity);
        }
    }
}
