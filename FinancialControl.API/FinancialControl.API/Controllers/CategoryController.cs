using FinancialControl.BLL.Models;
using FinancialControl.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinancialControl.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<object>> GetCategories()  //can be Task<dynamic>
        {
            return await _categoryRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {
            Category category = await _categoryRepository.GetById(id);

            if (category == null)
                return NotFound();

            return category;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, Category category)
        {
            if (id != category.Id)
                return BadRequest();


            if (ModelState.IsValid)
            {
                await _categoryRepository.Update(category);

                return Ok(new
                {
                    message = $"Category {category.Name} updated"
                });
            }

            return BadRequest(ModelState);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> InsertCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                await _categoryRepository.Insert(category);

                return Ok(new
                {
                    message = $"Category {category.Name} created"
                });
            }

            return BadRequest(ModelState);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> DeleteCategory(int id)
        {
            Category category = await _categoryRepository.GetById(id);

            if (category == null)
                return NotFound();

            await _categoryRepository.Delete(id);

            return Ok(new
            {
                message = $"Category {category.Name} deleted"
            });
        }
    }
}
