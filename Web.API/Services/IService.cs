using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IService<TEntity> where TEntity: class
    {
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> query);
        TEntity Get(int id);
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter);
        Task SaveAsync(TEntity entity);
        Task DeleteAsync(int id);
        Task DeleteListAsync(List<int> id);
    }
}
