using ADO.NET_Dapper.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Dapper
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity: class
    {
        private string _tableName;

        private IEnumerable<PropertyInfo> GetProperties => typeof(TEntity).GetProperties();

        public GenericRepository(string tableName)
        {
            _tableName = tableName;
        }

        private SqlConnection SqlConnection()
        {
            return new SqlConnection(
                    ConfigurationManager
                    .ConnectionStrings["ShopDb"]
                    .ConnectionString
                );
        }

        private IDbConnection CreateConnection()
        {
            IDbConnection conn = SqlConnection();
            conn.Open();
            return conn;
        }

        private static List<string> GenerateListOfProperties(IEnumerable<PropertyInfo> listOfProperties)
        {
            return (from prop in listOfProperties
                    let attributes = prop.GetCustomAttributes(typeof(DescriptionAttribute), false)
                    where attributes.Length <= 0 || (attributes[0] as DescriptionAttribute)?.Description != "ignore"
                    select prop.Name).ToList();
        }

        private string GenerateInsertQuery()
        {
            var insertQuery = new StringBuilder($"INSERT INTO {_tableName} ");

            insertQuery.Append("(");

            var properties = GenerateListOfProperties(GetProperties);
            foreach (var prop in properties)
            {
                if (prop != "Id")
                    insertQuery.Append($"[{prop}],");
            }

            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append(") VALUES (");

            foreach (var prop in properties)
            {
                if (prop != "Id")
                    insertQuery.Append($"@{prop},");
            }

            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append($") ");

            return insertQuery.ToString();
        }

        public void Insert(TEntity entity)
        {
            using (var connection = CreateConnection())
            {
                string query = GenerateInsertQuery();
                connection.Execute(query, entity);
            }
        }

        private string GenerateUpdateQuery()
        {
            var updateQuery = new StringBuilder($"UPDATE {_tableName} SET ");
            var properties = GenerateListOfProperties(GetProperties);

            properties.ForEach(property =>
            {
                if (!property.Equals("Id"))
                {
                    updateQuery.Append($"{property}=@{property},");
                }
            });

            updateQuery.Remove(updateQuery.Length - 1, 1); //remove last comma
            updateQuery.Append(" WHERE Id=@Id");

            return updateQuery.ToString();
        }

        public void Update(TEntity entity)
        {
            using (var connection = CreateConnection())
            {
                string query = GenerateUpdateQuery();
                connection.Execute(query, entity);
            }
        }

        public void Delete(int entityId)
        {
            using (IDbConnection connection = CreateConnection())
            {
                connection
                .Execute(
                        $"DELETE " +
                        $"FROM {_tableName} " +
                        $"WHERE Id=@Id ",
                        new { Id = entityId }
                    );
            }
        }

        public TEntity GetbyId(int entityId)
        {
            using (IDbConnection connection = CreateConnection())
            {
                return connection
                    .Query<TEntity>(
                            $"SELECT * " +
                            $"FROM {_tableName} " +
                            $"WHERE Id=@Id ",
                            new { Id = entityId }
                        )
                    .FirstOrDefault();
            }
        }

        public IEnumerable<TEntity> GetEntities()
        {
            using (IDbConnection connection = CreateConnection())
            {
                return connection
                    .Query<TEntity>(
                            $"SELECT * " +
                            $"FROM {_tableName} "
                        );
            }
        }

        public IEnumerable<TEntity> GetEntities(Predicate<TEntity> condition)
        {
            using (IDbConnection connection = CreateConnection())
            {
                return GetEntities()
                    .Where(e => condition(e));
            }
        }
    }
}
