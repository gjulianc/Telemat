using System;
using System.Linq;
using System.Linq.Expressions;
using Data.Interfaz;
using Entities;
using System.Data.Entity;

namespace Data.EFRepository
{
    public abstract class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly TelematContext ContextFactory = new TelematContext();
        protected DbSet<T> DbSet;

        protected GenericRepository()
        {
            DbSet = ContextFactory.Set<T>();
        }


        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = DbSet.Where(predicate);
            return query;
        }

        public virtual IQueryable<T> GetAll()
        {
            IQueryable<T> query = DbSet;
            return query;
        }

        public T GetByKey(int id)
        {
            var query = GetAll().FirstOrDefault(e => e.Id == id);
            return query;
        }

        public virtual void Save()
        {
            ContextFactory.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            var entry = ContextFactory.Entry(entity);
            if (entry.State != System.Data.Entity.EntityState.Added)
                entry.State = System.Data.Entity.EntityState.Modified;
        }
    }
}
