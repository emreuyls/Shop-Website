using Microsoft.EntityFrameworkCore;
using Shop.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.DataAccess.Concrete.EntityFramework
{
   public class EFBaseRepository<T> : IBaseRepository<T> where T:class
    {
        protected DbContext context;
        public EFBaseRepository(DbContext  ctx)
        {
            context = ctx;
        }
        public void Create(T entity)
        {
             context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
           context.Set<T>().Remove(entity);
        }

        public IQueryable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().Where(expression);
        }

        public T Get(int id)
        {
            return context.Set<T>().Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return context.Set<T>();
        }

        public void Update(T entity)
        {
            context.Entry<T>(entity).State = EntityState.Modified;
        }
    }
}
