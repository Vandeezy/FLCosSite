using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IUserService : IService<User>
    {

    }
    public class UserService : IUserService
    {
        private FLCosContext _db;
        public UserService(FLCosContext db)
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

        public User Get(int id)
        {
            return _db.Users.Where(s => s.Id == id).FirstOrDefault();
        }

        public List<User> GetAll(Expression<Func<User, bool>> filter)
        {
            return _db.Users.Where(filter).ToList();
        }

        public IQueryable<User> Query(Expression<Func<User, bool>> query)
        {
            return _db.Users.Where(query);
        }

        public async Task SaveAsync(User entity)
        {
            _db.Users.Add(entity);
            await _db.SaveChangesAsync();
        }
    }
}
