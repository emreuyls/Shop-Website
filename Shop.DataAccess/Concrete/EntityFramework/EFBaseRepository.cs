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
        //TODO: Save methodunu kontrol et ileride hata döndürme ihtimali var
        protected DbContext context;
        public EFBaseRepository(DbContext  ctx)
        {
            context = ctx;
        }
        public int Create(T entity)
        {
             context.Set<T>().Add(entity);
           return Save();
        }

        public int Delete(T entity)
        {
           context.Set<T>().Remove(entity);
           return Save();
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

        public int Save()
        {
            return context.SaveChanges();
        }

        public int Update(T entity)
        {
            context.Entry<T>(entity).State = EntityState.Modified;
            
            return Save();
        }
    }
}
