using FinancialControl.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = FinancialControl.BLL.Models.Type;

namespace FinancialControl.DAL.Repositories
{
    public class TypeRepository : GenericRepository<Type>, ITypeRepository
    {
        public TypeRepository(Context context) : base(context)
        {
        }
    }
}
