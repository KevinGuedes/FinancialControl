using FinancialControl.BLL.Models;
using System.Threading.Tasks;

namespace FinancialControl.DAL.Interfaces
{
    public interface IFunctionRepository : IGenericRepository<Function>
    {
        Task InsertFunction(Function function);

        Task UpdateFunction(Function function);
    }
}
