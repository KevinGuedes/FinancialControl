using FinancialControl.BLL.Models;
using System.Threading.Tasks;

namespace FinancialControl.DAL.Interfaces
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        Task InsertRole(Role role);

        Task UpdateRole(Role role);
    }
}
