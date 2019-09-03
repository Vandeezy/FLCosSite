using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IUserService : IService<User>
    {
        Task<ClaimsIdentity> GetUserClaims(User user);
        Task<IDictionary<string, string>> GetAuhenticationProperties(User user);
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

        public async Task<IDictionary<string, string>> GetAuhenticationProperties(User user)
        {
            var props = new Dictionary<string, string>
             {
                { "userName", user.UserName },
                { "userId", user.Id.ToString() },
                //{ "abbreviatedName", user.AbbreviatedName },
                //{ "fullName", user.FullName }
            };

            return await Task.FromResult(props);
        }

        public async Task<ClaimsIdentity> GetUserClaims(User user)
        {
            var id = new ClaimsIdentity("Bearer", ClaimTypes.Name, ClaimTypes.Role);
            id.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString(), ClaimValueTypes.String));
            id.AddClaim(new Claim(ClaimTypes.Name, user.UserName, ClaimValueTypes.String));
            //foreach (var role in user.Roles)
            //{
            //    id.AddClaim(new Claim(ClaimTypes.Role, role.Name, ClaimValueTypes.String));
            //}

            return await Task.FromResult(id);
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
