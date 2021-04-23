using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialControl.DAL.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> GetById(int id);

        Task Insert(TEntity entity);

        Task Insert(List<TEntity> entity);

        Task Update(TEntity entity);

        Task Delete(int id);
    }
}
