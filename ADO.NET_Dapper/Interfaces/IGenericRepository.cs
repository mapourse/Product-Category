using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Dapper.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity: class
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(int entityId);

        TEntity GetbyId(int entityId);
        IEnumerable<TEntity> GetEntities();
        IEnumerable<TEntity> GetEntities(Predicate<TEntity> condition);
    }
}
