using Shop.DataAccess.Abstract;
using Shop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.DataAccess.Concrete.EntityFramework
{
   public class EFProductRepository:EFBaseRepository<Products>,IProductRepository
    {
        public EFProductRepository(EFDatabaseContext ctx):base(ctx)
        {

        }
        public EFDatabaseContext EFDatabaseContext
        {
            get { return context as EFDatabaseContext; }
        }

        public List<Products> GetNewArrivals()
        {
            return EFDatabaseContext.Products.OrderByDescending(x => x.ID).Take(10).ToList();
        }
    }
}
