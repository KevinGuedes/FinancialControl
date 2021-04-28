using FinancialControl.BLL.Models;
using FinancialControl.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialControl.DAL.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly Context _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserRepository(Context context, UserManager<User> userManager, SignInManager<User> signInManager) : base(context)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> AddUserToRole(User user, string role)
        {
            try
            {
                return await _userManager.AddToRoleAsync(user, role);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IdentityResult> CreateUser(User user, string password)
        {
            try
            {
                return await _userManager.CreateAsync(user, password);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> GetUsersCount()
        {

            try
            {
                return await _context.Users.CountAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task SignInUser(User user, bool remember)
        {
            try
            {
                await _signInManager.SignInAsync(user, false);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
