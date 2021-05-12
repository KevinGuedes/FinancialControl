using FinancialControl.BLL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialControl.DAL.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        new Task<IEnumerable<object>> GetAll();

        new Task<Category> GetById(int id);
    }
}
