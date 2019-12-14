using Microsoft.EntityFrameworkCore;
using Shop.DataAccess.Abstract;
using Shop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.DataAccess.Concrete.EntityFramework
{
    class EFBrandRepository : EFBaseRepository<Brand>, IBrandRepository
    {
        public EFBrandRepository(EFDatabaseContext ctx) : base(ctx)
        {

        }
        public EFDatabaseContext EFDatabaseContext
        {
            get { return context as EFDatabaseContext; }
        }
        public List<Brand> GetBreadcrumb(int id)
        {
            var category = EFDatabaseContext.Category.Find(id);          
            return EFDatabaseContext.Category.Where(x => x.ID == category.SubCategory).Include(x => x.productCategories).ThenInclude(x => x.Brand).Select(x => x.productCategories.Select(a => a.Brand).ToList()).FirstOrDefault();
        }
    }
}
