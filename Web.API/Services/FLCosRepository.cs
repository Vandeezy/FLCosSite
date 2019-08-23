using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class FLCosRepository : SqlRepository, IFLCosReaderWriter
    {
        public FLCosRepository(string server, string database)
        {
            ConnectionString = string.Format("Data Source={0};initial catalog={1};Integrated Security=True;MultipleActiveResultSets=True;", server, database);
        }
        public override async Task Execute(string sql)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                try
                {
                    connection.Open();
                    await cmd.ExecuteNonQueryAsync();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
