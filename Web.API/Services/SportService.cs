using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ISportService: IService<Sport>
    {

    }

    public class SportService: ISportService
    {
        private FLCosContext _db;
        public SportService( FLCosContext db)
        {
            _db = db;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteListAsync(List<int> id)
        {
            throw new NotImplementedException();
        }

        public Sport Get(int id)
        {
            return _db.Sports.Where(s => s.Id == id).FirstOrDefault();
        }

        public List<Sport> GetAll(Expression<Func<Sport, bool>> filter)
        {
            return _db.Sports.Where(filter).ToList();
        }

        public Sport GetSport(int id)
        {
            return _db.Sports.Where(s => s.Id == id).FirstOrDefault();
        }



        public Task<IEnumerable<string>> GetSports()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Sport> Query(Expression<Func<Sport, bool>> query)
        {
           return _db.Sports.Where(query);
        }

        public async Task SaveAsync(Sport sport)
        {
            _db.Sports.Add(sport);
            await _db.SaveChangesAsync();
        }
    }
}
