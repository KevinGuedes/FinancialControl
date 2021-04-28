using FinancialControl.BLL.Models;
using FinancialControl.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace FinancialControl.DAL.Repositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        private readonly Context _context;
        private readonly RoleManager<Role> _roleManager;

        public RoleRepository(Context context, RoleManager<Role> roleManager) : base(context)
        {
            _context = context;
            _roleManager = roleManager;
        }

        public new async Task Insert(Role role)
        {
            try
            {
                await _roleManager.CreateAsync(role);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public new async Task Update(Role role)
        {
            try
            {
                Role roleToUpdate = await GetById(role.Id);

                roleToUpdate.Name = role.Name;
                roleToUpdate.NormalizedName = role.NormalizedName;
                roleToUpdate.Description = role.Description;

                await _roleManager.UpdateAsync(roleToUpdate);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
