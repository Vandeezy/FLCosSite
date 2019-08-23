using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public abstract class SqlRepository
    {
        public string ConnectionString { get; set; }

        public async Task<IEnumerable<T>> Query<T>(string sql) where T : IFromDataReader<T>
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                try
                {
                    connection.Open();
                    using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
                    {
                        return DataReaderMapToList<T>(dr);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<T> Get<T>(string sql) where T : IFromDataReader<T>
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                try
                {
                    connection.Open();
                    using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
                    {
                        return DataReaderMapToList<T>(dr).FirstOrDefault();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public abstract Task Execute(string sql);

        private List<T> DataReaderMapToList<T>(IDataReader dr) where T : IFromDataReader<T>
        {
            List<T> list = new List<T>();
            T obj = default(T);
            while (dr.Read())
            {
                obj = Activator.CreateInstance<T>();
                list.Add(obj.FromDataReader(dr));
            }
            return list;
        }
    }



    public interface IFromDataReader<T>
    {
        T FromDataReader(IDataReader reader);
    }
}
