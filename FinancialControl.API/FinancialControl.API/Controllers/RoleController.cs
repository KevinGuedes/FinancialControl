using FinancialControl.API.ViewModels;
using FinancialControl.BLL.Models;
using FinancialControl.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialControl.API.Controllers
{
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;
        
        public RoleController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetRoles()
        {
            return await _roleRepository.GetAll().ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetRole(string id)
        {
            Role function = await _roleRepository.GetById(id);

            if (function == null)
                return NotFound();

            return function;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(string id, RoleViewModel function)
        {
            if (id != function.Id)
                return BadRequest();


            if (ModelState.IsValid)
            {
                Role functionToUpdate = new Role
                {
                    Id = function.Id,
                    Name = function.Name,
                    Description = function.Description
                };

                await _roleRepository.UpdateRole(functionToUpdate);

                return Ok(new
                {
                    message = $"Role {function.Name} updated"
                });
            }

            return BadRequest(ModelState);
        }


        [HttpPost]
        public async Task<ActionResult<Role>> InsertCategory(RoleViewModel function)
        {
            if (ModelState.IsValid)
            {
                Role newRole = new Role
                {
                    Name = function.Name,
                    Description = function.Description
                };

                await _roleRepository.InsertRole(newRole);

                return Ok(new
                {
                    message = $"Role {function.Name} created"
                });
            }

            return BadRequest(ModelState);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Role>> DeleteRole(string id)
        {
            Role function = await _roleRepository.GetById(id);

            if (function == null)
                return NotFound();

            await _roleRepository.Delete(function);

            return Ok(new
            {
                message = $"Role {function.Name} deleted"
            });
        }
    }
}
