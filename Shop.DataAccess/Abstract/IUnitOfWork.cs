using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.DataAccess.Abstract
{
   public interface IUnitOfWork:IDisposable
    {
        IProductRepository Products { get; }
        ICategoryRepository Category { get; }
        ISuppliersRepository Suppliers { get; }
        IOrderRepository Order { get; }
        IBrandRepository Brand { get; }
        ICustomerRepository Customer { get; }
        IAdressRepository Adress { get; }
        int SaveChanges();
    }
}
