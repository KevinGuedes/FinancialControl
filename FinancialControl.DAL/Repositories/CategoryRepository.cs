using FinancialControl.BLL.Models;
using FinancialControl.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialControl.DAL.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly Context _context;

        public CategoryRepository(Context context) : base(context)
        {
            _context = context;
        }

        public new IQueryable<Category> GetAll()
        {
            try
            {
                return _context.Categories.Include(c => c.Type);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public new async Task<Category> GetById(int id)
        {
            try
            {
                return await _context.Categories.Include(c => c.Type).FirstOrDefaultAsync(c => c.Id == id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
