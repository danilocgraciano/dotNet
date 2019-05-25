using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using Tracker.Contracts;

namespace Tracker.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected TrackerContext TrackerContext { get; set; }

        public BaseRepository(TrackerContext TrackerContext)
        {
            this.TrackerContext = TrackerContext;
        }

        public IQueryable<T> FindAll()
        {
            return this.TrackerContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.TrackerContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            this.TrackerContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.TrackerContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.TrackerContext.Set<T>().Remove(entity);
        }

        public void Save()
        {
            this.TrackerContext.SaveChanges();
        }
    }
}
