using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Controllers
{
    public class DALMainController
    {
        private Market _ctx;

        public DALMainController()
        {
            _ctx = new Market();
        }

        public IEnumerable<Category> GetCategories()
        {
            return _ctx.Categories
                .ToList();
        }

        public Category GetCategorybyId(int catId)
        {
            return GetCategories()
                .FirstOrDefault(c => c.Id == catId);
        }

        public void InsertorUpdateCategory(Category cat)
        {
            _ctx.Entry(cat).State = cat.Id == 0 ?
                System.Data.Entity.EntityState.Added :
                System.Data.Entity.EntityState.Modified;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _ctx.Products
                .ToList();
        }

        public Product GetProductbyId(int prId)
        {
            return GetProducts()
                .FirstOrDefault(p => p.Id == prId);
        }

        public void InsertorUpdateProduct(Product pr)
        {
            _ctx.Entry(pr).State = pr.Id == 0 ?
                System.Data.Entity.EntityState.Added :
                System.Data.Entity.EntityState.Modified;
        }

        public void DeleteProductbyId(int prId)
        {
            Product pr = _ctx.Products
                .FirstOrDefault(p => p.Id == prId);

            _ctx.Products.Remove(pr);
        }

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }
    }
}
