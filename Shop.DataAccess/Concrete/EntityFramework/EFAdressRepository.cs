using Shop.DataAccess.Abstract;
using Shop.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.DataAccess.Concrete.EntityFramework
{
   public class EFAdressRepository:EFBaseRepository<Adress>,IAdressRepository
    {
        public EFAdressRepository(EFDatabaseContext ctx):base(ctx)
        {
                
        }
        public EFDatabaseContext EFDatabaseContext
        {
            get { return context as EFDatabaseContext; }
        }
    }
}
