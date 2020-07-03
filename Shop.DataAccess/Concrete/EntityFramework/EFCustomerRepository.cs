using Microsoft.EntityFrameworkCore;
using Shop.DataAccess.Abstract;
using Shop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Shop.DataAccess.Concrete.EntityFramework
{
     public class EFCustomerRepository : EFBaseRepository<Customers>, ICustomerRepository
    {

        public EFCustomerRepository(DbContext ctx) : base(ctx)
        {

        }
        public EFDatabaseContext EFDatabaseContext
        {
            get { return context as EFDatabaseContext; }
        }
    }
}
