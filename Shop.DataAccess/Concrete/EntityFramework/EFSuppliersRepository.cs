using Shop.DataAccess.Abstract;
using Shop.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.DataAccess.Concrete.EntityFramework
{
   public class EFSuppliersRepository:EFBaseRepository<Suppliers>,ISuppliersRepository
    {
        public EFSuppliersRepository(EFDatabaseContext ctx):base(ctx)
        {

        }
    }
}
