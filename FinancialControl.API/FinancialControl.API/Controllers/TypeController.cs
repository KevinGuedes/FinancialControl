using FinancialControl.DAL;
using FinancialControl.DAL.Interfaces;
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
        private readonly ITypeRepository _typeRepository;

        public TypeController(ITypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Type>>> GetTypes()
        {
            return await _typeRepository.GetAll().ToListAsync();
        }
    }
}
