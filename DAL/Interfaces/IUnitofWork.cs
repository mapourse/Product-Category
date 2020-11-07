using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitofWork : IDisposable
    {
        void SaveChanges();

        IRepository<Category> CategoryRepository { get; }
        IRepository<Product> ProductRepository { get; }
    }
}
