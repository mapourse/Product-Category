using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class ProductRepository : IRepository<Product>
    {
        Market _ctx;
        private bool _isDisposed;

        public ProductRepository(Market ctx)
        {
            _ctx = ctx;
        }

        public void DeleteEntity(int entityId)
        {
            Product pr = _ctx.Products
                .FirstOrDefault(p => p.Id == entityId);

            _ctx.Products.Remove(pr);
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

        public IEnumerable<Product> GetEntities()
        {
            return _ctx.Products
                .ToList();
        }

        public IEnumerable<Product> GetEntities(Predicate<Product> condition)
        {
            return GetEntities()
                .Where(p => condition(p));
        }

        public Product GetEntitybyId(int entityId)
        {
            return GetEntities()
                .FirstOrDefault(p => p.Id == entityId);
        }

        public void InsertorUpdateEntity(Product entity)
        {
            Product toUpdate = _ctx.Products.FirstOrDefault(p => p.Id == entity.Id);

            if (toUpdate != null)
                _ctx.Entry(toUpdate).CurrentValues.SetValues(entity);
            else
                _ctx.Entry(entity).State =
                    System.Data.Entity.EntityState.Added;
        }

        public void Save()
        {
            _ctx.SaveChanges();
        }
    }
}
