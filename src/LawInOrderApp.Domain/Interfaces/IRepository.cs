using System;
using System.Linq;
namespace LawInOrderApp.Domain.Interfaces
{
    public interface IRepository<TEntity> : 
    IDisposable where TEntity : class
    {
        void Add(TEntity entity);
        TEntity GetById(Guid id);
        IQueryable<TEntity> GetAll();
        void Update(TEntity entity);
        void Remove(TEntity entity);
        int SaveChanges();
    }
}
