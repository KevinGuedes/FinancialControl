using FinancialControl.BLL.Models;
using System.Threading.Tasks;

namespace FinancialControl.DAL.Interfaces
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        new Task Insert(Role role);

        new Task Update(Role role);
    }
}
