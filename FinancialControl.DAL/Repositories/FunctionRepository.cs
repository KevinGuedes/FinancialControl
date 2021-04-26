using FinancialControl.BLL.Models;
using FinancialControl.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialControl.DAL.Repositories
{
    public class FunctionRepository : GenericRepository<Function>, IFunctionRepository
    {
        private readonly Context _context;
        private readonly RoleManager<Function> _roleManager;

        public FunctionRepository(Context context, RoleManager<Function> roleManager) : base(context)
        {
            _context = context;
            _roleManager = roleManager;
        }

        public async Task InsertFunction(Function function)
        {
            try
            {
                await _roleManager.CreateAsync(function);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task UpdateFunction(Function function)
        {
            try
            {
                Function functionToUpdate = await GetById(function.Id);

                functionToUpdate.Name = function.Name;
                functionToUpdate.NormalizedName = function.NormalizedName;
                functionToUpdate.Description = function.Description;

                await _roleManager.UpdateAsync(functionToUpdate);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
