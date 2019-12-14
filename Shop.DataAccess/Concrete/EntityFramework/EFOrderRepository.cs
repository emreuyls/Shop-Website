using Shop.DataAccess.Abstract;
using Shop.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.DataAccess.Concrete.EntityFramework
{
   public class EFOrderRepository:EFBaseRepository<Orders>,IOrderRepository
    {
        public EFOrderRepository(EFDatabaseContext Ctx):base(Ctx)
        {

        }
    }
}
