using DAL.Interfaces;
using DAL.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitofWork : IUnitofWork
    {
        private Market _ctx;

        private bool _isDisposed;
        public IRepository<Category> categoryRepository;
        public IRepository<Product> productRepository;

        public UnitofWork()
        {
            _ctx = new Market();
        }

        public IRepository<Category> CategoryRepository
        {
            get
            {
                if (categoryRepository is null)
                    categoryRepository = new CategoryRepository(_ctx);

                return categoryRepository;
            }
        }

        public IRepository<Product> ProductRepository
        {
            get
            {
                if (productRepository is null)
                    productRepository = new ProductRepository(_ctx);

                return productRepository;
            }
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed && disposing)
                _ctx.Dispose();
            _isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }
    }
}
