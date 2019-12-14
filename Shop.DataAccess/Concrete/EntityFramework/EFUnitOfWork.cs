using Shop.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.DataAccess.Concrete.EntityFramework
{
    public class EFUnitOfWork : IUnitOfWork
    {
        EFDatabaseContext dbContext;
        public EFUnitOfWork(EFDatabaseContext _dbContext)
        {
            dbContext = _dbContext ?? throw new Exception("DB Context NULL");
        }
        private IProductRepository _product;
        private ICategoryRepository _category;
        private ISuppliersRepository _suppliers;
        private IOrderRepository _order;
        private IBrandRepository _brand;
        public IProductRepository Products
        {
            get { return _product ?? (_product = new EFProductRepository(dbContext)); }
        }


        public ICategoryRepository Category
        {
            get { return _category ?? (_category = new EFCategoryRepository(dbContext)); }
        }

        public ISuppliersRepository Suppliers
        {
            get { return _suppliers ?? (_suppliers = new EFSuppliersRepository(dbContext)); }
        }

        public IOrderRepository Order
        {
            get { return _order ?? (_order = new EFOrderRepository(dbContext)); }
        }

        public IBrandRepository Brand {
            get { return _brand ?? (_brand = new EFBrandRepository(dbContext));}
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }

        public int SaveChanges()
        {
            try
            {
                return dbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
