using FinancialControl.BLL.Models;
using FinancialControl.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Type = FinancialControl.BLL.Models.Type;

namespace FinancialControl.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private readonly Context _context;

        public TypeController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Type>>> GetTypes()
        {
            return await _context.Types.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Type>> GetType(int id)
        {
            Type type = await _context.Types.FindAsync(id);

            if (type == null)
                return NotFound();

            return type;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateType(int id, Type type)
        {
            if (id != type.Id)
                return BadRequest();

            _context.Entry(type).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Type>> InsertType(Type type)
        {
            _context.Types.Add(type);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetType", new { id = type.Id }, type);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Type>> DeleteType(int id)
        {
            Type type = await _context.Types.FindAsync(id);

            if (type == null)
                return NotFound();

            _context.Types.Remove(type);
            await _context.SaveChangesAsync();

            return type;
        }

        private bool TypeExists(int id)
        {
            return _context.Types.Any(c => c.Id == id);
        }
    }
}
