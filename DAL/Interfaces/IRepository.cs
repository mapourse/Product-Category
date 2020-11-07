using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository<TEntity> : IDisposable
    {
        void InsertorUpdateEntity(TEntity entity);
        void DeleteEntity(int entityId);
        void Save();

        TEntity GetEntitybyId(int entityId);
        IEnumerable<TEntity> GetEntities();
        IEnumerable<TEntity> GetEntities(Predicate<TEntity> condition);
    }
}
