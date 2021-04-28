using FinancialControl.BLL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialControl.DAL.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<int> GetUsersCount();

        Task<IdentityResult> CreateUser(User user, string password);

        Task AddUserToRole(User user, string role);

        Task SignInUser(User user, bool remember);
    }
}
