using FinancialControl.API.DTOs;
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
    [Route("[controller]")]
    [ApiController]
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
        public async Task<ActionResult<Role>> GetRoleById(string id)
        {
            Role role = await _roleRepository.GetById(id);

            if (role == null)
                return NotFound();

            return role;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(string id, RoleDTO roleDTO)
        {
            if (id != roleDTO.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                Role roleToUpdate = new()
                {
                    Id = roleDTO.Id,
                    Name = roleDTO.Name,
                    Description = roleDTO.Description
                };

                await _roleRepository.Update(roleToUpdate);

                return Ok(new
                {
                    message = $"Role {roleToUpdate.Name} updated"
                });
            }

            return BadRequest(ModelState);
        }

        [HttpPost]
        public async Task<ActionResult<Role>> InsertRole(RoleDTO roleDTO)
        {
            if (ModelState.IsValid)
            {
                Role newRole = new()
                {
                    Name = roleDTO.Name,
                    Description = roleDTO.Description
                };

                await _roleRepository.Insert(newRole);

                return Ok(new
                {
                    message = $"Role {newRole.Name} created"
                });
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Role>> DeleteRole(string id)
        {
            Role role = await _roleRepository.GetById(id);

            if (role == null)
                return NotFound();

            await _roleRepository.Delete(role);

            return Ok(new
            {
                message = $"Role {role.Name} deleted"
            });
        }
    }
}
