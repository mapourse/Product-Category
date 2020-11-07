using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class CategoryRepository : IRepository<Category>
    {
        Market _ctx;
        private bool _isDisposed;

        public CategoryRepository(Market ctx)
        {
            _ctx = ctx;
        }

        public void DeleteEntity(int entityId)
        {
            Category cat = _ctx.Categories
                .FirstOrDefault(c => c.Id == entityId);

            _ctx.Categories.Remove(cat);
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

        public IEnumerable<Category> GetEntities()
        {
            return _ctx.Categories
                .ToList();
        }

        public IEnumerable<Category> GetEntities(Predicate<Category> condition)
        {
            return GetEntities()
                .Where(c => condition(c));
        }

        public Category GetEntitybyId(int entityId)
        {
            return GetEntities()
                .FirstOrDefault(c => c.Id == entityId);
        }

        public void InsertorUpdateEntity(Category entity)
        {
            _ctx.Entry(entity).State = entity.Id == 0 ?
               System.Data.Entity.EntityState.Added :
               System.Data.Entity.EntityState.Modified;
        }

        public void Save()
        {
            _ctx.SaveChanges();
        }
    }
}
