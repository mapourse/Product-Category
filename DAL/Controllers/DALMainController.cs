using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controllers
{
    public class DALMainController : IDisposable
    {
        private IUnitofWork _uow;
        private bool _isDisposed;

        public DALMainController()
        {
            _uow = new UnitofWork();
        }

        public IEnumerable<Category> GetCategories()
        {
            return _uow.CategoryRepository.GetEntities();
        }

        public Category GetCategorybyId(int catId)
        {
            return _uow.CategoryRepository.GetEntitybyId(catId);
        }

        public void InsertorUpdateCategory(Category cat)
        {
            _uow.CategoryRepository.InsertorUpdateEntity(cat);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _uow.ProductRepository.GetEntities();
        }

        public Product GetProductbyId(int prId)
        {
            return _uow.ProductRepository.GetEntitybyId(prId);
        }

        public void InsertorUpdateProduct(Product pr)
        {
            _uow.ProductRepository.InsertorUpdateEntity(pr);
        }

        public void DeleteProductbyId(int prId)
        {
            _uow.ProductRepository.DeleteEntity(prId);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed && disposing)
                _uow.Dispose();
            _isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void SaveChanges()
        {
            _uow.SaveChanges();
        }
    }
}
