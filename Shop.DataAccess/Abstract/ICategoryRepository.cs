using Shop.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.DataAccess.Abstract
{
   public interface ICategoryRepository:IBaseRepository<Category>
    {
        int GetCategoryID(string categoryname);
        List<Category> GetBeforeCategory(int id);
    }
}
