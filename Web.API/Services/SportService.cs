using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ISportService
    {
        Task<IEnumerable<string>> GetSports();
        Task<Sport> GetSport(int id);
    }

    public class SportService: ISportService
    {
        private IFLCosReaderWriter readerWriter;

        public SportService(IFLCosReaderWriter rw)
        {
            readerWriter = rw;
        }

        public Task<Sport> GetSport(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> GetSports()
        {
            throw new NotImplementedException();
        }
    }
}
