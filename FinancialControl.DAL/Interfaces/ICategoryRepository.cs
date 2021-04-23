using FinancialControl.BLL.Models;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialControl.DAL.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        new IQueryable<Category> GetAll();

        new Task<Category> GetById(int id);
    }
}
