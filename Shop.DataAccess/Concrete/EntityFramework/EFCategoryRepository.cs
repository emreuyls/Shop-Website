using Microsoft.EntityFrameworkCore;
using Shop.DataAccess.Abstract;
using Shop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.DataAccess.Concrete.EntityFramework
{
    public class EFCategoryRepository:EFBaseRepository<Category>,ICategoryRepository
    {
        public EFCategoryRepository(EFDatabaseContext ctx):base(ctx)
        {

        }
        public EFDatabaseContext EFDatabaseContext
        {
            get { return context as EFDatabaseContext; }
        }

        public List<Category> GetBeforeCategory(int id)
        {
          
            return EFDatabaseContext.Category.Where(x => x.ID == id).ToList();
        }

        public int GetCategoryID(string categoryname)
        {
           return EFDatabaseContext.Category.Where(x => x.CategoryName == categoryname).Select(x => x.ID).FirstOrDefault();
        }
    }
}
