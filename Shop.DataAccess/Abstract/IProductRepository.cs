using Shop.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.DataAccess.Abstract
{
   public interface IProductRepository:IBaseRepository<Products>
    {
        List<Products> GetNewArrivals();
        
            
    }
}
