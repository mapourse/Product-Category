using ADO.NET_Dapper.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Dapper
{
    public class GenericUnitofWork
    {
        private Dictionary<Type, object> _repos = new Dictionary<Type, object>();
    
        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (_repos.Keys.Contains(typeof(TEntity)) is true)
            {
                return _repos[typeof(TEntity)] as IGenericRepository<TEntity>;
            }

            IGenericRepository<TEntity> repo = new GenericRepository<TEntity>(typeof(TEntity).Name);
            _repos.Add(typeof(TEntity), repo);
            return repo;
        }
    }
}
