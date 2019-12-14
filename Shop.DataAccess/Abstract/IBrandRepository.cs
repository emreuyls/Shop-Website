using Shop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.DataAccess.Abstract
{
   public interface IBrandRepository:IBaseRepository<Brand>
    {
        List<Brand> GetBreadcrumb(int id);

    }
}
