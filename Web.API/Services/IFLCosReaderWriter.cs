using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IFLCosReaderWriter
    {
        Task<IEnumerable<T>> Query<T>(string sql) where T : IFromDataReader<T>;
        Task<T> Get<T>(string sql) where T : IFromDataReader<T>;
        Task Execute(string sql);
    }

}
